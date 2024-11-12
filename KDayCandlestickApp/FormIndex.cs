using System.Globalization;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Data.SqlClient;
using ScottPlot;
using System;
using YahooFinanceApi;
using System.Linq;
using NodaTime;
using LiveChartsCore;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrayNotify;
using KDayCandlestickApp.DataModels;
using System.Net.Http;
using System.Threading.Tasks;
using Color = System.Drawing.Color;



namespace KDayCandlestickApp
{
    public partial class KDayCandlestickApp : Form
    {
        bool isLoading = false;
        private static readonly HttpClient httpClient = new HttpClient();
        List<StockDailyData> stockDailyDatas = new List<StockDailyData>();
        List<StockData> StockDatas = new List<StockData>();
        public string Sqlstr = @"Server=localhost;Database=master;User Id=SYSADM;Password=SYSADM";
        string[] headers = [];

        public KDayCandlestickApp()
        {
            InitializeComponent();
            comboBoxYears.SelectedItem = "���� " + (DateTime.Now.Year - 1911) + " �~";
            comboBoxRTYearsB.SelectedItem = "���� " + (DateTime.Now.Year - 1911) + " �~";
            comboBoxRTYearsE.SelectedItem = "���� " + (DateTime.Now.Year - 1911) + " �~";
            comboBoxMonths.SelectedItem = DateTime.Now.Month + " ��";
            comboBoxRTMonthsB.SelectedItem = DateTime.Now.Month - 3 + " ��";
            comboBoxRTMonthsE.SelectedItem = DateTime.Now.Month + " ��";
            comboBoxStockNo.TextChanged += ComboBoxStockNo_TextChanged;
            comboBoxRTStockNo.TextChanged += ComboBoxRTStockNo_TextChanged;
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (isLoading == true) return;
                isLoading = true;
                //this.Text = "";
                Cursor = Cursors.WaitCursor;

                string stockNo = comboBoxRTStockNo.Text.Split("\t")[0].Trim();

                if (!int.TryParse(comboBoxRTYearsB.Text.Split(" ")[1], out int startYearInt) ||
                    !int.TryParse(comboBoxRTYearsE.Text.Split(" ")[1], out int endYearInt) ||
                    !int.TryParse(comboBoxRTMonthsB.Text.Split(" ")[0], out int startMonthInt) ||
                    !int.TryParse(comboBoxRTMonthsE.Text.Split(" ")[0], out int endMonthInt))
                {
                    MessageBox.Show("�нT�{�~���M�������J�榡�O�_���T");
                    return;
                }

                int startYear = startYearInt + 1911;
                int endYear = endYearInt + 1911;

                var allStockDailyDatas = new List<StockDailyData>();

                using (var httpClient = new HttpClient())
                {
                    for (int year = startYear; year <= endYear; year++)
                    {
                        for (int month = (year == startYear ? startMonthInt : 1); month <= (year == endYear ? endMonthInt : 12); month++)
                        {
                            string monthStr = month.ToString("D2");
                            var res = await httpClient.GetStringAsync($"https://www.twse.com.tw/rwd/zh/afterTrading/STOCK_DAY?date={year}{monthStr}01&stockNo={stockNo}&response=json");
                            var stockDataResponse = JsonSerializer.Deserialize<StockDataRoot>(res);

                            if (stockDataResponse == null || stockDataResponse.Status is not "" && stockDataResponse.Status.Trim() != "OK")
                            {
                                MessageBox.Show(stockDataResponse?.Status ?? "�o�Ϳ��~");
                                continue;
                            }

                            allStockDailyDatas.AddRange(stockDataResponse.Data.Select(row => StockDailyData.FromDataRow(row)));
                        }
                    }
                }

                stockDailyDatas = allStockDailyDatas;
                // �L�o�X�C�Ӥ몺�Ĥ@�ӥ����
                var monthlyFirstTradeDays = stockDailyDatas
                    .GroupBy(x => new { x.Date.Year, x.Date.Month })
                    .Select(g => g.OrderBy(d => d.Date).First()) // �T�O����C�Ӥ몺�Ĥ@��
                    .ToList();

                // �ˬd��Ƶ��ƬO�_����
                if (stockDailyDatas.Count < 5)
                {
                    MessageBox.Show("��Ƥ����H�p�� 5 �鲾�ʥ����u�C");
                    return;
                }

                // �p�� 5 �鲾�ʥ����u
                var movingAverage5Days = stockDailyDatas
                    .Select((data, index) => new
                    {
                        Date = data.Date,
                        MA5 = stockDailyDatas
                            .Skip(Math.Max(0, index - 4)) // �q��e�驹�^�� 5 �Ѫ��ƾ�
                            .Take(5)
                            .Average(x => x.ClosingPrice) // �p��o 5 �Ѫ��������L��
                    })
                    .ToList();

                // �P�����K�u�ϩM����q�W����
                cartesianChart1.Series = new ISeries[]
                {
            // K�u�� Series
            new LiveChartsCore.SkiaSharpView.CandlesticksSeries<LiveChartsCore.Defaults.FinancialPointI>
                {
                    Values = stockDailyDatas.Select(x => new LiveChartsCore.Defaults.FinancialPointI(
                        (double)x.HighestPrice,
                        (double)x.OpeningPrice,
                        (double)x.ClosingPrice,
                        (double)x.LowestPrice)).ToArray(),
                        // �ھں��^�]�m�C��A�����^��
                        UpFill = new LiveChartsCore.SkiaSharpView.Painting.SolidColorPaint(SkiaSharp.SKColors.Red),
                        UpStroke = new LiveChartsCore.SkiaSharpView.Painting.SolidColorPaint(SkiaSharp.SKColors.Red),
                        DownFill = new LiveChartsCore.SkiaSharpView.Painting.SolidColorPaint(SkiaSharp.SKColors.Green),
                        DownStroke = new LiveChartsCore.SkiaSharpView.Painting.SolidColorPaint(SkiaSharp.SKColors.Green),
                        YToolTipLabelFormatter = x => $"H: {x.Model?.High}\r\nL: {x.Model?.Low}\r\nO: {x.Model?.Open}\r\nF: {x.Model?.Close}",
                },
            // ����q�W���Ϩt�C�A�]�m���z���Ǧ�
            new LiveChartsCore.SkiaSharpView.ColumnSeries<double>
                {
                    Values = stockDailyDatas.Select(x => (double)x.TradeVolume).ToArray(),
                    Stroke = null, // �h�����
                    Fill = new LiveChartsCore.SkiaSharpView.Painting.SolidColorPaint(new SkiaSharp.SKColor(128, 128, 128, 128)), // �]�m���z���Ǧ�
                    MaxBarWidth = 10, // �]�m�W���Ϫ��̤j�e��
                    ScalesYAt = 1 // �ϥΦ��nY�b��ܥ���q
                }
            //// 5 �鲾�ʥ����u�t�C
            //new LiveChartsCore.SkiaSharpView.LineSeries<double>
            //    {
            //        Values = movingAverage5Days.Select(x => x.MA5).ToArray(),
            //        Fill = null, // ���ʥ����u�L��R��
            //        Stroke = new LiveChartsCore.SkiaSharpView.Painting.SolidColorPaint(SkiaSharp.SKColors.Blue), // �Ŧ��u
            //        LineSmoothness = 0, // ���u�ӫD���u
            //        GeometrySize = 0 // ���ç�u�W���I
            //    }
                };

                // �]�m X �b�����ҡA��ܨC�Ӥ몺�Ĥ@�ӥ����
                var xLabels = stockDailyDatas
                    .Select(date => $"{date.Date.Month}/{date.Date.Day}") // �榡�Ƭ�����/�顨
                    .ToList();

                // �]�m X �b������
                cartesianChart1.XAxes = new[]
                {
                    new LiveChartsCore.SkiaSharpView.Axis
                        {
                            LabelsRotation = 15,
                            Labels = xLabels.ToArray()
                        }
                };

                // �]�m�D�n�M���nY�b�A������q�M����ϥΤ��P�����
                cartesianChart1.YAxes = new[]
                {
                    new LiveChartsCore.SkiaSharpView.Axis
                        {
                            Name = "Price",
                            Position = LiveChartsCore.Measure.AxisPosition.Start
                        },
            new LiveChartsCore.SkiaSharpView.Axis
                {
                    Name = "TradeVolume",
                    Position = LiveChartsCore.Measure.AxisPosition.End,
                    LabelsRotation = 0
                }
            };

                cartesianChart1.Title = new LiveChartsCore.SkiaSharpView.VisualElements.LabelVisual
                {
                    Text = stockNo,
                    TextSize = 25,
                    Padding = new LiveChartsCore.Drawing.Padding(15),
                    Paint = new LiveChartsCore.SkiaSharpView.Painting.SolidColorPaint(SkiaSharp.SKColors.DarkSlateGray)
                };
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Cursor = Cursors.Default;
                isLoading = false;
            }
        }
        public string[] GetStockNoSuggestions(string searchTerm)
        {
            string[] suggestions = [];
            //https://www.twse.com.tw/rwd/zh/api/codeQuery?query=
            try
            {
                isLoading = true;
                //this.Text = "Fetching suggestions...";
                Cursor = Cursors.WaitCursor;
                using (var httpClient = new HttpClient())
                {
                    var res = httpClient.GetStringAsync("https://www.twse.com.tw/rwd/zh/api/codeQuery?query=" + searchTerm).Result;
                    // convert to the suggestion array
                    suggestions = JsonSerializer.Deserialize<SuggestionAPIResponse>(res)?.Suggestions ?? [];
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                //this.Text = titleName;
                Cursor = Cursors.Default;
                isLoading = false;
            }
            return suggestions;
        }
        class SuggestionAPIResponse
        {
            [JsonPropertyName("suggestions")]
            public string[] Suggestions { get; set; } = [];
        }
        private void ComboBoxStockNo_TextChanged(object? sender, EventArgs e)
        {
            if (comboBoxStockNo.Text.Replace(" ", "") == "" || comboBoxStockNo.Text.Contains("\t") || isLoading) return;
            var items = GetStockNoSuggestions(comboBoxStockNo.Text);
            comboBoxStockNo.Items.Clear();
            comboBoxStockNo.Items.AddRange(items);
            // expand the dropdown
            comboBoxStockNo.DroppedDown = true;
            // focus to last character
            comboBoxStockNo.SelectionStart = comboBoxStockNo.Text.Length;
        }
        private void ComboBoxRTStockNo_TextChanged(object? sender, EventArgs e)
        {
            if (comboBoxRTStockNo.Text.Replace(" ", "") == "" || comboBoxRTStockNo.Text.Contains("\t") || isLoading) return;
            var items = GetStockNoSuggestions(comboBoxRTStockNo.Text);
            comboBoxRTStockNo.Items.Clear();
            comboBoxRTStockNo.Items.AddRange(items);
            // expand the dropdown
            comboBoxRTStockNo.DroppedDown = true;
            // focus to last character
            comboBoxRTStockNo.SelectionStart = comboBoxRTStockNo.Text.Length;
        }

        private void buttonDownload_Click(object sender, EventArgs e)
        {
            try
            {
                if (isLoading == true) return;
                isLoading = true;
                this.Text = "Fetching stock data...";
                Cursor = Cursors.WaitCursor;
                string year = int.TryParse(comboBoxYears.Text.Split(" ")[1], out int yearInt) ? (yearInt + 1911).ToString() : "";
                string month = comboBoxMonths.Text.Split(" ")[0];
                string stockNo = comboBoxStockNo.Text.Split("\t")[0].Trim();
                using (var httpClient = new HttpClient())
                {
                    var res = httpClient.GetStringAsync($"https://www.twse.com.tw/rwd/zh/afterTrading/STOCK_DAY?date={year}{month}01&stockNo={stockNo}&response=json").Result;
                    var stockDataResponse = JsonSerializer.Deserialize<StockDataRoot>(res);
                    if (stockDataResponse == null)
                    {
                        MessageBox.Show("�o�Ϳ��~");
                        return;
                    }
                    if (stockDataResponse.Status is not "" && stockDataResponse.Status.Trim() is not "OK")
                    {
                        MessageBox.Show(stockDataResponse.Status ?? "�o�Ϳ��~");
                        //labelTitle.Text = stockDataResponse.Status;
                        return;
                    }
                    //labelTitle.Text = stockDataResponse.Title;
                    stockDailyDatas = stockDataResponse.Data.Select(row => StockDailyData.FromDataRow(row)).ToList();
                    dataGridViewDaily.DataSource = stockDailyDatas;
                    // set first column as frozen column
                    dataGridViewDaily.Columns[0].Frozen = true;
                    headers = stockDataResponse.Fields.ToArray();
                    // set header names
                    //for (int i = 0; i < headers.Length; i++)
                    //{
                    //    dataGridView1.Columns[i].HeaderText = headers[i];
                    //}
                    // �e k�u��
                    cartesianChart1.Series =
                    [
                        // �ϥ�LiveChartCore.Defaults.FinancialPointI�����w���A�~��h�eK�u��
                        new LiveChartsCore.SkiaSharpView.CandlesticksSeries<LiveChartsCore.Defaults.FinancialPointI>
                        {
                            // ��ڭ̪�����ഫ��FinancialPointI���A
                            Values = stockDailyDatas.Select(x => new LiveChartsCore.Defaults.FinancialPointI((double)x.HighestPrice, (double)x.OpeningPrice, (double)x.ClosingPrice, (double)x.LowestPrice)).ToArray(),
                            // �]�w�ƹ���в��L�h��ܪ���T
                            YToolTipLabelFormatter = x => $"H: {x.Model?.High}\r\nL: {x.Model?.Low}\r\nO: {x.Model?.Open}\r\nF: {x.Model?.Close}",
                        }
                    ];
                    cartesianChart1.XAxes =
                    [
                        new LiveChartsCore.SkiaSharpView.Axis
                        {
                            LabelsRotation = 15,
                            // X�b�������T
                            Labels = stockDailyDatas.Select(x => x.Date.ToString("yyyy/MM/dd")).ToArray()
                        }
                    ];
                    cartesianChart1.Title = new LiveChartsCore.SkiaSharpView.VisualElements.LabelVisual
                    {
                        Text = "K�u�Ͻd��",
                        TextSize = 25,
                        Padding = new LiveChartsCore.Drawing.Padding(15),
                        Paint = new LiveChartsCore.SkiaSharpView.Painting.SolidColorPaint(SkiaSharp.SKColors.DarkSlateGray)
                    };
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {

                Cursor = Cursors.Default;
                isLoading = false;
            }
        }
        
        private void buttonPriceSearch_Click(object sender, EventArgs e)
        {
            try
            {
                // �ˬd�O�_���b���J�A�קK���ƽШD
                if (isLoading) return;

                isLoading = true; // �]�w���J��
                Cursor = Cursors.WaitCursor; // ��ܵ��ݴ��
                // �M�� StockDatas �C��
                StockDatas.Clear();

                // �ϥΫD�P�B HTTP �ШD���o�x�ѨC�馬�L���
                using (var httpClient = new HttpClient())
                {
                    var url = "https://www.twse.com.tw/exchangeReport/STOCK_DAY_ALL?response=open_data";
                    var data = httpClient.GetStringAsync(url).Result;


                    List<string> lines = new List<string>();
                    lines = data.Split("\r\n").ToList();
                    // �����O���Ʊ��_��
                    List<StockData> stocks = new List<StockData>();
                    for (int i = 0; i < lines.Count; i++)
                    {
                        lines[i] = lines[i].Replace("\"", "");
                        if (i == 0)
                        {
                            continue;
                        }
                        var items = lines[i].Split(",").ToList();
                        if (items.Count < 2)
                        {
                            continue;
                        }

                        StockData stockData = new StockData
                        {
                            ID = items[0],
                            StockName = items[1],
                            StockTraded = int.TryParse(items[2], out _) ? int.Parse(items[2]) : 0,
                            StockAmount = long.TryParse(items[3], out var stockAmount) ? stockAmount : 0,
                            // �ϥ� TryParse �O�ҼƦr�ഫ�w��
                            StartAmount = double.TryParse(items[4], out var startAmount) ? startAmount : 0,
                            HighestAmount = double.TryParse(items[5], out var highestAmount) ? highestAmount : 0,
                            LowestAmount = double.TryParse(items[6], out var lowestAmount) ? lowestAmount : 0,
                            FinalTradedAmount = double.TryParse(items[7], out var finalTradedAmount) ? finalTradedAmount : 0,
                            AmountChanged = double.TryParse(items[8], out var amountChanged) ? amountChanged : 0,
                            TradeCount = int.TryParse(items[9], out var tradeCount) ? tradeCount : 0
                        };
                        
                        // �p�⺦�T�ʤ���æs�J PriceChangePercentage
                        if (stockData.StartAmount != 0)
                        {
                            stockData.PriceChangePercentage = Math.Round(((stockData.FinalTradedAmount - stockData.StartAmount) / stockData.StartAmount) * 100, 2);
                        }
                        else
                        {
                            stockData.PriceChangePercentage = 0; // �קK���H�s
                        }
                        // Generate rest
                        stocks.Add(stockData);
                        // ��Ѳ���ƥ[��}�C
                        StockDatas.Add(stockData);
                    }
                    // �ھڿ�ܪ� radioButton �Ӥ����Ѳ�
                    List<StockData> filteredStocks = new List<StockData>();

                    if (radioButtonSAll.Checked) // �����Ѳ�
                    {
                        filteredStocks = StockDatas;
                    }
                    else if (radioButtonM.Checked) // �W���Ѳ�
                    {
                        filteredStocks = StockDatas.Where(stock => !stock.ID.StartsWith("3") && !stock.ID.StartsWith("00")).ToList();
                    }
                    else if (radioButtonB.Checked) // �W�d�Ѳ�
                    {
                        filteredStocks = StockDatas.Where(stock => stock.ID.StartsWith("3")).ToList();
                    }
                    else if (radioButtonE.Checked) // ETF �Ѳ�
                    {
                        filteredStocks = StockDatas.Where(stock => stock.ID.StartsWith("00")).ToList();
                    }
                    // �ھ� textBoxCount ������ܵ���
                    int displayCount = int.TryParse(textBoxCount.Text, out var count) ? count : filteredStocks.Count;

                    // �ھں��T�ζ^�T�i��Ƨ�
                    if (radioButtonStockAmountSort.Checked) // ������B�Ƨ�
                    {
                        var sortedStocks = filteredStocks.OrderByDescending(stock => stock.StockAmount).ToList();
                        dataGridViewDaily.DataSource = sortedStocks.Take(displayCount).ToList();
                    }
                    else if (radioButtonUpSort.Checked) // ���T�Ƨ�
                    {
                        var sortedStocks = filteredStocks.OrderByDescending(stock => stock.PriceChangePercentage).ToList();
                        dataGridViewDaily.DataSource = sortedStocks.Take(displayCount).ToList();
                    }
                    else if (radioButtonDnSort.Checked) // �^�T�Ƨ�
                    {
                        var sortedStocks = filteredStocks.OrderBy(stock => stock.PriceChangePercentage).ToList();
                        dataGridViewDaily.DataSource = sortedStocks.Take(displayCount).ToList();
                    }
                    else
                    {
                        // �p�G����ܱƧǡA�h��ܩҦ��Ѳ�
                        dataGridViewDaily.DataSource = filteredStocks.Take(displayCount).ToList();
                    }
                    //dataGridViewDaily.DataSource = stocks.Take(displayCount).ToList();
                    // �]�w��쪺����W��
                    dataGridViewDaily.Columns["ID"].HeaderText = "�Ѳ��N��";
                    dataGridViewDaily.Columns["StockName"].HeaderText = "�Ѳ��W��";
                    dataGridViewDaily.Columns["StockTraded"].HeaderText = "����Ѽ�";
                    dataGridViewDaily.Columns["StockAmount"].HeaderText = "������B";
                    dataGridViewDaily.Columns["StartAmount"].HeaderText = "�}�L��";
                    dataGridViewDaily.Columns["HighestAmount"].HeaderText = "�̰���";
                    dataGridViewDaily.Columns["LowestAmount"].HeaderText = "�̧C��";
                    dataGridViewDaily.Columns["FinalTradedAmount"].HeaderText = "���L��";
                    dataGridViewDaily.Columns["AmountChanged"].HeaderText = "���^���t";
                    dataGridViewDaily.Columns["TradeCount"].HeaderText = "���浧��";
                    dataGridViewDaily.Columns["StockTraded"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dataGridViewDaily.Columns["StockAmount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dataGridViewDaily.Columns["TradeCount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    // �s�W���T�ʤ������
                    if (!dataGridViewDaily.Columns.Contains("PriceChangePercentage"))
                    {
                        DataGridViewTextBoxColumn priceChangeColumn = new DataGridViewTextBoxColumn
                        {
                            Name = "PriceChangePercentage",
                            HeaderText = "���T(%)",
                            DataPropertyName = "PriceChangePercentage"
                        };
                        dataGridViewDaily.Columns.Add(priceChangeColumn);
                    }

                    // �榡�ƺ��T�ʤ������
                    foreach (DataGridViewRow row in dataGridViewDaily.Rows)
                    {
                        if (row.Cells["PriceChangePercentage"].Value != null)
                        {
                            double percentage = Convert.ToDouble(row.Cells["PriceChangePercentage"].Value);
                            row.Cells["PriceChangePercentage"].Value = percentage.ToString("F2") ;
                        }
                    }
                    // �T�O�ƥ�u�Q�j�w�@��
                    dataGridViewDaily.CellFormatting += dataGridViewDaily_CellFormatting;
                    


                }
            }
            catch (Exception ex)
            {
                // ��ܿ��~�T��
                MessageBox.Show(ex.Message);
            }
            finally
            {
                // ��_��СA�]�w���J���A������
                Cursor = Cursors.Default;
                isLoading = false;
            }
        }
        private void dataGridViewDaily_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // �ˬd�O�_�� AmountChanged �� FinalTradedAmount ���
            if (dataGridViewDaily.Columns[e.ColumnIndex].Name == "AmountChanged" ||
                dataGridViewDaily.Columns[e.ColumnIndex].Name == "FinalTradedAmount"||
                dataGridViewDaily.Columns[e.ColumnIndex].Name == "PriceChangePercentage")
            {
                // ���o AmountChanged ��쪺��
                var amountChangedCell = dataGridViewDaily.Rows[e.RowIndex].Cells["AmountChanged"].Value;

                if (amountChangedCell != null && double.TryParse(amountChangedCell.ToString(), out double amountChanged))
                {
                    if (amountChanged > 0)
                    {
                        e.CellStyle.ForeColor = Color.Red; // ������ܬ���
                    }
                    else if (amountChanged < 0)
                    {
                        e.CellStyle.ForeColor = Color.Green; // �t����ܺ��
                    }
                    else
                    {
                        e.CellStyle.ForeColor = dataGridViewDaily.DefaultCellStyle.ForeColor; // 0 ��ܹw�]�C��
                    }
                }
            }
            // �[�J�d����Ÿ����榡�]�w
            if (dataGridViewDaily.Columns[e.ColumnIndex].Name == "StockTraded" ||
                dataGridViewDaily.Columns[e.ColumnIndex].Name == "StockAmount" ||
                dataGridViewDaily.Columns[e.ColumnIndex].Name == "TradeCount")
            {
                if (e.Value != null && int.TryParse(e.Value.ToString(), out int intValue))
                {
                    e.Value = intValue.ToString("N0"); // �ϥ� "N0" �榡�A�[�J�d����Ÿ�
                    e.FormattingApplied = true;
                }
            }
            if (dataGridViewDaily.Columns[e.ColumnIndex].Name == "StockAmount")
            {
                // �ˬd�O�_�O long �������ƭȡA�î榡�Ƭ��d����
                if (e.Value is long)
                {
                    e.Value = ((long)e.Value).ToString("#,0");
                    e.FormattingApplied = true;
                }
            }
        }
    }
}

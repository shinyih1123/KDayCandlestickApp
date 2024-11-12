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
            comboBoxYears.SelectedItem = "民國 " + (DateTime.Now.Year - 1911) + " 年";
            comboBoxRTYearsB.SelectedItem = "民國 " + (DateTime.Now.Year - 1911) + " 年";
            comboBoxRTYearsE.SelectedItem = "民國 " + (DateTime.Now.Year - 1911) + " 年";
            comboBoxMonths.SelectedItem = DateTime.Now.Month + " 月";
            comboBoxRTMonthsB.SelectedItem = DateTime.Now.Month - 3 + " 月";
            comboBoxRTMonthsE.SelectedItem = DateTime.Now.Month + " 月";
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
                    MessageBox.Show("請確認年份和月份的輸入格式是否正確");
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
                                MessageBox.Show(stockDataResponse?.Status ?? "發生錯誤");
                                continue;
                            }

                            allStockDailyDatas.AddRange(stockDataResponse.Data.Select(row => StockDailyData.FromDataRow(row)));
                        }
                    }
                }

                stockDailyDatas = allStockDailyDatas;
                // 過濾出每個月的第一個交易日
                var monthlyFirstTradeDays = stockDailyDatas
                    .GroupBy(x => new { x.Date.Year, x.Date.Month })
                    .Select(g => g.OrderBy(d => d.Date).First()) // 確保取到每個月的第一天
                    .ToList();

                // 檢查資料筆數是否足夠
                if (stockDailyDatas.Count < 5)
                {
                    MessageBox.Show("資料不足以計算 5 日移動平均線。");
                    return;
                }

                // 計算 5 日移動平均線
                var movingAverage5Days = stockDailyDatas
                    .Select((data, index) => new
                    {
                        Date = data.Date,
                        MA5 = stockDailyDatas
                            .Skip(Math.Max(0, index - 4)) // 從當前日往回取 5 天的數據
                            .Take(5)
                            .Average(x => x.ClosingPrice) // 計算這 5 天的平均收盤價
                    })
                    .ToList();

                // 同時顯示K線圖和交易量柱狀圖
                cartesianChart1.Series = new ISeries[]
                {
            // K線圖 Series
            new LiveChartsCore.SkiaSharpView.CandlesticksSeries<LiveChartsCore.Defaults.FinancialPointI>
                {
                    Values = stockDailyDatas.Select(x => new LiveChartsCore.Defaults.FinancialPointI(
                        (double)x.HighestPrice,
                        (double)x.OpeningPrice,
                        (double)x.ClosingPrice,
                        (double)x.LowestPrice)).ToArray(),
                        // 根據漲跌設置顏色，漲紅跌綠
                        UpFill = new LiveChartsCore.SkiaSharpView.Painting.SolidColorPaint(SkiaSharp.SKColors.Red),
                        UpStroke = new LiveChartsCore.SkiaSharpView.Painting.SolidColorPaint(SkiaSharp.SKColors.Red),
                        DownFill = new LiveChartsCore.SkiaSharpView.Painting.SolidColorPaint(SkiaSharp.SKColors.Green),
                        DownStroke = new LiveChartsCore.SkiaSharpView.Painting.SolidColorPaint(SkiaSharp.SKColors.Green),
                        YToolTipLabelFormatter = x => $"H: {x.Model?.High}\r\nL: {x.Model?.Low}\r\nO: {x.Model?.Open}\r\nF: {x.Model?.Close}",
                },
            // 交易量柱狀圖系列，設置為透明灰色
            new LiveChartsCore.SkiaSharpView.ColumnSeries<double>
                {
                    Values = stockDailyDatas.Select(x => (double)x.TradeVolume).ToArray(),
                    Stroke = null, // 去掉邊框
                    Fill = new LiveChartsCore.SkiaSharpView.Painting.SolidColorPaint(new SkiaSharp.SKColor(128, 128, 128, 128)), // 設置為透明灰色
                    MaxBarWidth = 10, // 設置柱狀圖的最大寬度
                    ScalesYAt = 1 // 使用次要Y軸顯示交易量
                }
            //// 5 日移動平均線系列
            //new LiveChartsCore.SkiaSharpView.LineSeries<double>
            //    {
            //        Values = movingAverage5Days.Select(x => x.MA5).ToArray(),
            //        Fill = null, // 移動平均線無填充色
            //        Stroke = new LiveChartsCore.SkiaSharpView.Painting.SolidColorPaint(SkiaSharp.SKColors.Blue), // 藍色折線
            //        LineSmoothness = 0, // 直線而非曲線
            //        GeometrySize = 0 // 隱藏折線上的點
            //    }
                };

                // 設置 X 軸的標籤，顯示每個月的第一個交易日
                var xLabels = stockDailyDatas
                    .Select(date => $"{date.Date.Month}/{date.Date.Day}") // 格式化為“月/日”
                    .ToList();

                // 設置 X 軸的標籤
                cartesianChart1.XAxes = new[]
                {
                    new LiveChartsCore.SkiaSharpView.Axis
                        {
                            LabelsRotation = 15,
                            Labels = xLabels.ToArray()
                        }
                };

                // 設置主要和次要Y軸，讓交易量和價格使用不同的刻度
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
                        MessageBox.Show("發生錯誤");
                        return;
                    }
                    if (stockDataResponse.Status is not "" && stockDataResponse.Status.Trim() is not "OK")
                    {
                        MessageBox.Show(stockDataResponse.Status ?? "發生錯誤");
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
                    // 畫 k線圖
                    cartesianChart1.Series =
                    [
                        // 使用LiveChartCore.Defaults.FinancialPointI的指定型態才能去畫K線圖
                        new LiveChartsCore.SkiaSharpView.CandlesticksSeries<LiveChartsCore.Defaults.FinancialPointI>
                        {
                            // 把我們的資料轉換成FinancialPointI型態
                            Values = stockDailyDatas.Select(x => new LiveChartsCore.Defaults.FinancialPointI((double)x.HighestPrice, (double)x.OpeningPrice, (double)x.ClosingPrice, (double)x.LowestPrice)).ToArray(),
                            // 設定滑鼠游標移過去顯示的資訊
                            YToolTipLabelFormatter = x => $"H: {x.Model?.High}\r\nL: {x.Model?.Low}\r\nO: {x.Model?.Open}\r\nF: {x.Model?.Close}",
                        }
                    ];
                    cartesianChart1.XAxes =
                    [
                        new LiveChartsCore.SkiaSharpView.Axis
                        {
                            LabelsRotation = 15,
                            // X軸的日期資訊
                            Labels = stockDailyDatas.Select(x => x.Date.ToString("yyyy/MM/dd")).ToArray()
                        }
                    ];
                    cartesianChart1.Title = new LiveChartsCore.SkiaSharpView.VisualElements.LabelVisual
                    {
                        Text = "K線圖範例",
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
                // 檢查是否正在載入，避免重複請求
                if (isLoading) return;

                isLoading = true; // 設定載入中
                Cursor = Cursors.WaitCursor; // 顯示等待游標
                // 清空 StockDatas 列表
                StockDatas.Clear();

                // 使用非同步 HTTP 請求取得台股每日收盤資料
                using (var httpClient = new HttpClient())
                {
                    var url = "https://www.twse.com.tw/exchangeReport/STOCK_DAY_ALL?response=open_data";
                    var data = httpClient.GetStringAsync(url).Result;


                    List<string> lines = new List<string>();
                    lines = data.Split("\r\n").ToList();
                    // 用類別把資料接起來
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
                            // 使用 TryParse 保證數字轉換安全
                            StartAmount = double.TryParse(items[4], out var startAmount) ? startAmount : 0,
                            HighestAmount = double.TryParse(items[5], out var highestAmount) ? highestAmount : 0,
                            LowestAmount = double.TryParse(items[6], out var lowestAmount) ? lowestAmount : 0,
                            FinalTradedAmount = double.TryParse(items[7], out var finalTradedAmount) ? finalTradedAmount : 0,
                            AmountChanged = double.TryParse(items[8], out var amountChanged) ? amountChanged : 0,
                            TradeCount = int.TryParse(items[9], out var tradeCount) ? tradeCount : 0
                        };
                        
                        // 計算漲幅百分比並存入 PriceChangePercentage
                        if (stockData.StartAmount != 0)
                        {
                            stockData.PriceChangePercentage = Math.Round(((stockData.FinalTradedAmount - stockData.StartAmount) / stockData.StartAmount) * 100, 2);
                        }
                        else
                        {
                            stockData.PriceChangePercentage = 0; // 避免除以零
                        }
                        // Generate rest
                        stocks.Add(stockData);
                        // 把股票資料加到陣列
                        StockDatas.Add(stockData);
                    }
                    // 根據選擇的 radioButton 來分類股票
                    List<StockData> filteredStocks = new List<StockData>();

                    if (radioButtonSAll.Checked) // 全部股票
                    {
                        filteredStocks = StockDatas;
                    }
                    else if (radioButtonM.Checked) // 上市股票
                    {
                        filteredStocks = StockDatas.Where(stock => !stock.ID.StartsWith("3") && !stock.ID.StartsWith("00")).ToList();
                    }
                    else if (radioButtonB.Checked) // 上櫃股票
                    {
                        filteredStocks = StockDatas.Where(stock => stock.ID.StartsWith("3")).ToList();
                    }
                    else if (radioButtonE.Checked) // ETF 股票
                    {
                        filteredStocks = StockDatas.Where(stock => stock.ID.StartsWith("00")).ToList();
                    }
                    // 根據 textBoxCount 限制顯示筆數
                    int displayCount = int.TryParse(textBoxCount.Text, out var count) ? count : filteredStocks.Count;

                    // 根據漲幅或跌幅進行排序
                    if (radioButtonStockAmountSort.Checked) // 成交金額排序
                    {
                        var sortedStocks = filteredStocks.OrderByDescending(stock => stock.StockAmount).ToList();
                        dataGridViewDaily.DataSource = sortedStocks.Take(displayCount).ToList();
                    }
                    else if (radioButtonUpSort.Checked) // 漲幅排序
                    {
                        var sortedStocks = filteredStocks.OrderByDescending(stock => stock.PriceChangePercentage).ToList();
                        dataGridViewDaily.DataSource = sortedStocks.Take(displayCount).ToList();
                    }
                    else if (radioButtonDnSort.Checked) // 跌幅排序
                    {
                        var sortedStocks = filteredStocks.OrderBy(stock => stock.PriceChangePercentage).ToList();
                        dataGridViewDaily.DataSource = sortedStocks.Take(displayCount).ToList();
                    }
                    else
                    {
                        // 如果未選擇排序，則顯示所有股票
                        dataGridViewDaily.DataSource = filteredStocks.Take(displayCount).ToList();
                    }
                    //dataGridViewDaily.DataSource = stocks.Take(displayCount).ToList();
                    // 設定欄位的中文名稱
                    dataGridViewDaily.Columns["ID"].HeaderText = "股票代號";
                    dataGridViewDaily.Columns["StockName"].HeaderText = "股票名稱";
                    dataGridViewDaily.Columns["StockTraded"].HeaderText = "成交股數";
                    dataGridViewDaily.Columns["StockAmount"].HeaderText = "成交金額";
                    dataGridViewDaily.Columns["StartAmount"].HeaderText = "開盤價";
                    dataGridViewDaily.Columns["HighestAmount"].HeaderText = "最高價";
                    dataGridViewDaily.Columns["LowestAmount"].HeaderText = "最低價";
                    dataGridViewDaily.Columns["FinalTradedAmount"].HeaderText = "收盤價";
                    dataGridViewDaily.Columns["AmountChanged"].HeaderText = "漲跌價差";
                    dataGridViewDaily.Columns["TradeCount"].HeaderText = "成交筆數";
                    dataGridViewDaily.Columns["StockTraded"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dataGridViewDaily.Columns["StockAmount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dataGridViewDaily.Columns["TradeCount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    // 新增漲幅百分比欄位
                    if (!dataGridViewDaily.Columns.Contains("PriceChangePercentage"))
                    {
                        DataGridViewTextBoxColumn priceChangeColumn = new DataGridViewTextBoxColumn
                        {
                            Name = "PriceChangePercentage",
                            HeaderText = "漲幅(%)",
                            DataPropertyName = "PriceChangePercentage"
                        };
                        dataGridViewDaily.Columns.Add(priceChangeColumn);
                    }

                    // 格式化漲幅百分比顯示
                    foreach (DataGridViewRow row in dataGridViewDaily.Rows)
                    {
                        if (row.Cells["PriceChangePercentage"].Value != null)
                        {
                            double percentage = Convert.ToDouble(row.Cells["PriceChangePercentage"].Value);
                            row.Cells["PriceChangePercentage"].Value = percentage.ToString("F2") ;
                        }
                    }
                    // 確保事件只被綁定一次
                    dataGridViewDaily.CellFormatting += dataGridViewDaily_CellFormatting;
                    


                }
            }
            catch (Exception ex)
            {
                // 顯示錯誤訊息
                MessageBox.Show(ex.Message);
            }
            finally
            {
                // 恢復游標，設定載入狀態為完成
                Cursor = Cursors.Default;
                isLoading = false;
            }
        }
        private void dataGridViewDaily_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // 檢查是否為 AmountChanged 或 FinalTradedAmount 欄位
            if (dataGridViewDaily.Columns[e.ColumnIndex].Name == "AmountChanged" ||
                dataGridViewDaily.Columns[e.ColumnIndex].Name == "FinalTradedAmount"||
                dataGridViewDaily.Columns[e.ColumnIndex].Name == "PriceChangePercentage")
            {
                // 取得 AmountChanged 欄位的值
                var amountChangedCell = dataGridViewDaily.Rows[e.RowIndex].Cells["AmountChanged"].Value;

                if (amountChangedCell != null && double.TryParse(amountChangedCell.ToString(), out double amountChanged))
                {
                    if (amountChanged > 0)
                    {
                        e.CellStyle.ForeColor = Color.Red; // 正數顯示紅色
                    }
                    else if (amountChanged < 0)
                    {
                        e.CellStyle.ForeColor = Color.Green; // 負數顯示綠色
                    }
                    else
                    {
                        e.CellStyle.ForeColor = dataGridViewDaily.DefaultCellStyle.ForeColor; // 0 顯示預設顏色
                    }
                }
            }
            // 加入千分位符號的格式設定
            if (dataGridViewDaily.Columns[e.ColumnIndex].Name == "StockTraded" ||
                dataGridViewDaily.Columns[e.ColumnIndex].Name == "StockAmount" ||
                dataGridViewDaily.Columns[e.ColumnIndex].Name == "TradeCount")
            {
                if (e.Value != null && int.TryParse(e.Value.ToString(), out int intValue))
                {
                    e.Value = intValue.ToString("N0"); // 使用 "N0" 格式，加入千分位符號
                    e.FormattingApplied = true;
                }
            }
            if (dataGridViewDaily.Columns[e.ColumnIndex].Name == "StockAmount")
            {
                // 檢查是否是 long 類型的數值，並格式化為千分位
                if (e.Value is long)
                {
                    e.Value = ((long)e.Value).ToString("#,0");
                    e.FormattingApplied = true;
                }
            }
        }
    }
}

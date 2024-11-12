namespace KDayCandlestickApp
{
    partial class KDayCandlestickApp
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tabControl1 = new TabControl();
            tabPageChoose = new TabPage();
            label5 = new Label();
            dataGridViewDaily = new DataGridView();
            groupBox1 = new GroupBox();
            groupBox2 = new GroupBox();
            radioButtonToday = new RadioButton();
            radioButtonStockAmountSort = new RadioButton();
            radioButtonDnSort = new RadioButton();
            radioButtonUpSort = new RadioButton();
            label4 = new Label();
            textBoxCount = new TextBox();
            buttonPriceSearch = new Button();
            tabPageBackTest = new TabPage();
            cartesianChart1 = new LiveChartsCore.SkiaSharpView.WinForms.CartesianChart();
            groupBox3 = new GroupBox();
            comboBoxRTMonthsE = new ComboBox();
            comboBoxRTYearsE = new ComboBox();
            comboBoxRTStockNo = new ComboBox();
            comboBoxRTMonthsB = new ComboBox();
            comboBoxRTYearsB = new ComboBox();
            groupBox5 = new GroupBox();
            checkBox1 = new CheckBox();
            checkBox2 = new CheckBox();
            checkBox3 = new CheckBox();
            checkBox4 = new CheckBox();
            checkBox5 = new CheckBox();
            checkBox6 = new CheckBox();
            label10 = new Label();
            textBox7 = new TextBox();
            button2 = new Button();
            label9 = new Label();
            groupBox4 = new GroupBox();
            checkBoxCheck4 = new CheckBox();
            checkBoxCheck5 = new CheckBox();
            checkBoxCheck6 = new CheckBox();
            checkBoxCheck3 = new CheckBox();
            checkBoxCheck2 = new CheckBox();
            checkBoxCheck1 = new CheckBox();
            label6 = new Label();
            textBox4 = new TextBox();
            button1 = new Button();
            label7 = new Label();
            label8 = new Label();
            tabPageSetup = new TabPage();
            comboBoxStockNo = new ComboBox();
            label11 = new Label();
            comboBoxMonths = new ComboBox();
            comboBoxYears = new ComboBox();
            label12 = new Label();
            buttonDownload = new Button();
            label1 = new Label();
            radioButtonSAll = new RadioButton();
            radioButtonE = new RadioButton();
            radioButtonB = new RadioButton();
            radioButtonM = new RadioButton();
            tabControl1.SuspendLayout();
            tabPageChoose.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewDaily).BeginInit();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            tabPageBackTest.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox5.SuspendLayout();
            groupBox4.SuspendLayout();
            tabPageSetup.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPageChoose);
            tabControl1.Controls.Add(tabPageBackTest);
            tabControl1.Controls.Add(tabPageSetup);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Font = new Font("Microsoft JhengHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 136);
            tabControl1.Location = new Point(0, 0);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1220, 955);
            tabControl1.TabIndex = 0;
            // 
            // tabPageChoose
            // 
            tabPageChoose.Controls.Add(label5);
            tabPageChoose.Controls.Add(dataGridViewDaily);
            tabPageChoose.Controls.Add(groupBox1);
            tabPageChoose.Location = new Point(4, 34);
            tabPageChoose.Name = "tabPageChoose";
            tabPageChoose.Padding = new Padding(3);
            tabPageChoose.Size = new Size(1212, 917);
            tabPageChoose.TabIndex = 0;
            tabPageChoose.Text = "選股";
            tabPageChoose.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(8, 229);
            label5.Name = "label5";
            label5.Size = new Size(92, 25);
            label5.TabIndex = 5;
            label5.Text = "查詢結果";
            // 
            // dataGridViewDaily
            // 
            dataGridViewDaily.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewDaily.Location = new Point(8, 257);
            dataGridViewDaily.Name = "dataGridViewDaily";
            dataGridViewDaily.RowHeadersWidth = 51;
            dataGridViewDaily.Size = new Size(1035, 652);
            dataGridViewDaily.TabIndex = 3;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(radioButtonSAll);
            groupBox1.Controls.Add(radioButtonE);
            groupBox1.Controls.Add(radioButtonB);
            groupBox1.Controls.Add(radioButtonM);
            groupBox1.Controls.Add(groupBox2);
            groupBox1.Location = new Point(8, 6);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1035, 210);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Text = "●當日收盤行情";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(radioButtonToday);
            groupBox2.Controls.Add(radioButtonStockAmountSort);
            groupBox2.Controls.Add(radioButtonDnSort);
            groupBox2.Controls.Add(radioButtonUpSort);
            groupBox2.Controls.Add(label4);
            groupBox2.Controls.Add(textBoxCount);
            groupBox2.Controls.Add(buttonPriceSearch);
            groupBox2.Location = new Point(23, 70);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(991, 120);
            groupBox2.TabIndex = 4;
            groupBox2.TabStop = false;
            groupBox2.Text = "量價排行";
            // 
            // radioButtonToday
            // 
            radioButtonToday.AutoSize = true;
            radioButtonToday.Checked = true;
            radioButtonToday.Location = new Point(19, 32);
            radioButtonToday.Name = "radioButtonToday";
            radioButtonToday.Size = new Size(113, 29);
            radioButtonToday.TabIndex = 13;
            radioButtonToday.TabStop = true;
            radioButtonToday.Text = "當日收盤";
            radioButtonToday.UseVisualStyleBackColor = true;
            // 
            // radioButtonStockAmountSort
            // 
            radioButtonStockAmountSort.AutoSize = true;
            radioButtonStockAmountSort.Location = new Point(376, 32);
            radioButtonStockAmountSort.Name = "radioButtonStockAmountSort";
            radioButtonStockAmountSort.Size = new Size(153, 29);
            radioButtonStockAmountSort.TabIndex = 12;
            radioButtonStockAmountSort.Text = "成交金額排行";
            radioButtonStockAmountSort.UseVisualStyleBackColor = true;
            // 
            // radioButtonDnSort
            // 
            radioButtonDnSort.AutoSize = true;
            radioButtonDnSort.Location = new Point(257, 32);
            radioButtonDnSort.Name = "radioButtonDnSort";
            radioButtonDnSort.Size = new Size(113, 29);
            radioButtonDnSort.TabIndex = 11;
            radioButtonDnSort.Text = "跌幅排行";
            radioButtonDnSort.UseVisualStyleBackColor = true;
            // 
            // radioButtonUpSort
            // 
            radioButtonUpSort.AutoSize = true;
            radioButtonUpSort.Location = new Point(138, 32);
            radioButtonUpSort.Name = "radioButtonUpSort";
            radioButtonUpSort.Size = new Size(113, 29);
            radioButtonUpSort.TabIndex = 10;
            radioButtonUpSort.Text = "漲幅排行";
            radioButtonUpSort.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(737, 35);
            label4.Name = "label4";
            label4.Size = new Size(92, 25);
            label4.TabIndex = 5;
            label4.Text = "排行筆數";
            // 
            // textBoxCount
            // 
            textBoxCount.Location = new Point(835, 30);
            textBoxCount.Name = "textBoxCount";
            textBoxCount.Size = new Size(39, 33);
            textBoxCount.TabIndex = 5;
            textBoxCount.Text = "30";
            // 
            // buttonPriceSearch
            // 
            buttonPriceSearch.Location = new Point(891, 32);
            buttonPriceSearch.Name = "buttonPriceSearch";
            buttonPriceSearch.Size = new Size(94, 29);
            buttonPriceSearch.TabIndex = 4;
            buttonPriceSearch.Text = "查詢";
            buttonPriceSearch.UseVisualStyleBackColor = true;
            buttonPriceSearch.Click += buttonPriceSearch_Click;
            // 
            // tabPageBackTest
            // 
            tabPageBackTest.Controls.Add(cartesianChart1);
            tabPageBackTest.Controls.Add(groupBox3);
            tabPageBackTest.Location = new Point(4, 34);
            tabPageBackTest.Name = "tabPageBackTest";
            tabPageBackTest.Padding = new Padding(3);
            tabPageBackTest.Size = new Size(1212, 917);
            tabPageBackTest.TabIndex = 1;
            tabPageBackTest.Text = "回測";
            tabPageBackTest.UseVisualStyleBackColor = true;
            // 
            // cartesianChart1
            // 
            cartesianChart1.Location = new Point(8, 296);
            cartesianChart1.Name = "cartesianChart1";
            cartesianChart1.Size = new Size(1241, 613);
            cartesianChart1.TabIndex = 4;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(comboBoxRTMonthsE);
            groupBox3.Controls.Add(comboBoxRTYearsE);
            groupBox3.Controls.Add(comboBoxRTStockNo);
            groupBox3.Controls.Add(comboBoxRTMonthsB);
            groupBox3.Controls.Add(comboBoxRTYearsB);
            groupBox3.Controls.Add(groupBox5);
            groupBox3.Controls.Add(label9);
            groupBox3.Controls.Add(groupBox4);
            groupBox3.Controls.Add(label7);
            groupBox3.Controls.Add(label8);
            groupBox3.Location = new Point(6, 6);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(1156, 284);
            groupBox3.TabIndex = 3;
            groupBox3.TabStop = false;
            groupBox3.Text = "●回測邏輯";
            // 
            // comboBoxRTMonthsE
            // 
            comboBoxRTMonthsE.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxRTMonthsE.FormattingEnabled = true;
            comboBoxRTMonthsE.Items.AddRange(new object[] { "12 月", "11 月", "10 月", "9 月", "8 月", "7 月", "6 月", "5 月", "4 月", "3 月", "2 月", "1 月" });
            comboBoxRTMonthsE.Location = new Point(654, 67);
            comboBoxRTMonthsE.Name = "comboBoxRTMonthsE";
            comboBoxRTMonthsE.Size = new Size(95, 33);
            comboBoxRTMonthsE.TabIndex = 17;
            // 
            // comboBoxRTYearsE
            // 
            comboBoxRTYearsE.AutoCompleteCustomSource.AddRange(new string[] { "113", "112", "111", "110", "109" });
            comboBoxRTYearsE.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboBoxRTYearsE.AutoCompleteSource = AutoCompleteSource.ListItems;
            comboBoxRTYearsE.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxRTYearsE.FormattingEnabled = true;
            comboBoxRTYearsE.Items.AddRange(new object[] { "民國 113 年", "民國 112 年", "民國 111 年", "民國 110 年", "民國 109 年" });
            comboBoxRTYearsE.Location = new Point(477, 67);
            comboBoxRTYearsE.Name = "comboBoxRTYearsE";
            comboBoxRTYearsE.Size = new Size(169, 33);
            comboBoxRTYearsE.TabIndex = 16;
            // 
            // comboBoxRTStockNo
            // 
            comboBoxRTStockNo.FormattingEnabled = true;
            comboBoxRTStockNo.Location = new Point(112, 23);
            comboBoxRTStockNo.Name = "comboBoxRTStockNo";
            comboBoxRTStockNo.Size = new Size(221, 33);
            comboBoxRTStockNo.TabIndex = 15;
            // 
            // comboBoxRTMonthsB
            // 
            comboBoxRTMonthsB.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxRTMonthsB.FormattingEnabled = true;
            comboBoxRTMonthsB.Items.AddRange(new object[] { "12 月", "11 月", "10 月", "9 月", "8 月", "7 月", "6 月", "5 月", "4 月", "3 月", "2 月", "1 月" });
            comboBoxRTMonthsB.Location = new Point(289, 67);
            comboBoxRTMonthsB.Name = "comboBoxRTMonthsB";
            comboBoxRTMonthsB.Size = new Size(95, 33);
            comboBoxRTMonthsB.TabIndex = 14;
            // 
            // comboBoxRTYearsB
            // 
            comboBoxRTYearsB.AutoCompleteCustomSource.AddRange(new string[] { "113", "112", "111", "110", "109" });
            comboBoxRTYearsB.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboBoxRTYearsB.AutoCompleteSource = AutoCompleteSource.ListItems;
            comboBoxRTYearsB.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxRTYearsB.FormattingEnabled = true;
            comboBoxRTYearsB.Items.AddRange(new object[] { "民國 113 年", "民國 112 年", "民國 111 年", "民國 110 年", "民國 109 年" });
            comboBoxRTYearsB.Location = new Point(112, 67);
            comboBoxRTYearsB.Name = "comboBoxRTYearsB";
            comboBoxRTYearsB.Size = new Size(169, 33);
            comboBoxRTYearsB.TabIndex = 13;
            // 
            // groupBox5
            // 
            groupBox5.Controls.Add(checkBox1);
            groupBox5.Controls.Add(checkBox2);
            groupBox5.Controls.Add(checkBox3);
            groupBox5.Controls.Add(checkBox4);
            groupBox5.Controls.Add(checkBox5);
            groupBox5.Controls.Add(checkBox6);
            groupBox5.Controls.Add(label10);
            groupBox5.Controls.Add(textBox7);
            groupBox5.Controls.Add(button2);
            groupBox5.Location = new Point(16, 194);
            groupBox5.Name = "groupBox5";
            groupBox5.Size = new Size(1108, 76);
            groupBox5.TabIndex = 12;
            groupBox5.TabStop = false;
            groupBox5.Text = "條件項目-空";
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(502, 32);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(114, 29);
            checkBox1.TabIndex = 11;
            checkBox1.Text = "烏雲蓋頂";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            checkBox2.AutoSize = true;
            checkBox2.Location = new Point(271, 32);
            checkBox2.Name = "checkBox2";
            checkBox2.Size = new Size(114, 29);
            checkBox2.TabIndex = 10;
            checkBox2.Text = "三隻烏鴉";
            checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox3
            // 
            checkBox3.AutoSize = true;
            checkBox3.Location = new Point(622, 32);
            checkBox3.Name = "checkBox3";
            checkBox3.Size = new Size(114, 29);
            checkBox3.TabIndex = 9;
            checkBox3.Text = "黃昏之星";
            checkBox3.UseVisualStyleBackColor = true;
            // 
            // checkBox4
            // 
            checkBox4.AutoSize = true;
            checkBox4.Location = new Point(396, 32);
            checkBox4.Name = "checkBox4";
            checkBox4.Size = new Size(114, 29);
            checkBox4.TabIndex = 8;
            checkBox4.Text = "空頭吞噬";
            checkBox4.UseVisualStyleBackColor = true;
            // 
            // checkBox5
            // 
            checkBox5.AutoSize = true;
            checkBox5.Location = new Point(151, 32);
            checkBox5.Name = "checkBox5";
            checkBox5.Size = new Size(114, 29);
            checkBox5.TabIndex = 7;
            checkBox5.Text = "射擊之星";
            checkBox5.UseVisualStyleBackColor = true;
            // 
            // checkBox6
            // 
            checkBox6.AutoSize = true;
            checkBox6.Location = new Point(16, 32);
            checkBox6.Name = "checkBox6";
            checkBox6.Size = new Size(134, 29);
            checkBox6.TabIndex = 6;
            checkBox6.Text = "上吊線形態";
            checkBox6.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(851, 34);
            label10.Name = "label10";
            label10.Size = new Size(52, 25);
            label10.TabIndex = 5;
            label10.Text = "天數";
            // 
            // textBox7
            // 
            textBox7.Location = new Point(909, 29);
            textBox7.Name = "textBox7";
            textBox7.Size = new Size(39, 33);
            textBox7.TabIndex = 5;
            // 
            // button2
            // 
            button2.Location = new Point(966, 32);
            button2.Name = "button2";
            button2.Size = new Size(94, 29);
            button2.TabIndex = 4;
            button2.Text = "查詢";
            button2.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(16, 31);
            label9.Name = "label9";
            label9.Size = new Size(92, 25);
            label9.TabIndex = 5;
            label9.Text = "股票代號";
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(checkBoxCheck4);
            groupBox4.Controls.Add(checkBoxCheck5);
            groupBox4.Controls.Add(checkBoxCheck6);
            groupBox4.Controls.Add(checkBoxCheck3);
            groupBox4.Controls.Add(checkBoxCheck2);
            groupBox4.Controls.Add(checkBoxCheck1);
            groupBox4.Controls.Add(label6);
            groupBox4.Controls.Add(textBox4);
            groupBox4.Controls.Add(button1);
            groupBox4.Location = new Point(14, 106);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(1110, 73);
            groupBox4.TabIndex = 4;
            groupBox4.TabStop = false;
            groupBox4.Text = "條件項目-多";
            // 
            // checkBoxCheck4
            // 
            checkBoxCheck4.AutoSize = true;
            checkBoxCheck4.Location = new Point(624, 31);
            checkBoxCheck4.Name = "checkBoxCheck4";
            checkBoxCheck4.Size = new Size(114, 29);
            checkBoxCheck4.TabIndex = 11;
            checkBoxCheck4.Text = "白色三兵";
            checkBoxCheck4.UseVisualStyleBackColor = true;
            // 
            // checkBoxCheck5
            // 
            checkBoxCheck5.AutoSize = true;
            checkBoxCheck5.Location = new Point(504, 31);
            checkBoxCheck5.Name = "checkBoxCheck5";
            checkBoxCheck5.Size = new Size(114, 29);
            checkBoxCheck5.TabIndex = 10;
            checkBoxCheck5.Text = "早晨之星";
            checkBoxCheck5.UseVisualStyleBackColor = true;
            // 
            // checkBoxCheck6
            // 
            checkBoxCheck6.AutoSize = true;
            checkBoxCheck6.Location = new Point(395, 33);
            checkBoxCheck6.Name = "checkBoxCheck6";
            checkBoxCheck6.Size = new Size(94, 29);
            checkBoxCheck6.TabIndex = 9;
            checkBoxCheck6.Text = "穿刺線";
            checkBoxCheck6.UseVisualStyleBackColor = true;
            // 
            // checkBoxCheck3
            // 
            checkBoxCheck3.AutoSize = true;
            checkBoxCheck3.Location = new Point(275, 30);
            checkBoxCheck3.Name = "checkBoxCheck3";
            checkBoxCheck3.Size = new Size(114, 29);
            checkBoxCheck3.TabIndex = 8;
            checkBoxCheck3.Text = "多頭吞噬";
            checkBoxCheck3.UseVisualStyleBackColor = true;
            // 
            // checkBoxCheck2
            // 
            checkBoxCheck2.AutoSize = true;
            checkBoxCheck2.Location = new Point(153, 32);
            checkBoxCheck2.Name = "checkBoxCheck2";
            checkBoxCheck2.Size = new Size(94, 29);
            checkBoxCheck2.TabIndex = 7;
            checkBoxCheck2.Text = "倒錘形";
            checkBoxCheck2.UseVisualStyleBackColor = true;
            // 
            // checkBoxCheck1
            // 
            checkBoxCheck1.AutoSize = true;
            checkBoxCheck1.Location = new Point(16, 32);
            checkBoxCheck1.Name = "checkBoxCheck1";
            checkBoxCheck1.Size = new Size(94, 29);
            checkBoxCheck1.TabIndex = 6;
            checkBoxCheck1.Text = "錘形線";
            checkBoxCheck1.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(853, 33);
            label6.Name = "label6";
            label6.Size = new Size(52, 25);
            label6.TabIndex = 5;
            label6.Text = "天數";
            // 
            // textBox4
            // 
            textBox4.Location = new Point(911, 28);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(39, 33);
            textBox4.TabIndex = 5;
            // 
            // button1
            // 
            button1.Location = new Point(968, 31);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 4;
            button1.Text = "查詢";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(16, 75);
            label7.Name = "label7";
            label7.Size = new Size(92, 25);
            label7.TabIndex = 0;
            label7.Text = "日期開始";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(390, 75);
            label8.Name = "label8";
            label8.Size = new Size(92, 25);
            label8.TabIndex = 1;
            label8.Text = "日期結束";
            // 
            // tabPageSetup
            // 
            tabPageSetup.Controls.Add(comboBoxStockNo);
            tabPageSetup.Controls.Add(label11);
            tabPageSetup.Controls.Add(comboBoxMonths);
            tabPageSetup.Controls.Add(comboBoxYears);
            tabPageSetup.Controls.Add(label12);
            tabPageSetup.Controls.Add(buttonDownload);
            tabPageSetup.Controls.Add(label1);
            tabPageSetup.Location = new Point(4, 34);
            tabPageSetup.Name = "tabPageSetup";
            tabPageSetup.Size = new Size(1212, 917);
            tabPageSetup.TabIndex = 2;
            tabPageSetup.Text = "設定";
            tabPageSetup.UseVisualStyleBackColor = true;
            // 
            // comboBoxStockNo
            // 
            comboBoxStockNo.FormattingEnabled = true;
            comboBoxStockNo.Location = new Point(520, 40);
            comboBoxStockNo.Name = "comboBoxStockNo";
            comboBoxStockNo.Size = new Size(221, 33);
            comboBoxStockNo.TabIndex = 9;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(417, 43);
            label11.Name = "label11";
            label11.Size = new Size(97, 25);
            label11.TabIndex = 8;
            label11.Text = "股票代碼:";
            // 
            // comboBoxMonths
            // 
            comboBoxMonths.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxMonths.FormattingEnabled = true;
            comboBoxMonths.Items.AddRange(new object[] { "12 月", "11 月", "10 月", "9 月", "8 月", "7 月", "6 月", "5 月", "4 月", "3 月", "2 月", "1 月" });
            comboBoxMonths.Location = new Point(294, 40);
            comboBoxMonths.Name = "comboBoxMonths";
            comboBoxMonths.Size = new Size(95, 33);
            comboBoxMonths.TabIndex = 7;
            // 
            // comboBoxYears
            // 
            comboBoxYears.AutoCompleteCustomSource.AddRange(new string[] { "113", "112", "111", "110", "109" });
            comboBoxYears.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboBoxYears.AutoCompleteSource = AutoCompleteSource.ListItems;
            comboBoxYears.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxYears.FormattingEnabled = true;
            comboBoxYears.Items.AddRange(new object[] { "民國 113 年", "民國 112 年", "民國 111 年", "民國 110 年", "民國 109 年" });
            comboBoxYears.Location = new Point(117, 40);
            comboBoxYears.Name = "comboBoxYears";
            comboBoxYears.Size = new Size(169, 33);
            comboBoxYears.TabIndex = 6;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(13, 43);
            label12.Name = "label12";
            label12.Size = new Size(112, 25);
            label12.TabIndex = 5;
            label12.Text = "資料日期：";
            // 
            // buttonDownload
            // 
            buttonDownload.Location = new Point(758, 41);
            buttonDownload.Name = "buttonDownload";
            buttonDownload.Size = new Size(94, 29);
            buttonDownload.TabIndex = 1;
            buttonDownload.Text = "下載";
            buttonDownload.UseVisualStyleBackColor = true;
            buttonDownload.Click += buttonDownload_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(8, 12);
            label1.Name = "label1";
            label1.Size = new Size(212, 25);
            label1.TabIndex = 0;
            label1.Text = "每日收盤價格資料更新";
            // 
            // radioButtonSAll
            // 
            radioButtonSAll.AutoSize = true;
            radioButtonSAll.Checked = true;
            radioButtonSAll.Location = new Point(42, 35);
            radioButtonSAll.Name = "radioButtonSAll";
            radioButtonSAll.Size = new Size(93, 29);
            radioButtonSAll.TabIndex = 17;
            radioButtonSAll.TabStop = true;
            radioButtonSAll.Text = "不分類";
            radioButtonSAll.UseVisualStyleBackColor = true;
            // 
            // radioButtonE
            // 
            radioButtonE.AutoSize = true;
            radioButtonE.Location = new Point(399, 35);
            radioButtonE.Name = "radioButtonE";
            radioButtonE.Size = new Size(66, 29);
            radioButtonE.TabIndex = 16;
            radioButtonE.Text = "ETF";
            radioButtonE.UseVisualStyleBackColor = true;
            // 
            // radioButtonB
            // 
            radioButtonB.AutoSize = true;
            radioButtonB.Location = new Point(280, 35);
            radioButtonB.Name = "radioButtonB";
            radioButtonB.Size = new Size(73, 29);
            radioButtonB.TabIndex = 15;
            radioButtonB.Text = "上櫃";
            radioButtonB.UseVisualStyleBackColor = true;
            // 
            // radioButtonM
            // 
            radioButtonM.AutoSize = true;
            radioButtonM.Location = new Point(161, 35);
            radioButtonM.Name = "radioButtonM";
            radioButtonM.Size = new Size(73, 29);
            radioButtonM.TabIndex = 14;
            radioButtonM.Text = "上市";
            radioButtonM.UseVisualStyleBackColor = true;
            // 
            // KDayCandlestickApp
            // 
            AutoScaleDimensions = new SizeF(9F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1220, 955);
            Controls.Add(tabControl1);
            Name = "KDayCandlestickApp";
            Text = "KDayCandlestickApp";
            WindowState = FormWindowState.Maximized;
            tabControl1.ResumeLayout(false);
            tabPageChoose.ResumeLayout(false);
            tabPageChoose.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewDaily).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            tabPageBackTest.ResumeLayout(false);
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            groupBox5.ResumeLayout(false);
            groupBox5.PerformLayout();
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            tabPageSetup.ResumeLayout(false);
            tabPageSetup.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl1;
        private TabPage tabPageChoose;
        private TabPage tabPageBackTest;
        private TabPage tabPageSetup;
        private Label label1;
        private Button buttonDownload;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private Label label4;
        private TextBox textBoxCount;
        private Button buttonPriceSearch;
        private DataGridView dataGridViewDaily;
        private Label label5;
        private GroupBox groupBox3;
        private Label label9;
        private GroupBox groupBox4;
        private CheckBox checkBoxCheck4;
        private CheckBox checkBoxCheck5;
        private CheckBox checkBoxCheck6;
        private CheckBox checkBoxCheck3;
        private CheckBox checkBoxCheck2;
        private CheckBox checkBoxCheck1;
        private Label label6;
        private TextBox textBox4;
        private Button button1;
        private Label label7;
        private Label label8;
        private GroupBox groupBox5;
        private CheckBox checkBox1;
        private CheckBox checkBox2;
        private CheckBox checkBox3;
        private CheckBox checkBox4;
        private CheckBox checkBox5;
        private CheckBox checkBox6;
        private Label label10;
        private TextBox textBox7;
        private Button button2;
        private LiveChartsCore.SkiaSharpView.WinForms.CartesianChart cartesianChart1;
        private ComboBox comboBoxStockNo;
        private Label label11;
        private ComboBox comboBoxMonths;
        private ComboBox comboBoxYears;
        private Label label12;
        private ComboBox comboBoxRTMonthsE;
        private ComboBox comboBoxRTYearsE;
        private ComboBox comboBoxRTStockNo;
        private ComboBox comboBoxRTMonthsB;
        private ComboBox comboBoxRTYearsB;
        private RadioButton radioButtonDnSort;
        private RadioButton radioButtonUpSort;
        private RadioButton radioButtonStockAmountSort;
        private RadioButton radioButtonToday;
        private RadioButton radioButtonSAll;
        private RadioButton radioButtonE;
        private RadioButton radioButtonB;
        private RadioButton radioButtonM;
    }
}

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
            dataGridView1 = new DataGridView();
            groupBox1 = new GroupBox();
            groupBox2 = new GroupBox();
            radioButtonValueRateDN = new RadioButton();
            radioButtonValueRangeUP = new RadioButton();
            radioButtonValueDN = new RadioButton();
            radioButtonValueUP = new RadioButton();
            label4 = new Label();
            textBox3 = new TextBox();
            buttonPriceSearch = new Button();
            radioButtonPriceRangeDN = new RadioButton();
            radioButtonPriceRangeUP = new RadioButton();
            radioButtonPriceDN = new RadioButton();
            radioButtonPriceUP = new RadioButton();
            textBox2 = new TextBox();
            textBox1 = new TextBox();
            label2 = new Label();
            label3 = new Label();
            tabPageBackTest = new TabPage();
            cartesianChart1 = new LiveChartsCore.SkiaSharpView.WinForms.CartesianChart();
            groupBox3 = new GroupBox();
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
            textBoxCode = new TextBox();
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
            textBox5 = new TextBox();
            textBox6 = new TextBox();
            label7 = new Label();
            label8 = new Label();
            tabPageSetup = new TabPage();
            buttonDownload = new Button();
            label1 = new Label();
            tabControl1.SuspendLayout();
            tabPageChoose.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
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
            tabControl1.Size = new Size(1146, 955);
            tabControl1.TabIndex = 0;
            // 
            // tabPageChoose
            // 
            tabPageChoose.Controls.Add(label5);
            tabPageChoose.Controls.Add(dataGridView1);
            tabPageChoose.Controls.Add(groupBox1);
            tabPageChoose.Location = new Point(4, 34);
            tabPageChoose.Name = "tabPageChoose";
            tabPageChoose.Padding = new Padding(3);
            tabPageChoose.Size = new Size(1138, 917);
            tabPageChoose.TabIndex = 0;
            tabPageChoose.Text = "選股";
            tabPageChoose.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(8, 251);
            label5.Name = "label5";
            label5.Size = new Size(92, 25);
            label5.TabIndex = 5;
            label5.Text = "查詢結果";
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(8, 279);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(1035, 461);
            dataGridView1.TabIndex = 3;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(groupBox2);
            groupBox1.Controls.Add(textBox2);
            groupBox1.Controls.Add(textBox1);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label3);
            groupBox1.Location = new Point(8, 6);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1035, 235);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Text = "●選股邏輯";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(radioButtonValueRateDN);
            groupBox2.Controls.Add(radioButtonValueRangeUP);
            groupBox2.Controls.Add(radioButtonValueDN);
            groupBox2.Controls.Add(radioButtonValueUP);
            groupBox2.Controls.Add(label4);
            groupBox2.Controls.Add(textBox3);
            groupBox2.Controls.Add(buttonPriceSearch);
            groupBox2.Controls.Add(radioButtonPriceRangeDN);
            groupBox2.Controls.Add(radioButtonPriceRangeUP);
            groupBox2.Controls.Add(radioButtonPriceDN);
            groupBox2.Controls.Add(radioButtonPriceUP);
            groupBox2.Location = new Point(23, 70);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(991, 137);
            groupBox2.TabIndex = 4;
            groupBox2.TabStop = false;
            groupBox2.Text = "量價排行";
            // 
            // radioButtonValueRateDN
            // 
            radioButtonValueRateDN.AutoSize = true;
            radioButtonValueRateDN.Location = new Point(407, 36);
            radioButtonValueRateDN.Name = "radioButtonValueRateDN";
            radioButtonValueRateDN.Size = new Size(133, 29);
            radioButtonValueRateDN.TabIndex = 9;
            radioButtonValueRateDN.TabStop = true;
            radioButtonValueRateDN.Text = "量縮幅排行";
            radioButtonValueRateDN.UseVisualStyleBackColor = true;
            // 
            // radioButtonValueRangeUP
            // 
            radioButtonValueRangeUP.AutoSize = true;
            radioButtonValueRangeUP.Location = new Point(268, 36);
            radioButtonValueRangeUP.Name = "radioButtonValueRangeUP";
            radioButtonValueRangeUP.Size = new Size(133, 29);
            radioButtonValueRangeUP.TabIndex = 8;
            radioButtonValueRangeUP.TabStop = true;
            radioButtonValueRangeUP.Text = "量增幅排行";
            radioButtonValueRangeUP.UseVisualStyleBackColor = true;
            // 
            // radioButtonValueDN
            // 
            radioButtonValueDN.AutoSize = true;
            radioButtonValueDN.Location = new Point(149, 36);
            radioButtonValueDN.Name = "radioButtonValueDN";
            radioButtonValueDN.Size = new Size(113, 29);
            radioButtonValueDN.TabIndex = 7;
            radioButtonValueDN.TabStop = true;
            radioButtonValueDN.Text = "量縮排行";
            radioButtonValueDN.UseVisualStyleBackColor = true;
            // 
            // radioButtonValueUP
            // 
            radioButtonValueUP.AutoSize = true;
            radioButtonValueUP.Location = new Point(21, 36);
            radioButtonValueUP.Name = "radioButtonValueUP";
            radioButtonValueUP.Size = new Size(113, 29);
            radioButtonValueUP.TabIndex = 6;
            radioButtonValueUP.TabStop = true;
            radioButtonValueUP.Text = "量增排行";
            radioButtonValueUP.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(765, 73);
            label4.Name = "label4";
            label4.Size = new Size(52, 25);
            label4.TabIndex = 5;
            label4.Text = "天數";
            // 
            // textBox3
            // 
            textBox3.Location = new Point(823, 68);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(39, 33);
            textBox3.TabIndex = 5;
            // 
            // buttonPriceSearch
            // 
            buttonPriceSearch.Location = new Point(879, 70);
            buttonPriceSearch.Name = "buttonPriceSearch";
            buttonPriceSearch.Size = new Size(94, 29);
            buttonPriceSearch.TabIndex = 4;
            buttonPriceSearch.Text = "查詢";
            buttonPriceSearch.UseVisualStyleBackColor = true;
            // 
            // radioButtonPriceRangeDN
            // 
            radioButtonPriceRangeDN.AutoSize = true;
            radioButtonPriceRangeDN.Location = new Point(407, 68);
            radioButtonPriceRangeDN.Name = "radioButtonPriceRangeDN";
            radioButtonPriceRangeDN.Size = new Size(133, 29);
            radioButtonPriceRangeDN.TabIndex = 3;
            radioButtonPriceRangeDN.TabStop = true;
            radioButtonPriceRangeDN.Text = "值縮幅排行";
            radioButtonPriceRangeDN.UseVisualStyleBackColor = true;
            // 
            // radioButtonPriceRangeUP
            // 
            radioButtonPriceRangeUP.AutoSize = true;
            radioButtonPriceRangeUP.Location = new Point(268, 68);
            radioButtonPriceRangeUP.Name = "radioButtonPriceRangeUP";
            radioButtonPriceRangeUP.Size = new Size(133, 29);
            radioButtonPriceRangeUP.TabIndex = 2;
            radioButtonPriceRangeUP.TabStop = true;
            radioButtonPriceRangeUP.Text = "值增幅排行";
            radioButtonPriceRangeUP.UseVisualStyleBackColor = true;
            // 
            // radioButtonPriceDN
            // 
            radioButtonPriceDN.AutoSize = true;
            radioButtonPriceDN.Location = new Point(149, 68);
            radioButtonPriceDN.Name = "radioButtonPriceDN";
            radioButtonPriceDN.Size = new Size(113, 29);
            radioButtonPriceDN.TabIndex = 1;
            radioButtonPriceDN.TabStop = true;
            radioButtonPriceDN.Text = "值縮排行";
            radioButtonPriceDN.UseVisualStyleBackColor = true;
            // 
            // radioButtonPriceUP
            // 
            radioButtonPriceUP.AutoSize = true;
            radioButtonPriceUP.Location = new Point(21, 68);
            radioButtonPriceUP.Name = "radioButtonPriceUP";
            radioButtonPriceUP.Size = new Size(113, 29);
            radioButtonPriceUP.TabIndex = 0;
            radioButtonPriceUP.TabStop = true;
            radioButtonPriceUP.Text = "值增排行";
            radioButtonPriceUP.UseVisualStyleBackColor = true;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(333, 21);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(125, 33);
            textBox2.TabIndex = 3;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(113, 21);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(125, 33);
            textBox1.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(17, 29);
            label2.Name = "label2";
            label2.Size = new Size(92, 25);
            label2.TabIndex = 0;
            label2.Text = "日期開始";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(244, 29);
            label3.Name = "label3";
            label3.Size = new Size(92, 25);
            label3.TabIndex = 1;
            label3.Text = "日期結束";
            // 
            // tabPageBackTest
            // 
            tabPageBackTest.Controls.Add(cartesianChart1);
            tabPageBackTest.Controls.Add(groupBox3);
            tabPageBackTest.Location = new Point(4, 34);
            tabPageBackTest.Name = "tabPageBackTest";
            tabPageBackTest.Padding = new Padding(3);
            tabPageBackTest.Size = new Size(1138, 917);
            tabPageBackTest.TabIndex = 1;
            tabPageBackTest.Text = "回測";
            tabPageBackTest.UseVisualStyleBackColor = true;
            // 
            // cartesianChart1
            // 
            cartesianChart1.Location = new Point(8, 364);
            cartesianChart1.Name = "cartesianChart1";
            cartesianChart1.Size = new Size(1241, 545);
            cartesianChart1.TabIndex = 4;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(groupBox5);
            groupBox3.Controls.Add(textBoxCode);
            groupBox3.Controls.Add(label9);
            groupBox3.Controls.Add(groupBox4);
            groupBox3.Controls.Add(textBox5);
            groupBox3.Controls.Add(textBox6);
            groupBox3.Controls.Add(label7);
            groupBox3.Controls.Add(label8);
            groupBox3.Location = new Point(6, 6);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(1156, 352);
            groupBox3.TabIndex = 3;
            groupBox3.TabStop = false;
            groupBox3.Text = "●回測邏輯";
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
            groupBox5.Location = new Point(16, 226);
            groupBox5.Name = "groupBox5";
            groupBox5.Size = new Size(1108, 114);
            groupBox5.TabIndex = 12;
            groupBox5.TabStop = false;
            groupBox5.Text = "條件項目-空";
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(396, 73);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(114, 29);
            checkBox1.TabIndex = 11;
            checkBox1.Text = "烏雲蓋頂";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            checkBox2.AutoSize = true;
            checkBox2.Location = new Point(205, 73);
            checkBox2.Name = "checkBox2";
            checkBox2.Size = new Size(114, 29);
            checkBox2.TabIndex = 10;
            checkBox2.Text = "三隻烏鴉";
            checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox3
            // 
            checkBox3.AutoSize = true;
            checkBox3.Location = new Point(16, 73);
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
            checkBox5.Location = new Point(205, 32);
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
            label10.Location = new Point(765, 73);
            label10.Name = "label10";
            label10.Size = new Size(52, 25);
            label10.TabIndex = 5;
            label10.Text = "天數";
            // 
            // textBox7
            // 
            textBox7.Location = new Point(823, 68);
            textBox7.Name = "textBox7";
            textBox7.Size = new Size(39, 33);
            textBox7.TabIndex = 5;
            // 
            // button2
            // 
            button2.Location = new Point(880, 71);
            button2.Name = "button2";
            button2.Size = new Size(94, 29);
            button2.TabIndex = 4;
            button2.Text = "查詢";
            button2.UseVisualStyleBackColor = true;
            // 
            // textBoxCode
            // 
            textBoxCode.Location = new Point(112, 28);
            textBoxCode.Name = "textBoxCode";
            textBoxCode.Size = new Size(125, 33);
            textBoxCode.TabIndex = 6;
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
            groupBox4.Size = new Size(1110, 114);
            groupBox4.TabIndex = 4;
            groupBox4.TabStop = false;
            groupBox4.Text = "條件項目-多";
            // 
            // checkBoxCheck4
            // 
            checkBoxCheck4.AutoSize = true;
            checkBoxCheck4.Location = new Point(396, 73);
            checkBoxCheck4.Name = "checkBoxCheck4";
            checkBoxCheck4.Size = new Size(114, 29);
            checkBoxCheck4.TabIndex = 11;
            checkBoxCheck4.Text = "白色三兵";
            checkBoxCheck4.UseVisualStyleBackColor = true;
            // 
            // checkBoxCheck5
            // 
            checkBoxCheck5.AutoSize = true;
            checkBoxCheck5.Location = new Point(205, 73);
            checkBoxCheck5.Name = "checkBoxCheck5";
            checkBoxCheck5.Size = new Size(114, 29);
            checkBoxCheck5.TabIndex = 10;
            checkBoxCheck5.Text = "早晨之星";
            checkBoxCheck5.UseVisualStyleBackColor = true;
            // 
            // checkBoxCheck6
            // 
            checkBoxCheck6.AutoSize = true;
            checkBoxCheck6.Location = new Point(16, 73);
            checkBoxCheck6.Name = "checkBoxCheck6";
            checkBoxCheck6.Size = new Size(94, 29);
            checkBoxCheck6.TabIndex = 9;
            checkBoxCheck6.Text = "穿刺線";
            checkBoxCheck6.UseVisualStyleBackColor = true;
            // 
            // checkBoxCheck3
            // 
            checkBoxCheck3.AutoSize = true;
            checkBoxCheck3.Location = new Point(396, 32);
            checkBoxCheck3.Name = "checkBoxCheck3";
            checkBoxCheck3.Size = new Size(114, 29);
            checkBoxCheck3.TabIndex = 8;
            checkBoxCheck3.Text = "多頭吞噬";
            checkBoxCheck3.UseVisualStyleBackColor = true;
            // 
            // checkBoxCheck2
            // 
            checkBoxCheck2.AutoSize = true;
            checkBoxCheck2.Location = new Point(205, 32);
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
            label6.Location = new Point(765, 73);
            label6.Name = "label6";
            label6.Size = new Size(52, 25);
            label6.TabIndex = 5;
            label6.Text = "天數";
            // 
            // textBox4
            // 
            textBox4.Location = new Point(823, 68);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(39, 33);
            textBox4.TabIndex = 5;
            // 
            // button1
            // 
            button1.Location = new Point(880, 71);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 4;
            button1.Text = "查詢";
            button1.UseVisualStyleBackColor = true;
            // 
            // textBox5
            // 
            textBox5.Location = new Point(332, 67);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(125, 33);
            textBox5.TabIndex = 3;
            // 
            // textBox6
            // 
            textBox6.Location = new Point(112, 67);
            textBox6.Name = "textBox6";
            textBox6.Size = new Size(125, 33);
            textBox6.TabIndex = 2;
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
            label8.Location = new Point(243, 75);
            label8.Name = "label8";
            label8.Size = new Size(92, 25);
            label8.TabIndex = 1;
            label8.Text = "日期結束";
            // 
            // tabPageSetup
            // 
            tabPageSetup.Controls.Add(buttonDownload);
            tabPageSetup.Controls.Add(label1);
            tabPageSetup.Location = new Point(4, 34);
            tabPageSetup.Name = "tabPageSetup";
            tabPageSetup.Size = new Size(1138, 917);
            tabPageSetup.TabIndex = 2;
            tabPageSetup.Text = "設定";
            tabPageSetup.UseVisualStyleBackColor = true;
            // 
            // buttonDownload
            // 
            buttonDownload.Location = new Point(226, 10);
            buttonDownload.Name = "buttonDownload";
            buttonDownload.Size = new Size(94, 29);
            buttonDownload.TabIndex = 1;
            buttonDownload.Text = "下載";
            buttonDownload.UseVisualStyleBackColor = true;
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
            // KDayCandlestickApp
            // 
            AutoScaleDimensions = new SizeF(9F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1146, 955);
            Controls.Add(tabControl1);
            Name = "KDayCandlestickApp";
            Text = "KDayCandlestickApp";
            WindowState = FormWindowState.Maximized;
            tabControl1.ResumeLayout(false);
            tabPageChoose.ResumeLayout(false);
            tabPageChoose.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
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
        private Label label2;
        private Label label3;
        private TextBox textBox2;
        private TextBox textBox1;
        private GroupBox groupBox2;
        private RadioButton radioButtonPriceRangeDN;
        private RadioButton radioButtonPriceRangeUP;
        private RadioButton radioButtonPriceDN;
        private RadioButton radioButtonPriceUP;
        private RadioButton radioButtonValueRateDN;
        private RadioButton radioButtonValueRangeUP;
        private RadioButton radioButtonValueDN;
        private RadioButton radioButtonValueUP;
        private Label label4;
        private TextBox textBox3;
        private Button buttonPriceSearch;
        private DataGridView dataGridView1;
        private Label label5;
        private GroupBox groupBox3;
        private TextBox textBoxCode;
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
        private TextBox textBox5;
        private TextBox textBox6;
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
    }
}

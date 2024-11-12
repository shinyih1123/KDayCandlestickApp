using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KDayCandlestickApp.DataModels
{
    public class StockData
    {
        // 證券代號,證券名稱,成交股數,成交金額,開盤價,最高價,最低價,收盤價,漲跌價差,成交筆數
        public string ID { get; set; } = "";
        public string StockName { get; set; } = "";
        public int StockTraded { get; set; }
        public long StockAmount { get; set; }
        public double StartAmount { get; set; }
        public double HighestAmount { get; set; }
        public double LowestAmount { get; set; }
        public double FinalTradedAmount { get; set; }
        public double AmountChanged { get; set; }
        public int TradeCount { get; set; }
        public double PriceChangePercentage { get; set; } // 新增漲幅百分比屬性
    }
}

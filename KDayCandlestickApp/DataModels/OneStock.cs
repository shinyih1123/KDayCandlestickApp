using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace KDayCandlestickApp.DataModels
{
    internal class OneStock
    {
        //"日期","成交股數","成交金額","開盤價","最高價","最低價","收盤價","漲跌價差","成交筆數"
        public DateTime Date { get; set; }
        public int TradeVolume { get; set; }
        public long TradeValue { get; set; }
        public decimal OpeningPrice { get; set; }
        public decimal HighestPrice { get; set; }
        public decimal LowestPrice { get; set; }
        public decimal ClosingPrice { get; set; }
        public decimal PriceChange { get; set; }
        public int NumberOfTransactions { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KDayCandlestickApp
{
    using System.Text.Json.Serialization;
    public class StockDataRoot
    {
        [JsonPropertyName("stat")]
        public string Status { get; set; } = string.Empty;

        [JsonPropertyName("date")]
        public string Date { get; set; } = string.Empty;

        [JsonPropertyName("title")]
        public string Title { get; set; } = string.Empty;

        [JsonPropertyName("fields")]
        public List<string> Fields { get; set; } = new();

        [JsonPropertyName("data")]
        public List<List<string>> Data { get; set; } = new();

        [JsonPropertyName("notes")]
        public List<string> Notes { get; set; } = new();

        [JsonPropertyName("total")]
        public int Total { get; set; }
    }
    public class StockDailyData
    {
        public DateTime Date { get; set; }
        public long TradeVolume { get; set; }
        public decimal TradeValue { get; set; }
        public decimal OpeningPrice { get; set; }
        public decimal HighestPrice { get; set; }
        public decimal LowestPrice { get; set; }
        public decimal ClosingPrice { get; set; }
        public decimal PriceChange { get; set; }
        public int NumberOfTransactions { get; set; }

        public static StockDailyData FromDataRow(List<string> row)
        {
            return new StockDailyData
            {
                Date = ParseTaiwaneseDate(row[0]),
                TradeVolume = long.Parse(row[1].Replace(",", "")),
                TradeValue = decimal.Parse(row[2].Replace(",", "")),
                OpeningPrice = decimal.Parse(row[3]),
                HighestPrice = decimal.Parse(row[4]),
                LowestPrice = decimal.Parse(row[5]),
                ClosingPrice = decimal.Parse(row[6]),
                PriceChange = ParsePriceChange(row[7]),
                NumberOfTransactions = int.Parse(row[8].Replace(",", ""))
            };
        }

        private static DateTime ParseTaiwaneseDate(string taiwaneseDate)
        {
            // Convert Taiwanese calendar date (113/10/01) to Gregorian calendar
            var parts = taiwaneseDate.Split('/');
            int year = int.Parse(parts[0]) + 1911; // Convert from Taiwanese year to AD
            int month = int.Parse(parts[1]);
            int day = int.Parse(parts[2]);
            return new DateTime(year, month, day);
        }

        private static decimal ParsePriceChange(string priceChange)
        {
            if (string.IsNullOrEmpty(priceChange)) return 0;

            // Handle the +/- prefix
            return decimal.Parse(priceChange.TrimStart('+'));
        }
    }
}

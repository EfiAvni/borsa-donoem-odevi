using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace borsa.Classes
{
    public class StockData
    {
        public string Symbol { get; set; }   // Hisse sembolü (örneğin: AAPL, GOOG)
        public double Price { get; set; }     // Hisse fiyatı
        public string Time { get; set; }      // Güncellenme zamanı
    }

}

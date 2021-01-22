using GFTCategorization.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GFTCategorization
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Culture
            CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("en-US");
            CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo("en-US");
            #endregion

            #region Variables
            DateTime ReferenceDate;
            int NumberOfTrades = 0;
            List<string> Trade = new List<string>();

            #endregion

            #region Data Input
            Console.WriteLine("GFT - Trade Categorization");
            Console.WriteLine("==============================================================================");
            Console.Write("Reference Date [mm/DD/yyyy]: ");
            ReferenceDate = Convert.ToDateTime(Console.ReadLine());
            Console.Write("Number os Trades: ");
            NumberOfTrades = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("==============================================================================");
            for (int t = 1; t <= NumberOfTrades; t++)
            {
                Console.Write("Trade " + t.ToString() + ": ");
                Trade.Add(Console.ReadLine());
            }
            #endregion
            Trade transaction = new Trade();
            transaction.CategorizeTrade(Trade, ReferenceDate);
        }
    }
}

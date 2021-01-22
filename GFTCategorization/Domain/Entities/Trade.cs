using GFTCategorization.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GFTCategorization.Domain.Entities
{
    public class Trade : iTrade
    {
        public double Value { get; set; }
        public string ClientSector { get; set; }
        public DateTime NextPaymentDate { get; set; }

        public string Risk { get; set; }

        public void CategorizeTrade(List<string> trades, DateTime referenceDate)
        {
            List<Trade> lTrade = new List<Trade>();

            Console.WriteLine("==============================================================================");
            foreach (var trade in trades)
            {
                Trade newTrade = new Trade
                {
                    Value = Convert.ToDouble(trade.Split(' ')[0]),
                    ClientSector = trade.Split(' ')[1],
                    NextPaymentDate = Convert.ToDateTime(trade.Split(' ')[2]),
                    Risk = (CategorizeTransaction(Convert.ToDouble(trade.Split(' ')[0]), 
                                                 trade.Split(' ')[1],
                                                 Convert.ToDateTime(trade.Split(' ')[2])))
                };
                Console.WriteLine(newTrade.Risk);
            }
            Console.WriteLine("==============================================================================");
            Console.ReadLine();
        }

        private string CategorizeTransaction(double value,
                                             string clientSector,
                                             DateTime nextPaymentDate
                                             )
        {
            if (DateTime.Now.Subtract(nextPaymentDate).Days > 30)
            {
               return "DEFAULTED";
            }
            else if (value > 1000000 && clientSector.ToUpper() == "PRIVATE")
            {
                return "HIGHRISK";
            }
            else if (value > 1000000 && clientSector.ToUpper() == "PUBLIC")
            {
                return "MEDIUMRISK";
            }
            else
            {
                return "NOT CATEGORIZED";
            }
        }
    }
}
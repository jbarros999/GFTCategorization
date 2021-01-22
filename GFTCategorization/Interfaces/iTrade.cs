using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GFTCategorization.Interfaces
{
    /// <summary>
    /// Interface Trade: Receive the trade´s informations
    /// <param>Value - Amount, in Dollars, for the transaction</param>
    /// <param>ClientSector - Client´s sector (Public or Private)</param>
    /// <param>NextPaymentDate - Indicates when the next payment from the client to the bank is expected</param>
    /// </summary>

    public interface iTrade
    {
        double Value { get; set; }
        string ClientSector { get; set; }
        DateTime NextPaymentDate { get; set; }
    }
}

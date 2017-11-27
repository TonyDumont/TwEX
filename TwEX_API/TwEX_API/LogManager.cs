using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwEX_API
{
    class LogManager
    {
        public static void AddDebugMessage(String source, String functionCall, String message)
        {
            DebugMessage debugMessage = new DebugMessage();
            debugMessage.TimeStamp = DateTime.Now;
            debugMessage.Source = source;
            debugMessage.FunctionCall = functionCall;
            debugMessage.Message = message;

            switch (source)
            {
                case "AdministrationClientManager":
                case "AdministrationMessageClient":

                    break;

                case "ExchangeManager":
                case "BittrexManager":
                case "BleuTradeManager":
                case "CCEXManager":
                case "CryptopiaManager":
                case "GateIOManager":
                case "GDAXManager":
                case "HitBTCManager":
                case "LiveCoinManager":
                case "PoloniexManager":
                case "YoBitManager":
                    //AdministrationMessageServerManager.administrationServerView.ProcessDebugMessage(debugMessage);
                    break;


                default:
                    // code
                    break;
            }
        }

        public class DebugMessage
        {
            public DateTime TimeStamp { get; set; }
            public string Source { get; set; }
            public string FunctionCall { get; set; }
            public string Message { get; set; }
        }
    }
}

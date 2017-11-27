using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwEX_API
{
    public class ExchangeManager
    {
        public static String GetNonce()
        {
            long ms = (long)((DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalSeconds);

            return ms.ToString();
        }
    }
}

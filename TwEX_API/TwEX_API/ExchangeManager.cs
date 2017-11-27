using System;

namespace TwEX_API
{
    public class ExchangeManager
    {
        // GETTERS
        public static String GetNonce()
        {
            long ms = (long)((DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalSeconds);
            return ms.ToString();
        }
    }
}

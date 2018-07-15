using Newtonsoft.Json.Linq;
using System;

namespace JotFormWebhookParser
{
    public class JotFormParser : IJotFormParser
    {
        public JObject Parse(JObject rawRequest)
        {
            if (rawRequest == null)
            {
                throw new ArgumentNullException(nameof(rawRequest));
            }

            throw new NotImplementedException();
        }
    }
}

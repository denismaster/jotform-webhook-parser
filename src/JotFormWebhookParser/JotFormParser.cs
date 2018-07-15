using Newtonsoft.Json.Linq;
using System;
using System.Linq;

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

            var tokens = rawRequest.Properties().Where(property => property.Name.StartsWith("q")).Select(token => token.Name).ToList();

            var result = new JObject();

            foreach (var (source, target) in tokens.Select(token => (source: token, target: token.Substring(token.IndexOf('_') + 1))))
            {
                result[target] = rawRequest[source];
            }

            return result;
        }
    }
}

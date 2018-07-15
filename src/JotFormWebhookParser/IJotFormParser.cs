using Newtonsoft.Json.Linq;

namespace JotFormWebhookParser
{
    /// <summary>
    /// Parser for rawRequest processing
    /// </summary>
    public interface IJotFormParser
    {
        /// <summary>
        /// Parse rawRequest into another json.
        /// </summary>
        /// <param name="rawRequest">JSON that coming in rawRequest field in incoming submission to webhook</param>
        /// <returns>Parsed json in other form</returns>
        JObject Parse(JObject rawRequest);
    }
}

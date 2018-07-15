using Newtonsoft.Json.Linq;
using System;
using System.Linq;
using Xunit;

namespace JotFormWebhookParser.Tests
{
    public class JotFormParserTests
    {
        [Fact]
        public void ShouldReturnNullWhenArgumentIsNull()
        {
            JObject submission = null;

            var parser = new JotFormParser();

            var result = parser.Parse(submission);

            Assert.Null(result);
        }
    }
}

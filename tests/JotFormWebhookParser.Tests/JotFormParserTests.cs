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

        [Fact]
        public void ShouldRemoveFirstPartOfPropertyName()
        {
            var submission = new JObject
            {
                { "q1_test", "foo" }
            };

            var parser = new JotFormParser();

            var result = parser.Parse(submission);

            Assert.NotNull(result);

            Assert.True(result.Properties().Count() == 1);
            Assert.Contains(result.Properties(), c => c.Name == "test");

            Assert.Equal("foo", result["test"]);
        }
    }
}

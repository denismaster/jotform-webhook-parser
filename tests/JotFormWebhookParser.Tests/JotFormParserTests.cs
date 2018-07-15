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

            Assert.Throws<ArgumentNullException>(() => parser.Parse(submission));
        }

        [Fact]
        public void ShouldRemovePrefixInEachPropertyAndCopyValues()
        {
            var submission = new JObject
            {
                { "q1_foo", "foo" },
                { "q1_bar", "bar" }
            };

            var parser = new JotFormParser();

            var result = parser.Parse(submission);

            Assert.NotNull(result);

            Assert.True(result.Properties().Count() == 2);
            Assert.Contains(result.Properties(), c => c.Name == "foo");
            Assert.Contains(result.Properties(), c => c.Name == "bar");

            Assert.Equal("foo", result["foo"]);
            Assert.Equal("bar", result["bar"]);
        }

        [Fact]
        public void ShouldCopyComplexValues()
        {
            var submission = new JObject
            {
                {
                    "q1_test",
                    new JObject
                    {
                        { "foo", "foo" },
                        { "bar", "bar" }
                    }
                },
            };

            var parser = new JotFormParser();

            var result = parser.Parse(submission);

            Assert.NotNull(result);

            Assert.True(result.Properties().Count() == 1);
            Assert.Contains(result.Properties(), c => c.Name == "test");

            Assert.True(result["test"] is JObject);

            Assert.Equal("foo", result["test"]["foo"]);
            Assert.Equal("bar", result["test"]["bar"]);
        }
    }
}

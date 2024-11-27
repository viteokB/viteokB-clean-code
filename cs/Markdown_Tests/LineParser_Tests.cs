using Markdown.TokenParser.ConcreteParser;

namespace MarkdownTests
{
    public class LineParserTests
    {
        private LineParser tokenizer = new LineParser();

        [Test]
        public void ParseLine_ThrowArgumentNullException_WhenArgumentIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => tokenizer.ParseLine(null), "String argument text must be not null");
        }
    }
}

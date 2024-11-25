using Markdown.TokenizerClasses;
using Markdown;
using Markdown.MarkdownRenders.ConcreteMarkdownRenders;
using Markdown.Parsers.ConcreteMarkdownParsers;
using Markdown.TokenizerClasses.ConcreteTokenizers;


namespace Markdown_Tests
{
    public class MarkdownRenderHtmlTests
    {
        private Md markdown = new Md(new MarkdownParser(), new Tokenizer(), new HtmlRender());

        [SetUp]
        public void Setup()
        {
            
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
    }
}
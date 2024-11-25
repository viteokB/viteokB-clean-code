using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Markdown.MarkdownRenders;
using Markdown.Parsers;
using Markdown.TokenizerClasses;
using Markdown.TokenizerClasses.ConcreteTokenizers;

namespace Markdown
{
    public class Md
    {
        private readonly IMarkdownParser markdownParser;

        private readonly ITokenizer markdownTokenizer;

        private readonly IMarkdownRender render;

        public Md(IMarkdownParser parser, ITokenizer tokenizer, IMarkdownRender render)
        {
            markdownParser = parser;
            markdownTokenizer = tokenizer;
            this.render = render;
        }

        public string Render(string text)
        {
            var tokens = markdownTokenizer.Tokenize(text);
            var rootNode = markdownParser.Parse(tokens);

            return render.Render(rootNode);
        }
    }
}

using Markdown.Converter;
using Markdown.Extensions;
using Markdown.TokenParser.Interfaces;

namespace Markdown
{
    public class Md
    {
        private readonly ITokenLineParser markdownTokenizer;

        private readonly IConverter converter;

        public Md(ITokenLineParser tokenizer, IConverter converter)
        {
            markdownTokenizer = tokenizer;
            this.converter = converter;
        }

        public string Render(string mdString)
        {
            return converter.Convert(mdString.SplitIntoLines()
                .Select(markdownTokenizer.ParseLine)
                .ToArray());
        }
    }
}

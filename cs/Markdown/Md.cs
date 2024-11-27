using Markdown.Converter;
using Markdown.Extensions;
using Markdown.TokenParser;

namespace Markdown
{
    public class Md
    {
        private readonly ILineParser markdownTokenizer;

        private readonly IConverter converter;

        public Md(ILineParser tokenizer, IConverter converter)
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

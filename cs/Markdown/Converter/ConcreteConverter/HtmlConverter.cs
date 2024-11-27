using Markdown.Tags;

namespace Markdown.Converter.ConcreteConverter
{
    public class HtmlConverter : IConverter
    {
        private static readonly Dictionary<TagType, string> startTags = new()
        {
            { TagType.Bold, "<strong>" },
            { TagType.Italic, "<em>" },
            { TagType.Header, "<h1>" },
        };

        private static readonly Dictionary<TagType, string> closeTags = new()
        {
            { TagType.Bold, "</strong>" },
            { TagType.Italic, "</em>" },
            { TagType.Header, "</h1>" }
        };

        public string Convert(ParsedLine[] parsedLines)
        {
            throw new NotImplementedException();
        }
    }
}

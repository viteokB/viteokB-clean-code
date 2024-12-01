using Markdown.Tags;

namespace Markdown
{
    public class ParsedLine
    {
        public readonly string Line;

        public readonly List<ITag> Tags;

        public ParsedLine(string line, List<ITag> tags)
        {
            var sortedTags = tags.OrderBy(x => x.Position).ToList();

            if (sortedTags.Any(x => x.Position > line.Length))
                throw new ArgumentException("Позиция тега не может быть больше длины строки", nameof(sortedTags));

            this.Line = line;
            this.Tags = sortedTags;
        }
    }
}

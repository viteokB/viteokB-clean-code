namespace Markdown.Tags.ConcreteTags
{
    public class ItalicTag : ITag
    {
        public TagType TagType => TagType.Italic;

        public int Position { get; set; }

        public bool IsCloseTag { get; set; }

        public string OpenTag => "<em>";

        public string CloseTag => "</em>";

        public ItalicTag(int position, bool isCloseTag = false)
        {
            Position = position;
            IsCloseTag = isCloseTag;
        }
    }
}

namespace Markdown.Tags.ConcreteTags
{
    public class ItalicTag : ITag
    {
        public TagType TagType => TagType.Italic;

        public int Position { get; set; }

        public bool IsCloseTag { get; set; }

        public bool IsAutoClosing => false;

        public string OpenTag => "<em>";

        public string CloseTag => "</em>";

        public ItalicTag(int position, bool isCloseTag)
        {
            Position = position;
            IsCloseTag = isCloseTag;
        }
    }
}

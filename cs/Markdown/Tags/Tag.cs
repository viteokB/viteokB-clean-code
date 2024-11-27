namespace Markdown.Tags
{
    public abstract class Tag
    {
        public TagType TagType { get; }
        public int Position { get; }
        public bool IsCloseTag { get; }

        public Tag(TagType tagType, int position, bool isCloseTag)
        {
            TagType = tagType;
            Position = position;
            IsCloseTag = isCloseTag;
        }
    }
}

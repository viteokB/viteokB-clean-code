namespace Markdown.Tags.ConcreteTags
{
    public class BoldTag : ITag
    {
        public TagType TagType => TagType.Bold;

        public int Position { get; set; }

        public bool IsCloseTag { get; set; }

        public string OpenTag => "<strong>";

        public string CloseTag => "</strong>";

        public BoldTag(int position, bool isCloseTag = false)
        {
            Position = position;
            IsCloseTag = isCloseTag;
        }
    }
}

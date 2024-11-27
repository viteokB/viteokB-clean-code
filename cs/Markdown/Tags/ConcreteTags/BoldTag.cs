namespace Markdown.Tags.ConcreteTags
{
    public class BoldTag : Tag
    {
        public BoldTag(int position, bool isCloseTag) : base(TagType.Bold, position, isCloseTag)
        {
        }
    }
}

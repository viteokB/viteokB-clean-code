namespace Markdown.Tags.ConcreteTags
{
    public class HeaderTag : Tag
    {
        public HeaderTag(int position, bool isCloseTag) : base(TagType.Header, position, isCloseTag)
        {
        }
    }
}

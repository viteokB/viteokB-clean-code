namespace Markdown.Tags.ConcreteTags
{
    public class ItalicTag : Tag
    {
        public ItalicTag(int position, bool isCloseTag) : base(TagType.Italic, position, isCloseTag)
        {
        }
    }
}

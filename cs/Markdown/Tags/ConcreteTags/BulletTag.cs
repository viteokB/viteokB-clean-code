namespace Markdown.Tags.ConcreteTags;

public class BulletTag : ITag
{
    public TagType TagType { get; }
    public int Position { get; set; }
    public bool IsCloseTag { get; set; }

    public string OpenTag => "<li>";

    public string CloseTag => "</li>";

    public BulletTag(int position, bool isCloseTag = false)
    {
        Position = position;
        IsCloseTag = isCloseTag;
    }
}
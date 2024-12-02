﻿namespace Markdown.Tags.ConcreteTags
{
    public class HeaderTag : ITag
    {
        public TagType TagType => TagType.Header;

        public int Position { get; set; }

        public bool IsCloseTag { get; set; }

        public bool IsAutoClosing => true;

        public string OpenTag => "<h1>";

        public string CloseTag => "</h1>";

        public HeaderTag(int position, bool isCloseTag)
        {
            Position = position;
            IsCloseTag = isCloseTag;
        }
    }
}

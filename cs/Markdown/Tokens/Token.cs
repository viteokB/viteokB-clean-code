using Markdown.Tags;

namespace Markdown.Tokens
{
    public class Token
    {
        public TokenType TokenType { get; set; }
        public string Content { get; set; }
        public TagType TagType { get; set; }
        public bool IsCloseTag { get; set; }
        public int Position { get; set; }

        public Token(TokenType tokenType, string content, int position, bool isCloseTag = false, TagType tagType = TagType.UnDefined)
        {
            TokenType = tokenType;
            Content = content;
            Position = position;
            IsCloseTag = isCloseTag;
            TagType = tagType;
        }
    }
}

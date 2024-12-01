using Markdown.Tags;

namespace Markdown.Tokens
{
    public class Token
    {
        public TokenType TokenType;

        public readonly string Content;

        public readonly TagType TagType;

        public bool IsCloseTag;

        public bool IsSelfCosingTag;

        public int PairTagPosition;

        public Token(TokenType tokenType, string content, TagType tagType = TagType.UnDefined, bool isSelfClosing = false)
        {
            TokenType = tokenType;
            Content = content;
            TagType = tagType;

            IsSelfCosingTag = isSelfClosing;
        }
    }
}

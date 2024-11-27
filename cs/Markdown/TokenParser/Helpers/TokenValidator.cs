using Markdown.Tags;
using Markdown.Tokens;

namespace Markdown.TokenParser.Helpers
{
    internal class TokenValidator
    {
        public static bool IsTokenTagOpen(TagType tagType, List<Token> tokens, int index)
        {
            throw new NotImplementedException();
        }

        public static bool IsValidTagToken(List<Token> tokens, int index)
        {
            throw new NotImplementedException();
        }

        public static bool OrderIsCorrect(Stack<Token> openedTokens, Token token)
        {
            throw new NotImplementedException();
        }
    }
}

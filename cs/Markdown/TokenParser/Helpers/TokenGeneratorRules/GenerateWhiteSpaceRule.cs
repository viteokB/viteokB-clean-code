using Markdown.Tags;
using Markdown.Tokens;

namespace Markdown.TokenParser.Helpers.TokenGeneratorRules
{
    public class GenerateWhiteSpaceRule : ITokenGenerateRule
    {
        public Token? GetToken(string line, int currentIndex)
        {
            if (line[currentIndex] == ' ')
                return new Token(TokenType.WhiteSpace, " ", TagType.UnDefined);

            return null;
        }
    }
}

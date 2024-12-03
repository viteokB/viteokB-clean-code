using Markdown.Tags;
using Markdown.Tokens;

namespace Markdown.TokenParser.Helpers.TokenGeneratorRules
{
    public class GenerateEscapeTokenRule : ITokenGenerateRule
    {
        public Token? GetToken(string line, int currentIndex)
        {
            if (line[currentIndex] == '\\')
                return new Token(TokenType.Escape, @"\", TagType.Escape);

            return null;
        }
    }
}

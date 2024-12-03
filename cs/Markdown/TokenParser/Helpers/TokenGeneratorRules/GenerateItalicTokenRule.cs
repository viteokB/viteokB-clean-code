using Markdown.Extensions;
using Markdown.Tags;
using Markdown.Tokens;

namespace Markdown.TokenParser.Helpers.TokenGeneratorRules
{
    public class GenerateItalicTokenRule : ITokenGenerateRule
    {
        public Token? GetToken(string line, int currentIndex)
        {
            if (line[currentIndex] == '_' && !line.NextCharIs('_', currentIndex))
                return new Token(TokenType.MdTag, "_", TagType.Italic);

            return null;
        }
    }
}

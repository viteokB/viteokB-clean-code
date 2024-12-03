using Markdown.Tags;
using Markdown.Tokens;

namespace Markdown.TokenParser.Helpers.TokenGeneratorRules;

public class GenerateBulletTokenRule : ITokenGenerateRule
{
    public Token? GetToken(string line, int currentIndex)
    {
        if (currentIndex + 1 < line.Length && line[currentIndex] == '*' && line[currentIndex + 1] == ' ')
            return new Token(TokenType.MdTag, "* ", TagType.BulletedList, true);

        return null;
    }
}
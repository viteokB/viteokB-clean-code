using Markdown.Tokens;

namespace Markdown.TokenParser.Helpers
{
    public interface ITokenGenerateRule
    {
        public Token? GetToken(string line, int currentIndex);
    }
}

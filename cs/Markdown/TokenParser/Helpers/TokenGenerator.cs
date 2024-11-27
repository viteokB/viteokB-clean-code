using Markdown.Tokens;

namespace Markdown.TokenParser.Helpers
{
    public class TokenGenerator
    {
        public static Token GetTokenBySymbol(string line, int currentIndex) =>
            line[currentIndex] switch
            {
                '#' => GetHashToken(line, currentIndex),
                '\\' => GetEscapeToken(),
                '_' => GetUnderscoreToken(line, currentIndex),
                ' ' => GetSpaceToken(),
                _ => GetTextToken(line, currentIndex)
            };

        private static Token GetHashToken(string line, int currentIndex) =>
            throw new NotImplementedException();

        private static Token GetSpaceToken() =>
            throw new NotImplementedException();

        private static Token GetTextToken(string line, int currentIndex)
        {
            throw new NotImplementedException();
        }

        private static Token GetUnderscoreToken(string line, int currentPosition) =>
            throw new NotImplementedException();

        private static Token GetEscapeToken() =>
            throw new NotImplementedException();
    }
}

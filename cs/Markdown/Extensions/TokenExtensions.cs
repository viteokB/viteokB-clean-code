using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Markdown.Tokens;

namespace Markdown.Extensions
{
    public static class TokenExtensions
    {
        public static bool NextTokenIs(this List<Token> tokens, TokenType tokenType,  int currentIndex)
        {
            return currentIndex + 1 < tokens.Count && tokens[currentIndex + 1].TokenType == tokenType;
        }

        public static bool LastTokenIs(this List<Token> tokens, TokenType tokenType, int currentIndex)
        {
            return currentIndex - 1 >= 0 && tokens[currentIndex - 1].TokenType == tokenType;
        }
    }
}

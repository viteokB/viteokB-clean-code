using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Markdown.Tags;

namespace Markdown.Tokens
{
    public class Token
    {
        public readonly TokenType TokenType;

        public readonly string Content;

        public Token(TokenType tokenType, string content)
        {
            TokenType = tokenType;

            Content = content;
        }
    }
}

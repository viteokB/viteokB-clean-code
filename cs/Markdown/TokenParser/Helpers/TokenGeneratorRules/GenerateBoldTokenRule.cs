using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Markdown.Tags;
using Markdown.Tokens;
using Markdown.Extensions;

namespace Markdown.TokenParser.Helpers.TokenGeneratorRules
{
    public class GenerateBoldTokenRule : ITokenGenerateRule
    {
        public Token? GetToken(string line, int currentIndex)
        {
            if (line[currentIndex] == '_' && line.NextCharIs('_', currentIndex))
                return new Token(TokenType.MdTag, "__", TagType.Bold);

            return null;
        }
    }
}

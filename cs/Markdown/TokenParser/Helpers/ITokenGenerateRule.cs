using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Markdown.Tokens;

namespace Markdown.TokenParser.Helpers
{
    public interface ITokenGenerateRule
    {
        public Token? GetToken(string line, int currentIndex);
    }
}

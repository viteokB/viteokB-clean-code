using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Markdown.Tokens;

namespace Markdown.TokenizerClasses
{
    public interface ITokenizer
    {
        public List<Token> Tokenize(string text);
    }
}

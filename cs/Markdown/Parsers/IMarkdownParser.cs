using Markdown.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Markdown.Parsers
{
    public interface IMarkdownParser
    {
        public AstNode Parse(List<Token> tokens);
    }
}

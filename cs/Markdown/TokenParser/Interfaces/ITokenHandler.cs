using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Markdown.Tags;
using Markdown.Tokens;

namespace Markdown.TokenParser.Interfaces
{
    public interface ITokenHandler
    {
        List<Token> HandleLine(List<Token> line);
    }
}

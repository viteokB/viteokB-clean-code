using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Markdown.Tokens
{
    public enum TokenType
    {
        WhiteSpace,
        BreakLine,
        Escape,
        Em_start,
        Em_end,
        Bold_start,
        Bold_end,
        Hash,
        Text,
        Number
    }
}

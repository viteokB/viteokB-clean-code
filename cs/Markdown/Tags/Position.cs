using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Markdown.Tags
{
    public struct Position(int LineNumber, int InLinePosititon)
    {
        public int LineNumber;

        public int InLinePosititon;
    }
}

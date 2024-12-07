using Markdown.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Markdown.TokenGeneratorClasses.Interfaces
{
    public interface ITokenGenerator
    {
        public static abstract Token? GetToken(string line, int currentIndex);
    }
}

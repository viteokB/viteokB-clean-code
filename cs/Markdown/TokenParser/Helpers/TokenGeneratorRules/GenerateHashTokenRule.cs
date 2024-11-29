﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Markdown.Tags;
using Markdown.Tokens;

namespace Markdown.TokenParser.Helpers.TokenGeneratorRules
{
    public class GenerateHashTokenRule : ITokenGenerateRule
    {
        public Token? GetToken(string line, int currentIndex)
        {
            if (currentIndex + 1 < line.Length && line[currentIndex] == '#' && line[currentIndex + 1] == ' ')
                return new Token(TokenType.MdTag, "# ", TagType.Header);

            return null;
        }
    }
}
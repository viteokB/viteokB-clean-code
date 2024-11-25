using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Markdown.Tags;
using Markdown.Tags.ConcreteTags;
using Markdown.Tokens;

namespace Markdown.Parsers.ConcreteMarkdownParsers
{
    public class MarkdownParser : IMarkdownParser
    {

        public AstNode Parse(List<Token> tokens)
        {
            var root = new AstNode(null, new DocumentTag());

            //Некая логика

            return root;
        }
    }
}

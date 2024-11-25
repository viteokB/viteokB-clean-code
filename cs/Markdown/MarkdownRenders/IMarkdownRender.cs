using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Markdown.Parsers;

namespace Markdown.MarkdownRenders
{
    public interface IMarkdownRender
    {
        public string Render(AstNode root);
    }
}

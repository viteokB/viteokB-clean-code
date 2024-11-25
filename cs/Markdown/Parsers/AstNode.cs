using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Markdown.Tags;
using Markdown.Tokens;

namespace Markdown.Parsers
{
    public class AstNode
    {
        public readonly AstNode ParentToken;

        public readonly List<AstNode> ChildsTokens;

        public Tag Tag;

        public AstNode(AstNode parent, Tag tag)
        {
            ParentToken = parent;
            ParentToken.ChildsTokens.Add(this);

            Tag = tag;
        }

        public void AddChild(AstNode child)
        {
            ChildsTokens.Add(child);
        }
    }
}

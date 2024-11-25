using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Markdown.Tags.ConcreteTags
{
    public class TextTag : Tag
    {
        public TextTag(string content) : base(TagType.Text, content, true, 0)
        {
        }
    }
}

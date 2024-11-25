using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Markdown.Tags.ConcreteTags
{
    public class DocumentTag : Tag
    {
        public DocumentTag() : base(TagType.Document, String.Empty, true, 0)
        {
        }
    }
}

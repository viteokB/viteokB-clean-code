using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Markdown.Tags.ConcreteTags;

namespace Markdown.Tags
{
    public abstract class Tag
    {
        public bool IsCompleted { get; set; }

        public bool SelfCompeted { get; protected set; }

        public TagType TagType { get; protected set; }

        public readonly string Content;

        public readonly int level;

        public Tag(TagType tagType, string content, bool selfCompleted, int level = 0)
        {
            TagType = tagType;
            Content = content;
            this.level = level;
            Content = string.Empty;

            SelfCompeted = selfCompleted;
            IsCompleted = false;
        }

        public Tag CheckCompleted()
        {
            if (IsCompleted || SelfCompeted)
                return this;

            return new TextTag(this.Content);
        }
    }
}

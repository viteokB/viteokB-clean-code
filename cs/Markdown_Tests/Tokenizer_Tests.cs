using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Markdown.TokenizerClasses;
using Markdown.TokenizerClasses.ConcreteTokenizers;
using Markdown.Tokens;

namespace MarkdownTests
{
    public class TokenizerTests
    {
        private Tokenizer tokenizer = new Tokenizer();

        [Test]
        public void Tokenize_ThrowArgumentNullException_WhenArgumentIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => tokenizer.Tokenize(null), "String argument text must be not null");
        }
    }
}

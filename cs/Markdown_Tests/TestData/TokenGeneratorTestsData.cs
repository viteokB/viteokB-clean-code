using Markdown.Tags;
using Markdown.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarkdownTests.TestData
{
    public static class TokenGeneratorTestsData
    {
        public static IEnumerable<TestCaseData> TextOnlyLines()
        {
            yield return new TestCaseData("вася", new List<Token>()
            {
                new Token(TokenType.Text, "вася", TagType.UnDefined),
            });

            yield return new TestCaseData("петя1223d", new List<Token>()
            {
                new Token(TokenType.Text, "петя", TagType.UnDefined),
                new Token(TokenType.Number, "1223", TagType.UnDefined),
                new Token(TokenType.Text, "d", TagType.UnDefined),
            });

            yield return new TestCaseData("1234566", new List<Token>()
            {
                new Token(TokenType.Number, "1234566", TagType.UnDefined),
            });
        }

        public static IEnumerable<TestCaseData> WhiteSpacesOnlyLines()
        {
            yield return new TestCaseData(" ", new List<Token>()
            {
                new Token(TokenType.WhiteSpace, " ", TagType.UnDefined),
            });

            yield return new TestCaseData("  ", new List<Token>()
            {
                new Token(TokenType.WhiteSpace, " ", TagType.UnDefined),
                new Token(TokenType.WhiteSpace, " ", TagType.UnDefined),
            });

            yield return new TestCaseData("      ", new List<Token>()
            {
                new Token(TokenType.WhiteSpace, " ", TagType.UnDefined),
                new Token(TokenType.WhiteSpace, " ", TagType.UnDefined),
                new Token(TokenType.WhiteSpace, " ", TagType.UnDefined),
                new Token(TokenType.WhiteSpace, " ", TagType.UnDefined),
                new Token(TokenType.WhiteSpace, " ", TagType.UnDefined),
                new Token(TokenType.WhiteSpace, " ", TagType.UnDefined),
            });
        }

        public static IEnumerable<TestCaseData> LinesWithHeader()
        {
            yield return new TestCaseData("# Заголовок", new List<Token>()
            {
                new Token(TokenType.MdTag, "# ", TagType.Header, true),
                new Token(TokenType.Text, "Заголовок", TagType.UnDefined),
            });

            yield return new TestCaseData("# # # ", new List<Token>()
            {
                new Token(TokenType.MdTag, "# ", TagType.Header, true),
                new Token(TokenType.MdTag, "# ", TagType.Header, true),
                new Token(TokenType.MdTag, "# ", TagType.Header, true)
            });

            yield return new TestCaseData(@" # # ", new List<Token>()
            {
                new Token(TokenType.WhiteSpace, " ", TagType.UnDefined),
                new Token(TokenType.MdTag, "# ", TagType.Header, true),
                new Token(TokenType.MdTag, "# ", TagType.Header, true),
            });
        }

        public static IEnumerable<TestCaseData> LinesWithEscapes()
        {
            yield return new TestCaseData(@"\", new List<Token>()
            {
                new Token(TokenType.Escape, @"\", TagType.Escape),
            });

            yield return new TestCaseData(@"\\", new List<Token>()
            {
                new Token(TokenType.Escape, @"\", TagType.Escape),
                new Token(TokenType.Escape, @"\", TagType.Escape),
            });

            yield return new TestCaseData(@"\\\", new List<Token>()
            {
                new Token(TokenType.Escape, @"\", TagType.Escape),
                new Token(TokenType.Escape, @"\", TagType.Escape),
                new Token(TokenType.Escape, @"\", TagType.Escape),
            });
        }

        public static IEnumerable<TestCaseData> LinesWithUnderscores()
        {
            yield return new TestCaseData("_", new List<Token>()
            {
                new Token(TokenType.MdTag, "_", TagType.Italic),
            });

            yield return new TestCaseData("__", new List<Token>()
            {
                new Token(TokenType.MdTag, "__", TagType.Bold),
            });

            yield return new TestCaseData("___", new List<Token>()
            {
                new Token(TokenType.MdTag, "__", TagType.Bold),
                new Token(TokenType.MdTag, "_", TagType.Italic),
            });

            yield return new TestCaseData("____", new List<Token>()
            {
                new Token(TokenType.MdTag, "__", TagType.Bold),
                new Token(TokenType.MdTag, "__", TagType.Bold),
            });
        }

        public static IEnumerable<TestCaseData> LineWithMultiTokens()
        {
            yield return new TestCaseData("Bibo 234 _ # ", new List<Token>()
            {
                new Token(TokenType.Text, "Bibo", TagType.UnDefined),
                new Token(TokenType.WhiteSpace, " ", TagType.UnDefined),
                new Token(TokenType.Number, "234", TagType.UnDefined),
                new Token(TokenType.WhiteSpace, " ", TagType.UnDefined),
                new Token(TokenType.MdTag, "_", TagType.Italic),
                new Token(TokenType.WhiteSpace, " ", TagType.UnDefined),
                new Token(TokenType.MdTag, "# ", TagType.Header, true),
            });

            yield return new TestCaseData("__# _", new List<Token>()
            {
                new Token(TokenType.MdTag, "__", TagType.Bold),
                new Token(TokenType.MdTag, "# ", TagType.Header, true),
                new Token(TokenType.MdTag, "_", TagType.Italic),
            });

            yield return new TestCaseData("_2_3_", new List<Token>()
            {
                new Token(TokenType.MdTag, "_", TagType.Italic),
                new Token(TokenType.Number, "2", TagType.UnDefined),
                new Token(TokenType.MdTag, "_", TagType.Italic),
                new Token(TokenType.Number, "3", TagType.UnDefined),
                new Token(TokenType.MdTag, "_", TagType.Italic),
            });

            yield return new TestCaseData(@"\# word", new List<Token>()
            {
                new Token(TokenType.Escape, @"\", TagType.Escape),
                new Token(TokenType.MdTag, "# ", TagType.Header, true),
                new Token(TokenType.Text, "word", TagType.UnDefined),
            });
        }
    }
}

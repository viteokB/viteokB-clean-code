using Markdown.Tags;
using Markdown.Tags.ConcreteTags;

namespace MarkdownTests.TestData
{
    public static class LineParserData
    {
        public static IEnumerable<TestCaseData> WordsOnlyLines()
        {
            yield return new TestCaseData("word bubo bibo", "word bubo bibo", new List<ITag>());
            yield return new TestCaseData("Why1 word 23 bubo bibo", "Why1 word 23 bubo bibo", new List<ITag>());
        }

        public static IEnumerable<TestCaseData> LineWithHeader()
        {
            yield return new TestCaseData("# word bubo bibo", "word bubo bibo", new List<ITag>()
            {
                new HeaderTag(0, false),
            });
            yield return new TestCaseData("# Why1 word 23 bubo bibo", "Why1 word 23 bubo bibo", new List<ITag>()
            {
                new HeaderTag(0, false),
            });
        }

        public static IEnumerable<TestCaseData> LineWithItalic()
        {
            yield return new TestCaseData("_word bubo_ bibo", "word bubo bibo", new List<ITag>()
            {
                new ItalicTag(0, false),
                new ItalicTag(9, true),
            });
            yield return new TestCaseData("_wo_rd bubo bibo", "word bubo bibo", new List<ITag>()
            {
                new ItalicTag(0, false),
                new ItalicTag(2, true),
            });
            yield return new TestCaseData("_word __bubo_ bibo__", "_word __bubo_ bibo__", new List<ITag>());
            yield return new TestCaseData(@"\_word bubo_ bibo", "_word bubo_ bibo", new List<ITag>());
            yield return new TestCaseData(@"_word bubo\_ bibo", "_word bubo_ bibo", new List<ITag>());
            yield return new TestCaseData(@"\_word bubo\_ bibo", "_word bubo_ bibo", new List<ITag>());
            yield return new TestCaseData("Why_1_ word 23 bubo bibo", "Why_1_ word 23 bubo bibo", new List<ITag>());
        }

        public static IEnumerable<TestCaseData> LinesWithBulletedList()
        {
            yield return new TestCaseData("* один", "один", new List<ITag>()
            {
                new BulletTag(0, false),
            });
            yield return new TestCaseData(@"\* один", @"* один", new List<ITag>());
        }

        public static IEnumerable<TestCaseData> LineWithBold()
        {
            yield return new TestCaseData("__word bubo__ bibo", "word bubo bibo", new List<ITag>()
            {
                new BoldTag(0, false),
                new BoldTag(9, true),
            });
            yield return new TestCaseData("__wo__rd bubo bibo", "word bubo bibo", new List<ITag>()
            {
                new BoldTag(0, false),
                new BoldTag(2, true),
            });
            yield return new TestCaseData("_word __bubo_ bibo__", "_word __bubo_ bibo__", new List<ITag>());
            yield return new TestCaseData(@"\__word bubo__ bibo", "__word bubo__ bibo", new List<ITag>());
            yield return new TestCaseData(@"__word bubo\__ bibo", "__word bubo__ bibo", new List<ITag>());
            yield return new TestCaseData(@"\__word bubo\__ bibo", @"__word bubo__ bibo", new List<ITag>());
            yield return new TestCaseData("Why__1__ word 23 bubo bibo", "Why__1__ word 23 bubo bibo", new List<ITag>());
        }
    }
}

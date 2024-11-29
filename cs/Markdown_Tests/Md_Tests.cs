//using FluentAssertions;
//using Markdown;
//using Markdown.TokenParser.ConcreteParser;


//namespace Markdown_Tests
//{
//    public class MdTests
//    {
//        private Md markdown = new Md(new LineParser(), new HtmlConverter());

//        #region HeaderTests

//        [TestCase(@"# bibo", "<h1>bibo</h1>")]
//        [TestCase(@"# # bibo", "<h1># bibo</h1>")]
//        public void Md_ShouldCreateHeaderCorrectly_WhenHeaderNotEscaped(string input, string expected)
//        {
//            markdown.Render(input).Should().BeEquivalentTo(expected);
//        }

//        [TestCase(@"\# bibo", @"\# bibo")]
//        [TestCase(@"\# # bibo", @"\# # bibo")]
//        public void Md_ShouldNotCreateHeaderTag_WhenHeaderEscaped(string input, string expected)
//        {
//            markdown.Render(input).Should().BeEquivalentTo(expected);
//        }

//        [TestCase(@"\\# bibo", @"\# bibo")]
//        [TestCase(@"a # # bibo", @"a # # bibo")]
//        public void Md_ShouldNotCreateHeaderTag_WhenAreCharsBeforeHash(string input, string expected)
//        {
//            markdown.Render(input).Should().BeEquivalentTo(expected);
//        }

//        #endregion

//        #region ItalicTests

//        [TestCase(@"_bibo love bubu_", @"<em>bibo love bubu</em>")]
//        [TestCase(@"bibo _love_ bubu", @"bibo <em>love</em> bubu")]
//        public void Md_ShouldCreateItalicTag_WhenTagAfterWhiteSpace(string input, string expected)
//        {
//            markdown.Render(input).Should().BeEquivalentTo(expected);
//        }

//        [TestCase(@"_ bibo love bubu_", @"_ bibo love bubu_")]
//        [TestCase(@"bibo _love _ bubu", @"bibo _love _ bubu")]
//        [TestCase(@"bibo _ love _ bubu", @"bibo _ love _ bubu")]
//        public void Md_ShouldNotCreateItalicTag_WhenWhiteSpaceBeforeOrAfterText(string input, string expected)
//        {
//            markdown.Render(input).Should().BeEquivalentTo(expected);
//        }

//        [TestCase(@"bibo _lo_ve bubu", @"bibo <em>lo</em>ve bubu")]
//        [TestCase(@"bibo l_ove_ bubu", @"bibo l<em>ove</em> bubu")]
//        public void Md_ShouldCreateItalicTag_WhenTagInsideTextWithoutDigits(string input, string expected)
//        {
//            markdown.Render(input).Should().BeEquivalentTo(expected);
//        }

//        [TestCase(@"bibo \_love_ bubu", @"bibo _love_ bubu")]
//        [TestCase(@"bibo _love\_ bubu", @"bibo _love_ bubu")]
//        [TestCase(@"bibo \_love\_ bubu", @"bibo _love_ bubu")]
//        public void Md_ShouldNotCreateItalicTag_WhenTagEscaped(string input, string expected)
//        {
//            markdown.Render(input).Should().BeEquivalentTo(expected);
//        }

//        [Test]
//        public void Md_ShoudNotCreateItalicAndBoldTags_WhenBoldTagsInsideItalic()
//        {
//            var input = "I _want to __sleep__ tonight_";
//            var expected = "I <em>want to __sleep__ tonight</em>";

//            markdown.Render(input).Should().BeEquivalentTo(expected);
//        }

//        [TestCase(@"текста c цифрами_12_3 не", @"текста c цифрами_12_3 не")]
//        [TestCase(@"bibo love_4_ bubu", @"bibo love_4_ bubu")]
//        public void Md_ShouldNotCreateItalicTag_WhenTextInsideHaveDigits(string input, string expected)
//        {
//            markdown.Render(input).Should().BeEquivalentTo(expected);
//        }

//        #endregion

//        #region BoldTests

//        [TestCase(@"__bibo love bubu__", @"<strong>bibo love bubu</strong>")]
//        [TestCase(@"bibo __love__ bubu", @"bibo <strong>love</strong> bubu")]
//        public void Md_ShouldCreateBoldTag_WhenTagAfterSpace(string input, string expected)
//        {
//            markdown.Render(input).Should().BeEquivalentTo(expected);
//        }

//        [TestCase(@"__ bibo love bubu__", @"__ bibo love bubu__")]
//        [TestCase(@"bibo __love __ bubu", @"bibo __love __ bubu")]
//        [TestCase(@"bibo __ love __ bubu", @"bibo __ love __ bubu")]
//        public void Md_ShouldNotCreateBoldTag_WhenWhiteSpaceBeforeOrAfterText(string input, string expected)
//        {
//            markdown.Render(input).Should().BeEquivalentTo(expected);
//        }

//        [TestCase(@"bibo \__love__ bubu", @"bibo __love__ bubu")]
//        [TestCase(@"bibo __love\__ bubu", @"bibo __love__ bubu")]
//        [TestCase(@"bibo \__love\__ bubu", @"bibo __love__ bubu")]
//        public void Md_ShouldNotCreateBoldTag_WhenTagEscaped(string input, string expected)
//        {
//            markdown.Render(input).Should().BeEquivalentTo(expected);
//        }

//        [Test]
//        public void Md_ShoudCreateItalicAndBoldTags_WhenItalicTagsInsideBold()
//        {
//            var input = "I __want to _sleep_ tonight__";
//            var expected = "I <strong>want to <em>sleep</em> tonight</strong>";

//            markdown.Render(input).Should().BeEquivalentTo(expected);
//        }

//        [TestCase(@"текста c цифрами__12__3 не", @"текста c цифрами__12__3 не")]
//        [TestCase(@"bibo love__4__ bubu", @"bibo love__4__ bubu")]
//        public void Md_ShouldNotCreateBoldTag_WhenTextInsideHaveDigits(string input, string expected)
//        {
//            markdown.Render(input).Should().BeEquivalentTo(expected);
//        }

//        #endregion

//        #region IntersectionTest

//        [TestCase(@"__bibo _love__ bubu_", @"__bibo _love__ bubu_")]
//        [TestCase(@"_bibo __love_ bubu__", @"_bibo __love_ bubu__")]
//        public void Md_ShouldProccessIntersectsCorrecttly(string input, string expected)
//        {
//            markdown.Render(input).Should().BeEquivalentTo(expected);
//        }

//        #endregion

//        [TestCase(@"____", @"____")]
//        [TestCase(@"__", @"__")]
//        public void Md_CanCreateEmptyItalicOrBoldTag(string input, string expected)
//        {
//            markdown.Render(input).Should().BeEquivalentTo(expected);
//        }

//        public void Md_ShouldCreateEmptyHtml_WhenTextIsStringEmpty(string input, string expected)
//        {
//            markdown.Render(String.Empty).Should().BeEquivalentTo(String.Empty);
//        }
//    }
//}
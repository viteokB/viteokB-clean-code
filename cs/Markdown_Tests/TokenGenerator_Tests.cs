﻿using FluentAssertions;
using Markdown.Tags;
using Markdown.TokenParser.Helpers;
using Markdown.Tokens;
using MarkdownTests.TestData;

namespace MarkdownTests
{
    public class TokenGenerator_Tests
    {
        [TestCaseSource(typeof(TokenGeneratorTestsData), nameof(TokenGeneratorTestsData.TextOnlyLines))]
        public void TokenGenerator_GetTokenBySymbolCorrectly_WhenTextOnly(string input, List<Token> expectedTokens)
        {
            var actuallyTokens = GetAllTokensFromLine(input);

            actuallyTokens.Should().BeEquivalentTo(expectedTokens);
        }

        [TestCaseSource(typeof(TokenGeneratorTestsData), nameof(TokenGeneratorTestsData.WhiteSpacesOnlyLines))]
        public void TokenGenerator_GetTokensBySymbolCorrectly_WhenWhiteSpacesOnly(string input, List<Token> expectedTokens)
        {
            var actuallyTokens = GetAllTokensFromLine(input);

            actuallyTokens.Should().BeEquivalentTo(expectedTokens);
        }

        [Test]
        public void TokenGenerator_GetTokensBySymbolCorrectly_WhenHeaderTokenOnly()
        {
            var actuallyTokens = GetAllTokensFromLine("# ");

            actuallyTokens.Should().BeEquivalentTo(new List<Token>()
            {
                new Token(TokenType.MdTag, "# ", TagType.Header, true)
            });
        }

        [TestCaseSource(typeof(TokenGeneratorTestsData), nameof(TokenGeneratorTestsData.LinesWithHeader))]
        public void TokenGenerator_GetTokensBySymbolCorrectly_WhenLineWithHeaders(string input, List<Token> expectedTokens)
        {
            var actuallyTokens = GetAllTokensFromLine(input);

            actuallyTokens.Should().BeEquivalentTo(expectedTokens);
        }

        [TestCaseSource(typeof(TokenGeneratorTestsData), nameof(TokenGeneratorTestsData.LinesWithBulletedList))]
        public void TokenGenerator_GetTokensBySymbolCorrectly_WhenLineWithBulletedLis(string input, List<Token> expectedTokens)
        {
            var actuallyTokens = GetAllTokensFromLine(input);

            actuallyTokens.Should().BeEquivalentTo(expectedTokens);
        }

        [TestCaseSource(typeof(TokenGeneratorTestsData), nameof(TokenGeneratorTestsData.LinesWithEscapes))]
        public void TokenGenerator_GetTokensBySymbolCorrectly_WhenLineWithEscapes(string input, List<Token> expectedTokens)
        {
            var actuallyTokens = GetAllTokensFromLine(input);

            actuallyTokens.Should().BeEquivalentTo(expectedTokens);
        }

        [TestCaseSource(typeof(TokenGeneratorTestsData), nameof(TokenGeneratorTestsData.LinesWithUnderscores))]
        public void TokenGenerator_GetTokensBySymbolCorrectly_WhenLineWithUnderscores(string input, List<Token> expectedTokens)
        {
            var actuallyTokens = GetAllTokensFromLine(input);

            actuallyTokens.Should().BeEquivalentTo(expectedTokens);
        }

        [TestCaseSource(typeof(TokenGeneratorTestsData), nameof(TokenGeneratorTestsData.LineWithMultiTokens))]
        public void TokenGenerator_GetTokensBySymbolCorrectly_WhenLineWithMultiTokens(string input, List<Token> expectedTokens)
        {
            var actuallyTokens = GetAllTokensFromLine(input);

            actuallyTokens.Should().BeEquivalentTo(expectedTokens);
        }


        private static List<Token?> GetAllTokensFromLine(string line)
        {
            int i = 0;
            var result = new List<Token?>();

            while (i < line.Length)
            {
                var token = TokenGenerator.GetTokenBySymbol(line, i);
                result.Add(token);
                i += token.Content.Length;
            }

            return result;
        }
    }
}

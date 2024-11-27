using Markdown.Tags;
using Markdown.Tokens;

namespace Markdown.TokenParser.ConcreteParser
{
    public class LineParser : ILineParser
    {
        public ParsedLine ParseLine(string line)
        {
            throw new NotImplementedException();
        }

        private List<Token> GetTokens(string line)
        {
            throw new NotImplementedException();
        }

        private Tag GetNewTag(Token token, int position)
        {
            throw new NotImplementedException();
        }

        private List<Token> EscapeTags(List<Token> tokens)
        {
            throw new NotImplementedException();
        }

        private List<Token> EscapeInvalidTokens(List<Token> tokens) =>
            throw new NotImplementedException();

        private List<Token> EscapeNonPairTokens(List<Token> tokens)
        {
            throw new NotImplementedException();
        }

        private void SolveOpenAndCloseTags(Stack<int> openTags, List<Token> tokens, int openIndex,
            int closeIndex, List<Token> incorrectTags)
        {
            throw new NotImplementedException();
        }

        private List<Token> EscapeWrongOrder(List<Token> tokens)
        {
            throw new NotImplementedException();
        }

        private ParsedLine GetTagsAndCleanText(List<Token> tokens)
        {
            throw new NotImplementedException();
        }
    }
}

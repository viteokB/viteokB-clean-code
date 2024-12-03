using Markdown.Extensions;
using Markdown.Tags;
using Markdown.Tokens;

namespace Markdown.TokenParser.Helpers
{
    public class TokenValidator
    {
        public static bool IsTokenTagOpen(TagType tagType, List<Token> tokens, int index)
        {
            switch (tagType)
            {
                case TagType.Italic:
                    return IsBoldOrItalicOpen(tokens, index);
                case TagType.Bold:
                    return IsBoldOrItalicOpen(tokens, index);
                case TagType.Header:
                default:
                    return true;
            }
        }

        private static bool lastOpenWasInWord;
        
        public static bool IsTokenTagClosed(TagType tagType, List<Token> tokens, int index)
        {
            switch (tagType)
            {
                case TagType.Italic:
                    return IsBoldOrItalicClosed(tokens, index);
                case TagType.Bold:
                    return IsBoldOrItalicClosed(tokens, index);
                case TagType.Header:
                default:
                    return true;
            }
        }

        public static bool IsValidTagToken(List<Token> tokens, int index)
        {
            return tokens[index].TagType switch
            {
                TagType.Italic => IsValidItalic(tokens, index),
                TagType.Bold => IsValidBold(tokens, index),
                TagType.Header => IsValidHeader(tokens, index),
                _ => true
            };
        }

        public static bool OrderIsCorrect(Stack<Token> openedTokens, Token token)
        {
            return token.TagType != TagType.Bold || openedTokens.All(x => x.TagType != TagType.Italic);
        }

        private static bool IsValidHeader(List<Token> tokens, int index)
        {
            if (index == 0 && index + 1 < tokens.Count && tokens[index].TokenType == TokenType.MdTag)
                return true;

            return false;
        }

        private static bool IsValidItalic(List<Token> tokens, int index)
        {
            return IsValidUnderscoreTag(tokens, index);
        }

        private static bool IsValidBold(List<Token> tokens, int index)
        {
            return IsValidUnderscoreTag(tokens, index);
        }

        private static bool IsValidUnderscoreTag(List<Token> tokens, int index)
        {
            var isOpen = IsBoldOrItalicOpen(tokens, index);
            var isClosed = IsBoldOrItalicClosed(tokens, index);

            return (isOpen ^ isClosed);
        }

        #region IsBoldOrItalicOpen

        private static bool IsBoldOrItalicOpen(List<Token> tokens, int index)
        {
            var betweenWordsOpen = IsBoldOrItalicBetweenWordsOpen(tokens, index);

            var inOneWord = IsBoldOrItalicInOneWordOpen(tokens, index);

            return betweenWordsOpen ^ inOneWord;
        }

        //Является ли тег открывающим для ситуации когда тег применятеся к нескольким
        //применяется между словами:  '_вася'
        private static bool IsBoldOrItalicBetweenWordsOpen(List<Token> tokens, int index)
        {
            return tokens.NextTokenIs(TokenType.Text, index) &&
                   (index - 1 < 0 || tokens.LastTokenIs(TokenType.WhiteSpace, index)) ;
        }

        //Является ли тег открывающим для ситуации когда тег применятеся внутри
        //слова:  ' кр_овать' '_word_w_w_word_
        private static bool IsBoldOrItalicInOneWordOpen(List<Token> tokens, int index)
        {
            return tokens.NextTokenIs(TokenType.Text, index) &&
                   tokens.LastTokenIs(TokenType.Text, index) &&
                   !IsBoldOrItalicOpen(tokens, index - 2);
        }

        #endregion

        #region IsBoldOrdItalicClosed

        private static bool IsBoldOrItalicClosed(List<Token> tokens, int index)
        {
            var betweenWordsOpen = IsBoldOrItalicBetweenWordsClosed(tokens, index);

            var inOneWord = IsBoldOrItalicInOneWordClosed(tokens, index);

            return betweenWordsOpen ^ inOneWord;
        }

        private static bool IsBoldOrItalicBetweenWordsClosed(List<Token> tokens, int index)
        {
            return  (tokens.NextTokenIs(TokenType.WhiteSpace, index) || index + 1 >= tokens.Count) &&
                   tokens.LastTokenIs(TokenType.Text, index);
        }

        private static bool IsBoldOrItalicInOneWordClosed(List<Token> tokens, int index)
        {
            return tokens.NextTokenIs(TokenType.Text, index) &&
                   tokens.LastTokenIs(TokenType.Text, index) &&
                   IsBoldOrItalicOpen(tokens, index - 2);
        }

        #endregion
    }
}

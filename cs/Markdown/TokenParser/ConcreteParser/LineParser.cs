using Markdown.Tags;
using Markdown.Tags.ConcreteTags;
using Markdown.TokenParser.Helpers;
using Markdown.Tokens;
using System.Text;

namespace Markdown.TokenParser.ConcreteParser
{
    public class LineParser : ILineParser
    {
        public ParsedLine ParseLine(string line)
        {
            if (line == null)
                throw new ArgumentNullException("String argument text must be not null");

            var listTokens = GetTokens(line);
            listTokens = EscapeTags(listTokens);
            listTokens = EscapeInvalidTokens(listTokens);
            listTokens = EscapeNonPairTokens(listTokens);
            listTokens = EscapeWrongOrder(listTokens);
            var parseLine = GetTagsAndCleanText(listTokens);

            return parseLine;
        }

        private List<Token> GetTokens(string line)
        {
            int position = 0;
            var result = new List<Token?>();

            while (position < line.Length)
            {
                var token = TokenGenerator.GetTokenBySymbol(line, position);
                result.Add(token);
                position += token.Content.Length;
            }

            return result;
        }

        private List<Token> EscapeTags(List<Token> tokens)
        {
            Token? previousToken = null;
            var result = new List<Token>();

            foreach (var token in tokens)
            {
                if (previousToken is { TokenType: TokenType.Escape })
                {
                    if (token.TokenType is TokenType.MdTag or TokenType.Escape)
                    {
                        token.TokenType = TokenType.Text;
                        previousToken = token;
                        result.Add(token);
                    }
                    else
                    {
                        previousToken.TokenType = TokenType.Text;
                        result.Add(previousToken);
                        result.Add(token);
                        previousToken = token;
                    }
                }
                else if (token.TokenType == TokenType.Escape)
                    previousToken = token;
                else
                {
                    result.Add(token);
                    previousToken = token;
                }
            }

            if (previousToken is not { TokenType: TokenType.Escape })
                return result;

            previousToken.TokenType = TokenType.Text;
            result.Add(previousToken);
            return result;
        }

        private List<Token> EscapeInvalidTokens(List<Token> tokens) =>
            tokens.Select((t, index) =>
                    t.TokenType is not TokenType.MdTag || TokenValidator.IsValidTagToken(tokens, index)
                        ? t
                        : new Token(TokenType.Text, t.Content))
                .ToList();

        private List<Token> EscapeNonPairTokens(List<Token> tokens)
        {
            var resultTokens = new List<Token>();
            var openTagsPositions = new Stack<int>();
            var incorrectTags = new List<Token>();

            for (var index = 0; index < tokens.Count; index++)
            {
                var token = tokens[index];
                resultTokens.Add(token);

                // Пропускаем токены, которые не являются тегами
                if (token.TokenType != TokenType.MdTag) continue;

                // Проверяем, является ли текущий токен открывающим тегом
                if (TokenValidator.IsTokenTagOpen(token.TagType, tokens, index))
                {
                    openTagsPositions.Push(index);
                }
                else if(TokenValidator.IsTokenTagClosed(token.TagType, tokens, index))
                {
                    // Если это закрывающий тег
                    if (openTagsPositions.TryPop(out var lastOpenTokenIndex))
                    {
                        SolveOpenAndCloseTags(openTagsPositions, tokens, lastOpenTokenIndex, index, incorrectTags);
                    }
                    else
                    {
                        // Если не нашли соответствующий открывающий тег
                        incorrectTags.Add(token);
                    }
                }
                // else
                // {
                //     // Если не нашли соответствующий открывающий тег
                //     incorrectTags.Add(token);
                // }
            }

            // Добавляем оставшиеся открытые теги как некорректные
            while (openTagsPositions.Count > 0)
            {
                var token = tokens[openTagsPositions.Pop()];
                if(!token.IsSelfCosingTag)
                    incorrectTags.Add(token);
            }

            ChangeTypesForIncorrectTokens(incorrectTags);

            return resultTokens;
        }

        private void ChangeTypesForIncorrectTokens(List<Token> incorrectTags)
        {
            foreach (var token in incorrectTags)
            {
                token.TokenType = TokenType.Text; // Изменяем тип токена на текстовый
            }
        }

        private void SolveOpenAndCloseTags(Stack<int> openTags, List<Token> tokens, int openIndex,
           int closeIndex, List<Token> incorrectTags)
        {
            var openTagToken = tokens[openIndex];
            var closeTagToken = tokens[closeIndex];
            closeTagToken.IsCloseTag = true;

            // Проверяем, совпадают ли типы открывающего и закрывающего тегов
            if (openTagToken.TagType == closeTagToken.TagType)
            {
                tokens[openIndex].PairTagPosition = closeIndex;
                tokens[closeIndex].PairTagPosition = openIndex;
                return;
            }

            // Проверяем следующий тег после закрывающего
            if (TryGetNextTagType(tokens, closeIndex, out var nextTagTokenPosition))
            {
                if (openTags.TryPeek(out var preOpenTagIndex) && 
                    tokens[preOpenTagIndex].TagType == closeTagToken.TagType)
                {
                    HandleNestedTags(openTags, tokens, preOpenTagIndex, openIndex, closeIndex, nextTagTokenPosition, incorrectTags);
                    return;
                }

                // Если следующий тег не является открывающим
                if (!TokenValidator.IsTokenTagOpen(tokens[nextTagTokenPosition].TagType, tokens, nextTagTokenPosition))
                {
                    HandleIncorrectTag(openTags, tokens, openIndex, closeIndex, incorrectTags);
                    return;
                }
            }

            // Если не удалось найти соответствующий открывающий тег
            incorrectTags.Add(tokens[openIndex]);
            incorrectTags.Add(tokens[closeIndex]);
        }

        private void HandleNestedTags(Stack<int> openTags, List<Token> tokens, int preOpenTagIndex,
           int openIndex, int closeIndex, int nextTagTokenPosition, List<Token> incorrectTags)
        {
            // Обработка вложенных тегов
            if (tokens[nextTagTokenPosition].TagType == tokens[openIndex].TagType)
            {
                openTags.Push(openIndex);
                incorrectTags.Add(tokens[closeIndex]);
            }
            else
            {
                openTags.Pop();
                tokens[preOpenTagIndex].PairTagPosition = closeIndex;
                tokens[closeIndex].PairTagPosition = preOpenTagIndex;
                incorrectTags.Add(tokens[openIndex]);
            }
        }

        private void HandleIncorrectTag(Stack<int> openTags, List<Token> tokens,
           int openIndex, int closeIndex, List<Token> incorrectTags)
        {
            // Обработка некорректных тегов
            if (openTags.Count > 0)
            {
                var preOpenTagIndex = openTags.Pop();
                incorrectTags.Add(tokens[preOpenTagIndex]);
                incorrectTags.Add(tokens[openIndex]);
                incorrectTags.Add(tokens[closeIndex]);
            }
            else
            {
                incorrectTags.Add(tokens[openIndex]);
                incorrectTags.Add(tokens[closeIndex]);
            }
        }


        private bool TryGetNextTagType(List<Token> tokens, int index, out int nextTagToken)
        {
            for (var i = index + 1; i < tokens.Count; i++)
            {
                if (tokens[i].TokenType is not TokenType.MdTag) continue;
                nextTagToken = i;
                return true;
            }

            nextTagToken = -1;
            return false;
        }

        private List<Token> EscapeWrongOrder(List<Token> tokens)
        {
            var result = new List<Token>();
            var openTags = new Stack<Token>();
            foreach (var t in tokens)
            {
                result.Add(t);
                if (t.TokenType is TokenType.MdTag && !t.IsCloseTag)
                    openTags.Push(t);
                else if (t.TokenType is TokenType.MdTag)
                    openTags.Pop();
                if (!TokenValidator.OrderIsCorrect(openTags, t))
                {
                    t.TokenType = TokenType.Text;
                    tokens[t.PairTagPosition].TokenType = TokenType.Text;
                }
            }

            return result;
        }

        private ParsedLine GetTagsAndCleanText(List<Token> tokens)
        {
            var result = new List<ITag>();

            var line = new StringBuilder();
            foreach (var token in tokens)
            {
                if (token.TokenType is not TokenType.MdTag)
                {
                    line.Append(token.Content);
                    continue;
                }

                result.Add(GetNewTag(token, line.Length));
            }

            return new ParsedLine(line.ToString(), result);
        }

        private ITag GetNewTag(Token token, int position)
        {
            return token.TagType switch
            {
                TagType.Header => new HeaderTag(position, token.IsCloseTag),
                TagType.Italic => new ItalicTag(position, token.IsCloseTag),
                TagType.Bold => new BoldTag(position, token.IsCloseTag),
                _ => throw new NotImplementedException()
            };
        }
    }
}

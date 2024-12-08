using Markdown.Extensions;
using Markdown.Tags;
using Markdown.TokenParser.Interfaces;
using Markdown.Tokens;

namespace Markdown.TokenParser.TokenHandlers;

public class BoldTokensHandler : ITokenHandler
{
    public List<Token> HandleLine(List<Token> line)
    {
        var result = new List<Token>();
        var opened = new List<Token>(1);
        var position = 0;

        for (var j = 0; j < line.Count; j++)
        {
            if (opened.Count == 0 && IsOpen(j, line))
            {
                var token = line[j];
                opened.Add(new Token(TokenType.MdTag, "__",
                    position, false, TagType.Bold));
            }
            else if (opened.Count > 0 && IsClosed(j, line))
            {
                result.Add(opened[0]);
                result.Add(new Token(TokenType.MdTag, "__",
                    position, true, TagType.Bold));

                opened.Clear();
            }
            else if (line[j].TagType == TagType.Bold)
            {
                result.Add(new Token(TokenType.Text, "__", position));
            }

            position += line[j].Content.Length;
        }

        if (opened.Count > 0)
        {
            opened[0].TagType = TagType.UnDefined;
            opened[0].TokenType = TokenType.Text;

            result.Add(opened[0]);
        }

        return result;
    }

    private bool IsOpen(int index, List<Token> tokens)
    {
        var isFirstInLine = IsFirstInLine(index, tokens);
        var isOpenOrdinary = IsOpenOrdinary(index, tokens);
        var isOpenClosed = IsOpenClosed(index, tokens);

        return isFirstInLine ^ isOpenOrdinary ^ isOpenClosed;
    }

    private bool IsClosed(int index, List<Token> tokens)
    {
        var isLastInLine = IsLastInLine(index, tokens);
        var isClosedOrdinary = IsClosedOrdinary(index, tokens);
        var isOpenClosed = IsOpenClosed(index, tokens);

        return isLastInLine ^ isClosedOrdinary ^ isOpenClosed;
    }

    /// <summary>
    ///     Определяет является ли токен одновременно и
    ///     открывающим и закрывающим тегом - случай
    ///     если тэг в слове ("пре_сп_ко_йн_ый)
    /// </summary>
    /// <param name="index">Индекс токена</param>
    /// <param name="tokens">Список токенов для проверки</param>
    /// <returns>true если тег внутри слова иначе false</returns>
    private bool IsOpenClosed(int index, List<Token> tokens)
    {
        return tokens.LastTokenIs(TokenType.Text, index) &&
               tokens.CurrentTokenIs(TagType.Bold, index) &
               tokens.NextTokenIs(TokenType.Text, index);
    }

    #region OpenSituations

    private bool IsFirstInLine(int index, List<Token> tokens)
    {
        return index == 0 && tokens.CurrentTokenIs(TagType.Bold, index) &&
               (tokens.NextTokenIs(TokenType.Text, index) ||
                tokens.NextTokenIs(TokenType.MdTag, index));
    }

    private bool IsOpenOrdinary(int index, List<Token> tokens)
    {
        var hasWhSpaceBefore = tokens.LastTokenIs(TokenType.WhiteSpace, index);
        var hasMdTagBefore = tokens.LastTokenIs(TokenType.MdTag, index);

        return (hasWhSpaceBefore || hasMdTagBefore) &&
               tokens.CurrentTokenIs(TagType.Bold, index) &&
               tokens.NextTokenIs(TokenType.Text, index);
    }

    #endregion


    #region CloseSituations

    private bool IsLastInLine(int index, List<Token> tokens)
    {
        var isLast = index == tokens.Count() - 1;

        return isLast && tokens.CurrentTokenIs(TagType.Bold, index) &&
               (tokens.LastTokenIs(TokenType.Text, index) ||
                tokens.LastTokenIs(TokenType.MdTag, index));
    }

    private bool IsClosedOrdinary(int index, List<Token> tokens)
    {
        var hasTextAfter = tokens.NextTokenIs(TokenType.WhiteSpace, index);
        var hasMdTagAfter = tokens.NextTokenIs(TokenType.MdTag, index);

        return tokens.LastTokenIs(TokenType.Text, index) &&
               tokens.CurrentTokenIs(TagType.Bold, index) &&
               (hasMdTagAfter || hasTextAfter);
    }

    #endregion
}
namespace Markdown.TokenParser
{
    public interface ILineParser
    {
        public ParsedLine ParseLine(string line);
    }
}

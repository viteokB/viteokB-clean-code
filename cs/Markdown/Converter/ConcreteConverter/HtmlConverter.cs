using Markdown.Tags;
using System.Text;

namespace Markdown.Converter.ConcreteConverter
{
    public class HtmlConverter : IConverter
    {
        public string Convert(ParsedLine[] parsedLines)
        {
            var sb = new StringBuilder();

            foreach (var text in parsedLines)
            {
                var prevTagPos = 0;
                foreach (var tag in text.Tags)
                {
                    sb.Append(text.Line.AsSpan(prevTagPos, tag.Position - prevTagPos));

                    sb.Append(tag.IsCloseTag ?
                        tag.CloseTag : tag.OpenTag);

                    prevTagPos = tag.Position;
                }

                sb.Append(text.Line.AsSpan(prevTagPos, text.Line.Length - prevTagPos));
                if (text.Tags.Count > 0 && text.Tags[0].TagType == TagType.Header)
                    sb.Append(text.Tags[0].CloseTag);
            }

            return sb.ToString();
        }
    }
}

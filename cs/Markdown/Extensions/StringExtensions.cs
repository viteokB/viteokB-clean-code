namespace Markdown.Extensions
{
    public static class StringExtensions
    {
        public static string[] SplitIntoLines(this string text)
            => text.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);
    }
}

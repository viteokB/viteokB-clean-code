﻿using Markdown.Tags;

namespace Markdown;

public class ParsedLine
{
    public readonly string Line;

    public readonly List<ITag> Tags;

    public ParsedLine(string line, List<ITag> tags)
    {
        if (tags.Any(x => x.Position > line.Length))
            throw new ArgumentException("Позиция тега не может быть больше длины строки", nameof(tags));

        Line = line;
        Tags = tags;
    }
}
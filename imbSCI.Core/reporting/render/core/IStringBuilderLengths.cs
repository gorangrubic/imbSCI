namespace imbSCI.Core.reporting.render.core
{
    using System;

    public interface IStringBuilderLengths
    {
        String getLastLine(Boolean removeIt = false);
        long lastLength { get; }
        long Length { get; }

    }
}
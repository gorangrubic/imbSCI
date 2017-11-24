namespace imbSCI.Core.reporting.render.builders
{
    using System;

    [Flags]
    public enum logContentExceptionsFlags
    {
        ArgumentNullException = 0,
        ArgumentException = 1,
        InvalidOperationException = 2,
        FileNotFoundException = 4,
        IndexOutOfRangeException = 8,
        NullReferenceException = 16, 
        ArgumentOutOfRangeException = 32,
        ParserError = 64,
        StackOverflowException = 128,
        TypeAccessException = 256,
        PathTooLongException = 512,
        OverflowException = 1024,
        UnhandledException = 2028
    }
}
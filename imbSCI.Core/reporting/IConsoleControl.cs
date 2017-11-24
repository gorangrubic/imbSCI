namespace imbSCI.Core.reporting
{
    using System;

    public interface IConsoleControl
    {

        Boolean VAR_AllowAutoOutputToConsole { get; }

        Boolean VAR_AllowInstanceToOutputToConsole { get; set; }
    }

}
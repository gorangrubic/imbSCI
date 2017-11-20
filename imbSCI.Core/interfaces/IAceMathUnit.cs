namespace imbSCI.Core.interfaces
{
    using System;

    public interface IAceMathUnit
    {
        String format { get; }

        String ToString();

        Object getValue();
    }

}
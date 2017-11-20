namespace imbSCI.Data.interfaces
{
    using System;

    public interface IObjectWithRoot : IObjectWithParent
    {
        Object root { get; }
    }

}
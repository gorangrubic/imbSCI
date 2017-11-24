namespace imbSCI.Data.interfaces
{
    #region imbVeles using

    using System;

    #endregion

    /// <summary>
    /// Objekat ima svoj describe metod
    /// </summary>
    public interface IHasDescribeMethod
    {
        //String describe();

        String statusLine { get; }

        String label { get; }
        String describe(Int32 tabInsert);
    }
}
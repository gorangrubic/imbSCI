namespace imbSCI.Data.interfaces
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Manje zahtevni interfejs za rad sa tree strukturama
    /// </summary>
    /// <seealso cref="aceCommonTypes.core.interfaces.IObjectWithPath" />
    /// <seealso cref="aceCommonTypes.interfaces.IObjectWithName" />
    /// <seealso cref="System.Collections.Generic.IEnumerable{aceCommonTypes.interfaces.IObjectWithPathAndChildren}" />
    public interface IObjectWithPathAndChildren:IObjectWithPath, IObjectWithName, IEnumerable<IObjectWithPathAndChildren>
    {
        void Remove(String key);

        Int32 level { get; }
    }
}
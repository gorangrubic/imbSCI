namespace imbSCI.Data.interfaces
{
    /// <summary>
    /// Objects withL name, path and this[] selector
    /// </summary>
    /// <seealso cref="IObjectWithName" />
    /// <seealso cref="IObjectWithPath" />
    public interface IObjectWithPathAndChildSelector : IObjectWithChildSelector, IObjectWithPath, IObjectWithRoot
    {

    }

}
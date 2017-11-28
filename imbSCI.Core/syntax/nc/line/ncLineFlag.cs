namespace imbSCI.Core.syntax.nc.line
{
    public enum ncLineFlag
    {
        NOFLAG,
        EMPTYLINE,
        COMMENT,
        NOPARAMS,
        WITHPARAMS,
        /// <summary>
        /// ima samo jedan parametar i to je Label tipa
        /// </summary>
        WITHLABEL,
        UNRESOLVED,

    }
}
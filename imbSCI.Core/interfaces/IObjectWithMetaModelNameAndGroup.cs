namespace imbSCI.Core.interfaces
{
    public interface IObjectWithMetaModelNameAndGroup
    {
        string metaModelName { get; set; }

        string metaModelPrefix { get; set; }


        string metaModelFull { get; set; }
    }
}
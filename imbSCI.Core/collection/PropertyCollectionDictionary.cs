namespace imbSCI.Core.collection
{
    using System;
    using System.Data;

    /// <summary>
    /// PropertyCollection dataset by unique name (path)
    /// </summary>
    /// <seealso cref="aceCommonTypes.primitives.imbBindable" />
    public class PropertyCollectionDictionary : resourceDictionaryBase<PropertyCollection>
    {

        

        public PropertyCollection get(String path)
        {

            PropertyCollection output = this[path];

            return output;
        }

        /// <summary>
        /// Gets the default.
        /// </summary>
        /// <returns></returns>
        protected override PropertyCollection getDefault()
        {
            return new PropertyCollection();
        }
    }

}
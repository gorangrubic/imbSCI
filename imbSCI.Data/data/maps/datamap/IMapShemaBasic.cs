namespace imbSCI.Data.data.maps.datamap
{
    #region imbVeles using

    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using imbSCI.Data.data.maps.mapping;

    #endregion

    public interface IMapShemaBasic : IValuePairs
    {
        IEnumerable<string> mapNames { get; }
        IEnumerable<PropertyInfo> properties { get; }

        /// <summary>
        /// podaci o izvornom tipu
        /// </summary>
        Type mappedType { get; set; }



        PropertyInfo getProperty(String name);
        IImbMapItem getMapItem(String name);
        String getShemaLabel();

        /// <summary>
        /// Proverava da li propertz treba ubaciti u shemu 2014c
        /// </summary>
        /// <param name="pi"></param>
        /// <param name="sh"></param>
        /// <returns></returns>
        Boolean checkProperty(PropertyInfo pi);
    }
}
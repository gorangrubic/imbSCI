namespace imbSCI.Data.data.maps.mapping
{
    #region imbVeles using

    using System;
    using System.Reflection;
    using imbSCI.Data.interfaces;

    #endregion

    /// <summary>
    /// Zajednicke osobine razlicitih mapping itema
    /// </summary>
    public interface IImbMapItem : IObjectWithName
    {
        /// <summary>
        /// cela putanja - onako kako je prosledjeno prilikom definisanja
        /// </summary>
        String path { get; set; }

        /// <summary>
        /// ime propertija ili map itema, uvek je unikatno
        /// </summary>
        String name { get; set; }

        /// <summary>
        /// Podaci o propertiju koji se cilja ovom mapom
        /// </summary>
        PropertyInfo pi { get; set; }


        Boolean isActivated { get; }

        /// <summary>
        /// Dijagnosticki ispis naziva ovog mapiranog itema
        /// </summary>
        /// <returns></returns>
        String getMapItemLabel();
    }
}
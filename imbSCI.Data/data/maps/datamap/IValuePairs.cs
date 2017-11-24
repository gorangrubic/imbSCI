namespace imbSCI.Data.data.maps.datamap
{
    using imbSCI.Data.collection;
    #region imbVeles using

    using System;
    using System.Collections.Generic;
    using System.Data;

    #endregion

    public interface IValuePairs : IAceCollection, IDictionary<string, object>
    {
        /// <summary>
        /// Pristup key kolekciji
        /// </summary>
        IList<String> Keys { get; }

        Object this[Int32 index] { get; set; }

        /// <summary>
        /// Postavlja vrednosti u objekat
        /// </summary>
        /// <param name="target">Objekat u koji treba da se upisu vrednosti</param>
        /// <param name="values">Lista sa istim redosledom kao i u mapi</param>
        void setValues(Object target, Boolean valueConversion = true);

        /// <summary>
        /// Updataes data from the object. If fields defined does just update. If fields count is 0 - search all propertiesi in object
        /// </summary>
        /// <param name="target"></param>
        List<Object> getValues(Object target, Boolean reset = false);

        /// <summary>
        /// Vraca sve vrednosti parovima
        /// </summary>
        /// <returns></returns>
        List<Object> getValues();

        void Add(Object item);

        String getDataDescription(String format = "");

        ///bool ContainsKey(string name);
        /// 
        /// 
        /// <summary>
        /// Vraca pairs koji predstavljaju rezultat operacije nad skupom
        /// </summary>
        /// <remarks>
        /// Vraca vrednosti is second-a
        /// </remarks>
        /// <param name="second"></param>
        /// <param name="cst"></param>
        /// <returns></returns>
        IValuePairs getCrossSection(IValuePairs second, crossSectionType cst);

        /// <summary>
        /// Vraca vrednosti iz reda a koje se nalaze pod imenom u propertyValue paru - funkcija mapiranja ustvari
        /// </summary>
        /// <param name="row"></param>
        /// <param name="reset"></param>
        /// <returns></returns>
        List<Object> getValues(DataRow row, Boolean reset = false);

        bool ContainsKey(string columnName);
    }
}
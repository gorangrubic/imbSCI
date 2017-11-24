namespace imbSCI.Data.data.maps.datamap
{
    #region imbVeles using

    using System;
    using System.Collections;
    using System.Collections.Generic;
    using imbSCI.Data.data.maps.mapping;
    using System.Data;

    #endregion

    /// <summary>
    /// Univerzalni interfejs za sve mape
    /// </summary>
    public interface IMapShema : IMapShemaBasic
    {
        /// <summary>
        /// Da li je shema aktivirana - nakon ucitavanja
        /// </summary>
        Boolean isActivated { get; }

        /// <summary>
        /// lista imena propertija koji nisu pronadjeni u tipu kojim je aktivirana shema
        /// </summary>
        List<string> unmatchedProperties { get; set; }

        /// <summary>
        /// Glavni metod za dodavanje kolona
        /// </summary>
        /// <param name="input"></param>
        /// <param name="item"> </param>
        void addMapItem(IImbMapItem input);

        void copyMapItem(IImbMapItem input);

        /// <summary>
        /// Pravi kopiju kolone i ubacuje je
        /// </summary>
        /// <param name="input"></param>
        void addMapItemCopy(IImbMapItem input);

        void removeMapItem(IImbMapItem input);

        /// <summary>
        /// Postavlja vrednosti u objekat
        /// </summary>
        /// <param name="target">Objekat u koji treba da se upisu vrednosti</param>
        /// <param name="values">Lista sa istim redosledom kao i u mapi</param>
        void setValues(Object target, List<Object> values);

        /// <summary>
        /// Preuzima mapirane vrednosti iz objekta - po redosledu kakav je u mapi
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        List<Object> getValues(Object target);

        void AddMap(Object encProperty);

        /// <summary>
        /// Vrsi "aktiviranje" sheme - u evaluationMapItem-e prebacuje podatke o mapiranim propertijima i belezi nepronadjene
        /// </summary>
        /// <param name="mappedType">Tip za koji se pravi shema</param>
        /// <param name="__fields">Spisak polja koja treba da formira - ako je null onda pretpostavlja da vec postoje, ako nije null onda brise postojeca polja i definise nova </param>
        /// <returns>Broj nepronadjenih propertija u mapi</returns>
        Int32 activateShema(Type __mappedType, String[] __fields = null);

        /// Postavlja vrednosti u objekat
        /// </summary>
        /// <param name="target">Objekat u koji treba da se upisu vrednosti</param>
        /// <param name="values">Lista sa istim redosledom kao i u mapi</param>
        void setValues(Object target, IValuePairs values);

        TVP getValuePairs<TVP>(Object target) where TVP : class, IValuePairs, new();

        /// <summary>
        /// Preuzima vlednosti iz objekta i smesta ih u tipiziran niz, 
        /// </summary>
        /// <typeparam name="TV">Tip itema u nizu</typeparam>
        /// <param name="target">Objekat iz koga uzima vrednosti</param>
        /// <returns></returns>
        TV[] getValueArray<TV>(Object target);

        /// <summary>
        /// Creates value array for Evaluator input/output
        /// </summary>
        /// <typeparam name="TV">Property required</typeparam>
        /// <param name="source">Collection with parent item</param>
        /// <returns></returns>
        TV[][] getValueArrayCollection<TV>(IEnumerable source);

        /// <summary>
        /// Pravi propertyValuePair na osnovu niza vrednosti - redom mapira prema redosledu u mapi
        /// </summary>
        /// <typeparam name="TVP">tip propertyValuePair-a koji treba da se kreira</typeparam>
        /// <param name="values"></param>
        /// <returns></returns>
        TVP getValuePairs<TVP>(IList input) where TVP : class, IValuePairs, new();

        void setDataRow(DataRow row, Object source, Boolean valueConversion = true);

        /// <summary>
        /// Upisivanje podataka u DataRow
        /// </summary>
        /// <param name="row"></param>
        /// <param name="values"></param>
        /// <param name="valueConversion"></param>
        void setDataRow(DataRow row, IValuePairs values, Boolean valueConversion = true);

        DataTable makeDataTable(String __tableName = null);
        DataTable exportDataTable(IEnumerable __source, String __tableName, Boolean valueConversion = true);
    }
}
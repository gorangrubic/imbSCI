namespace imbSCI.Core.reporting.template
{
    #region imbVeles using

    using System;
    using System.Data;
    using System.Reflection;

    #endregion

    internal interface IApplyToContent
    {
        /// <summary>
        /// Rucno dodaje novi placeholder ili vraca postojeci ako vec postoji pod tim imenom
        /// </summary>
        /// <param name="fieldName"></param>
        /// <param name="_pi">Postavlja pi</param>
        /// <returns>vraca novi ili postojeci placeholder</returns>
        reportTemplatePlaceholder addPlaceholder(String fieldName = "", PropertyInfo _pi = null);

        /// <summary>
        /// Applies the property collection
        /// </summary>
        /// <param name="source"></param>
        /// <param name="mContent"></param>
        /// <param name="fieldPrefix"></param>
        /// <returns></returns>
        String applyToContent(PropertyCollection source, String mContent, Boolean autoRemove = false);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="source"></param>
        /// <param name="mContent"></param>
        /// <param name="fieldPrefix"></param>
        /// <param name="autoRemove"></param>
        /// <returns></returns>
        String applyToContent(Object source, String mContent, String fieldPrefix = "main_", Boolean autoRemove = false);

        /// <summary>
        /// Applies values from DataTable -- using shema and all rows.
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="mContent"></param>
        /// <param name="fieldPrefix">Prefix applied on placeholder key</param>
        /// <returns></returns>
        String applyToContent(DataTable dt, String mContent, Boolean autoRemove = false);

        /// <summary>
        /// removes all placeholder tags from the content
        /// </summary>
        /// <param name="mContent"></param>
        /// <returns></returns>
        String removeFromContent(String mContent);

        /// <summary>
        /// Ucitava string u kome se nalazi template -- dodaje pronadjene placeholdere u kolekciju
        /// </summary>
        /// <param name="formatString">String koji se obradjuje</param>
        /// <param name="makeReport">Da li da pravi izvestaj o importu</param>
        /// <returns>Broj novo dodatih placeholdera</returns>
        Int32 loadTemplateString(String formatString);
    }
}
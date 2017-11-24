namespace imbSCI.Core.reporting.template
{
    using imbSCI.Core.extensions.data;
    using imbSCI.Core.extensions.text;
    using imbSCI.Core.extensions.typeworks;
    using imbSCI.Data;
    #region imbVeles using

    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Reflection;
    using System.Text.RegularExpressions;

    #endregion

    /// <summary>
    /// Skup placeholdera za template
    /// </summary>
    /// <seealso cref="System.Collections.Generic.Dictionary{System.String, aceCommonTypes.reporting.template.reportTemplatePlaceholder}" />
    /// <seealso cref="aceCommonTypes.reporting.template.IApplyToContent" />
    public class reportTemplatePlaceholderCollection : Dictionary<string, reportTemplatePlaceholder>, IApplyToContent //propertyValuePairsBase<reportTemplatePlaceholder>
    {
        /// <summary>
        /// Pravi kolekciju i odmah primenjuje templateString
        /// </summary>
        /// <param name="templateStringToEvaluate"></param>
        public reportTemplatePlaceholderCollection(String templateStringToEvaluate)
        {
           // CollectionChanged += reportTemplatePlaceholderCollection_CollectionChanged;
            loadTemplateString(templateStringToEvaluate);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="reportTemplatePlaceholderCollection"/> class.
        /// </summary>
        public reportTemplatePlaceholderCollection()
            : base()
        {
           // CollectionChanged += reportTemplatePlaceholderCollection_CollectionChanged;
        }


        /// <summary>
        /// Rucno dodaje novi placeholder ili vraca postojeci ako vec postoji pod tim imenom
        /// </summary>
        /// <param name="fieldName"></param>
        /// <param name="_pi">Postavlja pi</param>
        /// <returns>vraca novi ili postojeci placeholder</returns>
        public reportTemplatePlaceholder addPlaceholder(String fieldName = "", PropertyInfo _pi = null)
        {
            if (ContainsKey(fieldName))
            {
                if (this[fieldName].pi == null && _pi != null)
                {
                    this[fieldName].pi = _pi;
                }
                return this[fieldName];
            }
            var tmp = new reportTemplatePlaceholder(Count, this, fieldName);
            tmp.pi = _pi;
            Add(fieldName, tmp);
            return tmp;
        }

        /// <summary>
        /// Applies the property collection
        /// </summary>
        /// <param name="source"></param>
        /// <param name="mContent"></param>
        /// <param name="fieldPrefix"></param>
        /// <returns></returns>
        public String applyToContent(PropertyCollection source, String mContent, Boolean autoRemove = false)
        {
            if (source == null) return mContent;

           
            
            foreach (Object key in source.Keys)
            {
                if (ContainsKey(key.toStringSafe()))
                {
                    String ndl = this[key.toStringSafe()].templateForm;
                    
                    mContent = mContent.Replace(ndl, source[key].toStringSafe(""));
                } else
                {
                    // key unknown
                }
            }

            if (autoRemove) mContent = removeFromContent(mContent);

            return mContent;

        }


        /// <summary>
        /// Reads properties from object and maps them to template
        /// </summary>
        /// <param name="source"></param>
        /// <param name="mContent"></param>
        /// <param name="fieldPrefix"></param>
        /// <param name="autoRemove"></param>
        /// <returns></returns>
        public String applyToContent(Object source, String mContent, String fieldPrefix = "main_", Boolean autoRemove = false)
        {
            if (source != null)
            {
                if (imbSciStringExtensions.isNullOrEmptyString(fieldPrefix))
                {
                    fieldPrefix = "";
                }
                else
                {
                    fieldPrefix = imbSciStringExtensions.ensureEndsWith(fieldPrefix, "_");
                }
                var pc = source.buildPropertyCollection<PropertyCollection>(false, true, fieldPrefix);
               // DataTable dt = source.buildDataTable("Source", true, false, true, fieldPrefix);
                return applyToContent((PropertyCollection) pc , mContent, autoRemove);
            }
            if (autoRemove) mContent = removeFromContent(mContent);
            return mContent;
            
        }

        /// <summary>
        /// Applies values from DataTable -- using shema and all rows.
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="mContent"></param>
        /// <param name="fieldPrefix">Prefix applied on placeholder key</param>
        /// <returns></returns>
        public String applyToContent(DataTable dt, String mContent, Boolean autoRemove = false)
        {
            if (dt == null) return mContent;

            foreach (DataRow dr in dt.Rows)
            {
                foreach (DataColumn dc in dt.Columns)
                {
                    if (ContainsKey(dc.ColumnName))
                    {
                        
                        String ndl = this[dc.ColumnName].templateForm;
                        String vl = dr[dc].toStringSafe(ndl);
                        if (vl != ndl)
                        {
                            mContent = mContent.Replace(ndl, vl);
                        }
                       
                    }
                }
            }

            if (autoRemove) mContent = removeFromContent(mContent);

            return mContent;
        }

        /// <summary>
        /// removes all placeholder tags from the content
        /// </summary>
        /// <param name="mContent"></param>
        /// <returns></returns>
        public String removeFromContent(String mContent)
        {
            foreach (KeyValuePair<string, reportTemplatePlaceholder> dr in this)
            {
                mContent = mContent.Replace(dr.Key, "");
            }

            return mContent;
        }


        /// <summary>
        /// Ucitava string u kome se nalazi template -- dodaje pronadjene placeholdere u kolekciju
        /// </summary>
        /// <param name="formatString">String koji se obradjuje</param>
        /// <param name="makeReport">Da li da pravi izvestaj o importu</param>
        /// <returns>Broj novo dodatih placeholdera</returns>
        public Int32 loadTemplateString(String formatString)
        {
            if (String.IsNullOrEmpty(formatString))
            {
                return 0;
            }
            Int32 c = this.Count;
            
            MatchCollection found = stringTemplateTools.regex_import.Matches(formatString);

            //if (_doMakeReportOnTemplate)
            //    logSystem.log("Found [" + found.Count + "] groups", logType.Execution);
            //formatString, logType.Execution);
            foreach (Match cp in found)
            {
                String _fieldName = cp.Groups[cp.Groups.Count - 1].Value;

                if (!ContainsKey(_fieldName))
                {
                    if (stringTemplateTools._useStringFormatAPI)
                    {
                        long __id = (long) cp.Value.imbToNumber(typeof (long));
                        Add(cp.Value, new reportTemplatePlaceholder(__id, this));
                    }
                    else
                    {
                        reportTemplatePlaceholder plc = new reportTemplatePlaceholder(Count, this, _fieldName);
                        Add(_fieldName, plc);
                       // if (_doMakeReportOnTemplate)
                           // logSystem.log("placeholder(" + plc.id + ") [" + plc.fieldName + "] found", logType.Execution);
                    }
                }
                else
                {
                    reportTemplatePlaceholder plc = this[_fieldName];
                   // if (_doMakeReportOnTemplate)
                        //logSystem.log(
                        //    "placeholder(" + plc.id + ") [" + plc.fieldName + "] found, but already registered",
                        //    logType.Execution);
                }
            }

            Int32 chg = Count - c;
            //if (_doMakeReportOnTemplate)
            //    logSystem.log("--- template processed :: placeholderCollection got (" + chg + ") new placeholders.",
            //                  logType.Execution);

            return Count - c;
        }

        /// <summary>
        /// kada se desi promena u kolekciji on obrise mapu da bi mogao ponovo da je pravi
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Collections.Specialized.NotifyCollectionChangedEventArgs"/> instance containing the event data.</param>
        private void reportTemplatePlaceholderCollection_CollectionChanged(object sender,
                                                                           System.Collections.Specialized.
                                                                               NotifyCollectionChangedEventArgs e)
        {
            //_map = null;
            //throw new NotImplementedException();
        }
    }
}
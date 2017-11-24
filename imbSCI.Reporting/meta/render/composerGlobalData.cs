using System;
using System.Linq;
using System.Collections.Generic;
namespace imbReportingCore.meta.render
{
    using System.Collections;
    using System.Data;
    using System.IO;
    using aceCommonTypes.diagnostic;
    using aceCommonTypes.extensions;
    using aceCommonTypes.primitives;
    using aceCommonTypes.data;
    using aceCommonTypes.core;
    using aceCommonTypes.collection;
    using aceCommonTypes.colors;
    using aceCommonTypes.reporting;
    using aceCommonTypes.reporting.render.fields;
    using aceCommonTypes.reporting.template;
    using imbReportingCore.interfaces;
    using imbReportingCore.reporting.core;



    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="System.Data.PropertyCollection" />
    public class composerGlobalData:PropertyCollection
    {


        


        public void setFromMetaContent(IMetaContent source)
        {
            source.buildPropertyCollection(false, true, "meta", this);

            if (source is IMetaContentNested)
            {
               


            }

           // this[templateFieldBasic.page_desc] = source.
        }

        public void setFromPathInfo(reportPathInfo pi)
        {
            
           
        }

        /// <summary>
        /// Should be recalled if execution prolongs
        /// </summary>
        /// <param name="log"></param>
        /// <param name="context"></param>
        public void setProperties(String log)
        {

        }

        /// <summary>
        /// Gets call once object initiated
        /// </summary>
        public void initialSet()
        {

            
        }

        public composerGlobalData()
        {
            initialSet();
        }

        /// <summary>
        /// Access by enum key
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public Object this[Enum key]
        {
            get
            {
                DictionaryEntry de = (DictionaryEntry) this[key.ToString()];
                return de.Value;
            }
            set
            {
                this[key.ToString()] = value;
            }
        }
    }

}
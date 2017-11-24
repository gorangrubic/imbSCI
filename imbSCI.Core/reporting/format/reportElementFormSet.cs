namespace imbSCI.Core.reporting.format
{
    using imbSCI.Core.extensions.data;
    using imbSCI.Data.data;
    using imbSCI.Data.enums.fields;
    using System;
    using System.Collections.Generic;

    // reportElement, reportOutputForm

    /// <summary>
    /// Default output settings for metaContent elementLevel
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <seealso cref="aceCommonTypes.primitives.imbBindable" />
    /// <seealso cref="elementLevelFormPreset" />
    public class reportElementFormSet:imbBindable
    {

        private Boolean _doTextShadowCopy = true;
        /// <summary>
        /// 
        /// </summary>
        public Boolean doTextShadowCopy
        {
            get { return _doTextShadowCopy; }
            set { _doTextShadowCopy = value; }
        }


        private Boolean _doEnableNamedDivsToData = true;
        /// <summary>
        /// It will keep record for each named content section defined by: <see cref="aceCommonTypes.enums.appendType.c_open"/>  and <see cref="aceCommonTypes.enums.appendType.c_close"/> calls 
        /// </summary>
        /// <remarks>
        /// To have this operational you must have <see cref="doTextShadowCopy"/> set to TRUE. 
        /// </remarks>
        public Boolean doEnableNamedDivsToData
        {
            get { return _doEnableNamedDivsToData; }
            set { _doEnableNamedDivsToData = value; }
        }



        private Boolean _doInMemoryOutputRepository = true;
        /// <summary>
        /// 
        /// </summary>
        public Boolean doInMemoryOutputRepository
        {
            get { return _doInMemoryOutputRepository; }
            set { _doInMemoryOutputRepository = value; }
        }



        private Boolean _doAutoUpdateStatusData = true;
        /// <summary>
        /// It will call autoupdate status data pn each scopeIn
        /// </summary>
        public Boolean doAutoUpdateStatusData
        {
            get { return _doAutoUpdateStatusData; }
            set { _doAutoUpdateStatusData = value; }
        }





        public reportElementFormSet(reportOutputForm __form, String __nametemplate = "{{{name}}}")
        {
            form = __form;
            nametemplate = __nametemplate;
        }

        public reportElementFormSet(reportOutputForm __form, reportOutputFormatName __format, String __nametemplate = "{{{name}}}")
        {
            form = __form;
            nametemplate = __nametemplate;
            fileformat = __format;
        }


        public List<templateFieldBasic> customProperties = new List<templateFieldBasic>();

        public reportElementFormSet AddProperties(List<templateFieldBasic> fields)
        {
            List<templateFieldBasic> flat = fields.getFlatList<templateFieldBasic>();
            customProperties.AddRange(flat);
            return this;
        }

        public reportElementFormSet AddProperties(params templateFieldBasic[] fields)
        {
            List<templateFieldBasic> flds = fields.getFlatList<templateFieldBasic>();

            customProperties.AddRange(flds);
            return this;
        }

        private reportOutputForm _form = reportOutputForm.unknown;
        /// <summary>
        /// 
        /// </summary>
        public reportOutputForm form
        {
            get { return _form; }
            set { _form = value; }
        }



        private String _nametemplate = "{{{name}}}";
        /// <summary>
        /// 
        /// </summary>
        public String nametemplate
        {
            get { return _nametemplate; }
            set { _nametemplate = value; }
        }



        private reportOutputFormatName _fileformat = reportOutputFormatName.unknown;
        /// <summary>
        /// 
        /// </summary>
        public reportOutputFormatName fileformat
        {
            get { return _fileformat; }
            set { _fileformat = value; }
        }

        public reportElementFormSet()
        {
        }
    }

}
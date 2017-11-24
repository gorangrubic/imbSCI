namespace imbSCI.Core.reporting.render.config
{
    using imbSCI.Core.enums;
    using imbSCI.Core.extensions.data;
    using imbSCI.Core.extensions.table;
    using imbSCI.Core.extensions.typeworks;
    using imbSCI.Data.enums;
    using imbSCI.Data.enums.fields;
    using System;
    using System.Data;

    public class dataValueFormatInfo
    {

        private Boolean _directAppend;
        /// <summary>
        /// Avoid markdown, XML or html escaping
        /// </summary>
        public Boolean directAppend
        {
            get { return _directAppend; }
            set { _directAppend = value; }
        }


        private String _valueFormat = "";
        /// <summary>
        /// String format to use for value to string transformation
        /// </summary>
        public String valueFormat
        {
            get { return _valueFormat; }
            set { _valueFormat = value; }
        }


        private printHorizontal _position = printHorizontal.left;
        /// <summary>
        /// 
        /// </summary>
        public printHorizontal position
        {
            get { return _position; }
            set { _position = value; }
        }


        private dataPointImportance _importance;
        /// <summary>
        ///
        /// </summary>
        public dataPointImportance importance
        {
            get { return _importance; }
            set { _importance = value; }
        }
        
        public dataValueFormatInfo(DataColumn dc)
        {
            directAppend = dc.ExtendedProperties.getProperBoolean(false, templateFieldDataTable.col_directAppend);
            valueFormat = dc.GetFormat();
            importance = dc.GetImportance(); // ExtendedProperties.getProperEnum<dataPointImportance>(dataPointImportance.normal, imbAttributeName.measure_important);

            Type type = dc.DataType;
            if (dc.ExtendedProperties.Contains(templateFieldDataTable.col_type)) type = (Type)dc.ExtendedProperties[templateFieldDataTable.col_type];


            if (dc.DataType.isNumber()) position = printHorizontal.right;

        }
    }

    
}

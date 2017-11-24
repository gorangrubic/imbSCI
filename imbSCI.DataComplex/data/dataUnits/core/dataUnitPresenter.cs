namespace imbSCI.DataComplex.data.dataUnits.core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using imbSCI.Core;
    using imbSCI.Core.attributes;
    using imbSCI.Core.collection;
    using imbSCI.Core.data;
    using imbSCI.Core.extensions.data;
    using imbSCI.Core.extensions.text;
    using imbSCI.Core.extensions.typeworks;
    using imbSCI.Core.interfaces;
    using imbSCI.Core.reporting;
    using imbSCI.Data.data;
    using imbSCI.Data.interfaces;
    using imbSCI.DataComplex.data.dataUnits.enums;

    /// <summary>
    /// Describes a way to render dataUnit to Table, Graph or text
    /// </summary>
    /// <typeparam name="TUnit">The type of the unit.</typeparam>
    public class dataUnitPresenter:imbBindable, IObjectWithNameAndDescription   {
        /// <summary>
        /// 
        /// </summary>
        public dataUnitBase parent { get; set; }


        private string _filenamebase;
        /// <summary>filename without extension</summary>
        public string filenamebase
        {
            get
            {
                return _filenamebase;
            }
            protected set
            {
                _filenamebase = value;
                OnPropertyChanged("filenamebase");
            }
        }


        /// <summary>
        /// 
        /// </summary>
        public string key { get; protected set; }


        /// <summary>
        /// Name for this instance
        /// </summary>
        public string name { get; set; } = "";

        /// <summary>
        /// Human-readable description of object instance
        /// </summary>
        public string description { get; set; } = "";


        public dataUnitPresenter(string query, string __title, string __description)
        {
            key = query;
            name = __title;
            description = __description;

        }
        public void setFlags(dataDeliveryPresenterTypeEnum __presentationType, dataDeliverFormatEnum __formatFlags, dataDeliverAttachmentEnum __attachmentFlags)
        {
            formatFlags = __formatFlags;
            presentationType = __presentationType;
            attachmentFlags = __attachmentFlags;
        }

        /// <summary>
        /// 
        /// </summary>
        public dataDeliverAttachmentEnum attachmentFlags { get; set; } = dataDeliverAttachmentEnum.attachCSV | dataDeliverAttachmentEnum.attachJSON | dataDeliverAttachmentEnum.attachExcel;


        private dataDeliveryPresenterTypeEnum _presentationType = dataDeliveryPresenterTypeEnum.tableTwoColumnParam;
        /// <summary> </summary>
        public dataDeliveryPresenterTypeEnum presentationType
        {
            get
            {
                return _presentationType;
            }
            protected set
            {
                _presentationType = value;
                OnPropertyChanged("presentationType");
            }
        }


        /// <summary>
        /// 
        /// </summary>
        public PropertyEntryColumn extraColumns { get; set; } = PropertyEntryColumn.entry_name | PropertyEntryColumn.entry_description;


        /// <summary>
        /// 
        /// </summary>
        public dataDeliverFormatEnum formatFlags { get; set; } = dataDeliverFormatEnum.includeAttachment | dataDeliverFormatEnum.countColumn;


        /// <summary>
        /// 
        /// </summary>
        public string propertyNameRegex { get; set; } = "";


        private List<string> _fields;
        /// <summary> </summary>
        public List<string> fields
        {
            get
            {
                return _fields;
            }
            protected set
            {
                _fields = value;
                OnPropertyChanged("fields");
            }
        }


    }

}
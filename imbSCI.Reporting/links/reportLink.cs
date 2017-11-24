namespace imbSCI.Reporting.links
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using imbSCI.Core;
    using imbSCI.Core.attributes;
    using imbSCI.Core.collection;
    using imbSCI.Core.data;
    using imbSCI.Core.enums;
    using imbSCI.Core.extensions.data;
    using imbSCI.Core.extensions.io;
    using imbSCI.Core.extensions.text;
    using imbSCI.Core.extensions.typeworks;
    using imbSCI.Core.interfaces;
    using imbSCI.Core.reporting;
    using imbSCI.Core.reporting.render;
    using imbSCI.Data;
    using imbSCI.Data.data;
    using imbSCI.Data.enums;
    using imbSCI.Data.enums.fields;
    using imbSCI.Data.interfaces;
    using imbSCI.Reporting.delivery;
    using imbSCI.Reporting.interfaces;
    using imbSCI.Reporting.links.groups;
    using imbSCI.Reporting.links.reportRegistry;
    using imbSCI.Reporting.resources;
    using imbSCI.Reporting.script;

    //public class reportingRegistryQuery
    //{

    //}


    /// <summary>
    /// Report item link
    /// </summary>
    public class reportLink : imbBindable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="reportLink"/> class.
        /// </summary>
        /// <param name="source">The source.</param>
        public reportLink(reportLink source, bool copyPathToo=false)
        {
            linkTitle = source.linkTitle;
            linkDescription = source.linkDescription;
            if (copyPathToo) linkPath = source.linkPath;
            priority = source.priority;

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="reportLink"/> class.
        /// </summary>
        /// <param name="__title">The title.</param>
        /// <param name="__description">The description.</param>
        /// <param name="__path">The path.</param>
        public reportLink(string __title, string __description, string __path)
        {
            linkTitle = __title;
            linkDescription = __description;
            linkPath = __path;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="reportLink"/> class.
        /// </summary>
        /// <param name="__title">The title.</param>
        /// <param name="__description">The description.</param>
        /// <param name="__query">The query.</param>
        public reportLink(string __title, string __description, reportingRegistryQuery __query)
        {
            linkTitle = __title;
            linkDescription = __description;
            registryQuery = __query;
        }

        private reportLinkState _state = reportLinkState.undefined;
        /// <summary> </summary>
        public reportLinkState state
        {
            get
            {
                return _state;
            }
            internal set
            {
                _state = value;
                OnPropertyChanged("state");
            }
        }


        private reportingRegistryQuery _registryQuery;
        /// <summary> </summary>
        public reportingRegistryQuery registryQuery
        {
            get
            {
                return _registryQuery;
            }
            protected set
            {
                _registryQuery = value;
                OnPropertyChanged("registryQuery");
            }
        }


        private dataPointImportance _importance = dataPointImportance.normal;
        /// <summary> </summary>
        public dataPointImportance importance
        {
            get
            {
                return _importance;
            }
            set
            {
                _importance = value;
                OnPropertyChanged("importance");
            }
        }



        private IMetaContentNested _element;
        /// <summary> </summary>
        public IMetaContentNested element
        {
            get
            {
                return _element;
            }
            internal set
            {
                _element = value;
                OnPropertyChanged("element");
            }
        }




        /// <summary>Priority used in menu sorting</summary>
        public int effectivePriority
        {
            get
            {
                return (group.priority * 100) + priority;
            }
            
        }


        private int _priority = 100;
        /// <summary> </summary>
        public int priority
        {
            get
            {
                return _priority;
            }
            set
            {
                _priority = value;
                OnPropertyChanged("priority");
            }
        }


        public void convertToRelative()
        {

            string start = "{{{" + templateFieldBasic.root_relpath + "}}}";

            bool startsWithPlaceholder = linkPath.StartsWith(start);

            linkPath = linkPath.removeStartsWith(start);

            
            linkPath = linkPath.removeStartsWith("/");
            linkPath = linkPath.removeStartsWith("\\");
            if (startsWithPlaceholder)
            {
                linkPath = start + linkPath;
            }
        }

        ///// <summary>
        ///// Converting to relative link path
        ///// </summary>
        ///// <param name="parent"></param>
        //public void convertToRelative(reportSimpleBase parent)
        //{
        //    string pth = linkPath;
        //    //linkPath = linkPath.removeUrlShema();
        //    linkPath = linkPath.removeStartsWith(parent.paths.directory.FullName);
        //    linkPath = linkPath.removeStartsWith("\\");
        //    if (pth.Length == linkPath.Length)
        //    {

        //    }
        //}

        #region --- linkTitle ------- Naslov koji se prikazuje u linku ka ovom izvestaju. Ako je naslov empty onda nece biti linkovanja 
        private string _linkTitle = "";
        /// <summary>
        /// Naslov koji se prikazuje u linku ka ovom izvestaju. Ako je naslov empty onda nece biti linkovanja
        /// </summary>
        public string linkTitle
        {
            get
            {
                return _linkTitle;
            }
            set
            {
                _linkTitle = value;
                OnPropertyChanged("linkTitle");
            }
        }
        #endregion

        #region --- linkDescription ------- Kratak opis ispod linka. 

        private string _linkDescription = "";
        /// <summary>
        /// Kratak opis ispod linka.
        /// </summary>
        public string linkDescription
        {
            get
            {
                return _linkDescription;
            }
            set
            {
                _linkDescription = value;
                OnPropertyChanged("linkDescription");
            }
        }
        #endregion

        #region --- linkPath ------- relativna putanja koju koristi link 
        private string _linkPath = "";
        /// <summary>
        /// relativna putanja koju koristi link
        /// </summary>
        public string linkPath
        {
            get
            {
                return _linkPath;
            }
            set
            {
                _linkPath = value;
                OnPropertyChanged("linkPath");
            }
        }
        #endregion


        #region --- group ------- referenca prema grupi 
        private reportInPackageGroup _group = null;
        /// <summary>
        /// referenca prema grupi
        /// </summary>
        public reportInPackageGroup group
        {
            get
            {
                return _group;
            }
            set
            {
                _group = value;
                OnPropertyChanged("group");
            }
        }
        #endregion



    }
}
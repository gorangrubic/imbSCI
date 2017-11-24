namespace imbSCI.Reporting.links.groups
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
    using imbSCI.Data.interfaces;
    using imbSCI.Reporting.delivery;
    using imbSCI.Reporting.interfaces;
    using imbSCI.Reporting.resources;
    using imbSCI.Reporting.script;

    public class reportInPackageGroup :imbBindable
    {

        private int _priority = 10;

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



        #region --- name ------- naziv grupe 
        private string _name;
        /// <summary>
        /// naziv grupe
        /// </summary>
        public string name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                OnPropertyChanged("name");
            }
        }
        #endregion



        #region --- description ------- group description 

        private string _description = "";
        /// <summary>
        /// group description
        /// </summary>
        public string description
        {
            get
            {
                return _description;
            }
            set
            {
                _description = value;
                OnPropertyChanged("description");
            }
        }
        #endregion



        #region --- parent -------  
        private reportInPackageGroup _parent;
        /// <summary>
        /// 
        /// </summary>
        public reportInPackageGroup parent
        {
            get
            {
                return _parent;
            }
            set
            {
                _parent = value;
                OnPropertyChanged("parent");
            }
        }
        #endregion


        /// <summary>
        /// Vraca putanju ka ovoj grupi
        /// </summary>
        /// <param name="splitter"></param>
        /// <returns></returns>
        public string getPath(string splitter = @"\")
        {
            string path = name;
            if (parent != null)
            {
                path = name.ensureStartsWith(splitter);
                path = parent.getPath(splitter) + path;
            }
            return path;
        }

    }
}
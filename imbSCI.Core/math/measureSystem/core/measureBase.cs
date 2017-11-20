namespace imbSCI.Core.math.measureSystem.core
{
    using System;
    using imbSCI.Data;

    /// <summary>
    /// 
    /// </summary>
    public abstract class measureBase
    {


        private String _name = "";
        /// <summary>
        /// 
        /// </summary>
        public String name
        {
            get { return _name; }
            set { _name = value; }
        }



        private String _description = "";
        /// <summary>
        /// 
        /// </summary>
        public String description
        {
            get { return _description; }
            set { _description = value; }
        }

        private String _metaModelName;
        /// <summary>
        /// 
        /// </summary>
        public String metaModelName
        {
            get { return _metaModelName; }
            set { _metaModelName = value; }
        }


        private String _metaModelPrefix;
        /// <summary>
        /// 
        /// </summary>
        public String metaModelPrefix
        {
            get { return _metaModelPrefix; }
            set { _metaModelPrefix = value; }
        }



        /// <summary>
        /// 
        /// </summary>
        public String metaModelFull
        {
            get
            {

                return imbSciStringExtensions.add(metaModelPrefix, metaModelName, "_");

            }
            set
            {
                var pths = value.SplitSmart("."); //.getPathParts();
                if (pths.Count > 1)
                {
                    _metaModelPrefix = pths[0];
                    _metaModelName = pths[1];

                }
                else if (pths.Count > 0)
                {
                    _metaModelName = pths[0];
                }
            }
        }

    }
}
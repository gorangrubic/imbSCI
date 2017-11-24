namespace imbSCI.Data.collection.special
{
    using System;

    public class colorWhellForContent:circularSelector<string>
    {
        private String _header;
        /// <summary>
        /// 
        /// </summary>
        public String header
        {
            get { return _header; }
            set { _header = value; }
        }


        private String _footer;
        /// <summary>
        /// 
        /// </summary>
        public String footer
        {
            get { return _footer; }
            set { _footer = value; }
        }



        private String _heading;
        /// <summary>
        /// 
        /// </summary>
        public String heading
        {
            get { return _heading; }
            set { _heading = value; }
        }


        public colorWhellForContent(String evenHex, String oddHex, String minorHex)
        {
            Add(evenHex, oddHex, evenHex, oddHex, minorHex);
        }
    }

}
using imbSCI.Data.data;

namespace imbSCI.Core.syntax.data.files.@base
{
    /// <summary>
    /// Polazna klasa za sve objekte koji su nastali citanjem fajlova
    /// </summary>
    public abstract class fileDataSetBase:dataBindableBase, IAceDataFile
    {

        #region --- path ------- source path 
        private string _path;
        /// <summary>
        /// source path 
        /// </summary>
        public string path
        {
            get
            {
                return _path;
            }
            set
            {
                _path = value;
                OnPropertyChanged("path");
            }
        }
        #endregion

        /// <summary>
        /// Proverava da li je prosledjena putanja
        /// </summary>
        /// <param name="_path"></param>
        /// <returns></returns>
        protected string _checkPath(string _path)
        {
            if (string.IsNullOrEmpty(_path))
            {
                
            } else
            {
                path = _path;
            }
            return path;
        }

        public abstract bool load(string _path="");

        public abstract bool afterLoad();


        public abstract bool processToObject(object _target);

        public abstract bool processToDictionary();


        public abstract bool beforeSave();

        public abstract bool save(string _path = "");

        

    }
}
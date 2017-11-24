namespace imbSCI.Core.collection.checkLists
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Xml.Serialization;

    /// <summary>
    /// Kolekcija chekiranih Enum objekata
    /// </summary>
    public class imbCheckedObjects 
    {
        #region --- values ------- Sve vrednosti

        private ObservableCollection<imbCheckedObject> _values;

        /// <summary>
        /// Sve vrednosti
        /// </summary>
        [XmlIgnore]
        public ObservableCollection<imbCheckedObject> values
        {
            get { return _values; }
            set
            {
                _values = value;
                
            }
        }

        #endregion

        #region --- checkList ------- Lista chekiranih vrednosti 

        private List<string> _checkList = new List<string>();

        /// <summary>
        /// Lista chekiranih vrednosti
        /// </summary>
        public List<string> checkList
        {
            get { return _checkList; }
            set
            {
                _checkList = value;
                prepare();
                
            }
        }

        #endregion

        private String _enumName;

        public imbCheckedObjects()
        {
        }

        /// <summary>
        /// naziv enumeracije koja se prikazuje
        /// </summary>
        public String enumName
        {
            get { return _enumName; }
            set
            {
                _enumName = value;
                
            }
        }

        public void prepare()
        {
            //ObservableCollection<imbCheckedObject> _values = new ObservableCollection<imbCheckedObject>();
            
            //Type enType = imbCoreManager.enumerations.getElementSafe(enumName) as Type;
            //    //._enumerations.getItem(enumName, imbCollection.loadType.nullIfNotFound) as Type;

            //if (enType != null)
            //{
            //    String[] names = Enum.GetNames(enType);
            //    foreach (String nm in names) _values.Add(new imbCheckedObject(false, nm));
            //}

            //foreach (String ch in _checkList)
            //{
            //    values.First(x => x.value == ch).isChecked = true;
            //}
        }


        //public imbCheckedObjects( enumeration)
        //{

        //}
    }
}
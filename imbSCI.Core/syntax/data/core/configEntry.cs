// // using System.Linq;

// using System.Threading.Tasks;

namespace imbSCI.Core.syntax.data.core
{
    using imbSCI.Data.data;
    using System;

    /// <summary>
    /// Opis jedne konfiguracione varijable - ne sadrzi vrednost
    /// </summary>
    public class configEntry : dataBindableBase
    {


        #region --- name ------- Short flag name of configuration entry
        private String _name;
        /// <summary>
        /// Short flag name of configuration entry
        /// </summary>
        public String name
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


        #region --- address ------- Int32 adresa u SYNCHRO, VT ili TECO registru
        private Int32 _address;
        /// <summary>
        /// Int32 adresa u SYNCHRO, VT ili TECO registru
        /// </summary>
        public Int32 address
        {
            get
            {
                return _address;
            }
            set
            {
                _address = value;
                OnPropertyChanged("address");
            }
        }
        #endregion


        #region --- description ------- Opis varijable

        private String _description = "";
        /// <summary>
        /// Opis varijable
        /// </summary>
        public String description
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
        
        


        #region --- flags ------- Primenjene oznake
        private configEntryFlag _flags;
        /// <summary>
        /// Primenjene oznake
        /// </summary>
        public configEntryFlag flags
        {
            get
            {
                return _flags;
            }
            set
            {
                _flags = value;
                OnPropertyChanged("flags");
            }
        }
        #endregion
        


       
    }
}

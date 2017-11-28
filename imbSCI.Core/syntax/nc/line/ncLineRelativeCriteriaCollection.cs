namespace imbSCI.Core.syntax.nc.line
{
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Xml.Serialization;

    [XmlInclude(typeof(ncLineRelativeCriteria))]
    [XmlInclude(typeof(ncLineCriteria))]
    
    /// <summary>
    /// Kolekcija relativnih kriterijuma koje evaluaira nakon osnovnog kriterijuma
    /// </summary>
    public class ncLineRelativeCriteriaCollection:List<ncLineRelativeCriteria>, INotifyPropertyChanged
    {
        /// <summary>
        /// Kreira event koji obaveštava da je promenjen neki parametar
        /// </summary>
        /// <remarks>
        /// Neće biti kreiran event ako nije spremna aplikacija: imbSettingsManager.current.isReady
        /// </remarks>
        /// <param name="name"></param>
        public void OnPropertyChanged(string name)
        {

            PropertyChangedEventHandler handler = PropertyChanged;

        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
namespace imbSCI.Core.files.job
{
    using imbSCI.Core.syntax.data.files;
    using imbSCI.Data.interfaces;
    using System;
    using System.ComponentModel;

    public interface IAceFileJobBase:IObjectWithName,INotifyPropertyChanged, IAceProjectBase
    {
        /// <summary>
        /// Name for this Job - used for filename and for menu navigation
        /// </summary>
// [XmlIgnore]
        String name { get; set; }

        /// <summary>
        /// Podesavanja skeniranja fajla
        /// </summary>
// [XmlIgnore]
        fileTargetListSettings scanFiles { get; set; }

        /// <summary>
        /// Number of files to be processed in one processing take; 0 and -1 will set program default
        /// </summary>
// [XmlIgnore]
        Int32 processTakeSize { get; set; }

        /// <summary>
        /// Generise string izvestaj o trenutnom poslu
        /// </summary>
        /// <returns></returns>
        String explainJob();

        /// <summary>
        /// Kreira event koji obaveštava da je promenjen neki parametar
        /// </summary>
        /// <remarks>
        /// Neće biti kreiran event ako nije spremna aplikacija: imbSettingsManager.current.isReady
        /// </remarks>
        /// <param name="name"></param>
        void OnPropertyChanged(string name);

        event PropertyChangedEventHandler PropertyChanged;
    }
}
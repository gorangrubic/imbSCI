namespace imbSCI.Core.syntax.data.files.@base
{
    using System.ComponentModel;

    public interface IAceDataFile
    {
        /// <summary>
        /// source path 
        /// </summary>
        string path { get; set; }

        bool load(string _path="");
        bool processToObject(object _target);
        bool processToDictionary();
        bool save(string _path = "");

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
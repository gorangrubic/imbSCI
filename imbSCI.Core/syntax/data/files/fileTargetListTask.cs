namespace imbSCI.Core.syntax.data.files
{
    /// <summary>
    /// Komande koje moze da izvrsi fileTargetList
    /// </summary>
    public enum fileTargetListTask
    {
        /// <summary>
        /// skenira fajlove
        /// </summary>
        scan,
        /// <summary>
        /// skenira i pokrece backup
        /// </summary>
        backup,
        /// <summary>
        /// skenira i vraca listu pronadjenih v
        /// </summary>
        showList,
        /// <summary>
        /// snima listu
        /// </summary>
        saveList,
        /// <summary>
        /// zatvara menu
        /// </summary>
        done,
    }
}
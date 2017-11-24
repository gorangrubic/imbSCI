namespace imbSCI.Data.enums
{
    /// <summary>
    /// External tool to run. Call extension to open tool and specified file from <c>filepath</c>
    /// </summary>
    public enum externalTool
    {
        none,
        /// <summary>
        /// Mozzila FireFox
        /// </summary>
        firefox,

        /// <summary>
        /// Google Chrome
        /// </summary>
        chrome,

        /// <summary>
        /// Internet Explorer
        /// </summary>
        explorer,

        /// <summary>
        /// Notepad ++
        /// </summary>
        notepadpp,

        /// <summary>
        /// Adobe Dreamweaver
        /// </summary>
        dreamweaver,

        /// <summary>
        /// WAMP server
        /// </summary>
        wamp,

        /// <summary>
        /// phpMyAdmin 
        /// </summary>
        phpMyAdmin,

        /// <summary>
        /// Windows Explorer da otvori folder gde se nalazi trenutni projekat
        /// </summary>
        projectFolder,

        /// <summary>
        /// Windows Explorer da otvori folder gde je instalirana aplikacija
        /// </summary>
        runtimeFolder,

        /// <summary>
        /// Windows Explorer da otvori WAMP www
        /// </summary>
        wampWWW,

        /// <summary>
        /// WAMP localhost via Firefox
        /// </summary>
        wampLocalhost,

        /// <summary>
        /// Windows Explorer
        /// </summary>
        folderExplorer,

        /// <summary>
        /// Adobe photoshop
        /// </summary>
        photoshop,

        /// <summary>
        /// Gde se nalazi dot.exe
        /// </summary>
        graphVizDot,

        /// <summary>
        /// Poziva kao command line
        /// </summary>
        fusekiServer,

        /// <summary>
        /// Poziva kao JAR preko Java
        /// </summary>
        fusekiServerJava,


        /// <summary>
        /// Prikaz fuseki local hosta
        /// </summary>
        fusekiLocalhost,

        /// <summary>
        /// Alatka za slobodno izvrsavanje
        /// </summary>
        freeRunner,

        /// <summary>
        /// Forces the application to guess tool by extension
        /// </summary>
        autodetect,
    }


}
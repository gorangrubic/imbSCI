using imbSCI.Core.files;
using imbSCI.Core.files.folders;
using imbSCI.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace imbSCI.Graph.DiagramLibraries.DiaShape
{



    [XmlRoot(ElementName = "sheet", Namespace = "http://www.lysator.liu.se/~alla/dia/dia-sheet-ns")]
    public class diaSheet
    {
        public diaSheet()
        {
        }

      

        /// <summary>
        /// Loads the specified path.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <returns></returns>
        public static diaSheet Load(String path)
        {

            diaSheet output = objectSerialization.loadObjectFromXML<diaSheet>(path);


            return output;
        }

        /// <summary>
        /// Saves the specified path.
        /// </summary>
        /// <param name="path">The path.</param>
        public void Save(String path)
        {
            objectSerialization.saveObjectToXML(this, path);
        }

        /// <summary>
        /// Saves the specified folder.
        /// </summary>
        /// <param name="folder">The folder.</param>
        /// <param name="filename">The filename.</param>
        /// <param name="description">The description.</param>
        /// <returns></returns>
        public String Save(folderNode folder, String filename, String description = "")
        {
            filename = filename.ensureEndsWith(".sheet");
            String path = folder.pathFor(filename, Data.enums.getWritableFileMode.newOrExisting, description, true);

            objectSerialization.saveObjectToXML(this, path);
            return path;
        }



        //[XmlArrayItem(ElementName = "name")]
        //public List<xmlTextLocaleEntry> names { get; set; } = new List<xmlTextLocaleEntry>();

        [XmlElement(ElementName = "name")]
        public xmlTextLocaleEntry[] names { get; set; } = new xmlTextLocaleEntry[] { };

        [XmlElement(ElementName = "description")]
        public xmlTextLocaleEntry[] descriptions { get; set; } = new xmlTextLocaleEntry[] { };

        //[XmlArrayItem(ElementName = "description")]
        //public List<xmlTextLocaleEntry> descriptions { get; set; } = new List<xmlTextLocaleEntry>();

        [XmlArray(ElementName = "contents")]
        [XmlArrayItem(ElementName = "object")]
        public List<diaSheetObject> contents { get; set; } = new List<diaSheetObject>();
    }

}
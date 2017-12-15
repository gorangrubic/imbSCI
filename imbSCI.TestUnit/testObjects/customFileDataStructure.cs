using System;
using System.Linq;
using System.Collections.Generic;
using imbSCI.DataComplex.tables;
using System.Text;
using System.Threading.Tasks;
using imbSCI.Core.files.fileDataStructure;
using System.Xml.Serialization;

namespace imbSCI.TestUnit.testObjects
{
    [fileStructure("name", fileStructureMode.subdirectory, fileDataFilenameMode.propertyValue)]
    public class customFileDataStructure : fileDataStructure, IFileDataStructure
    {

        private String _name = "test";
        /// <summary>
        /// Name for this instance
        /// </summary>
        public String name
        {
            get { return _name; }
            set { _name = value; }
        }

        private String _description = "";
        /// <summary>
        /// Human-readable description of object instance
        /// </summary>
        public String description
        {
            get { return _description; }
            set { _description = value; }
        }


        


        [fileData(fileDataFilenameMode.memberInfoName, fileDataPropertyMode.autoTextOrXml)]
        [XmlIgnore]
        public customTable table { get; set; } = new customTable(nameof(table));


        public override void OnBeforeSave()
        {
            
        }

        public override void OnLoaded()
        {
            
        }
    }

}
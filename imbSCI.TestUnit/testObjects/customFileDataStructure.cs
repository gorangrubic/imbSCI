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

    public class someDataObjectTwo
    {
        public someDataObjectTwo()
        {

        }

        public someDataObjectTwo(String _dataOne)
        {
            dataOne = _dataOne;
        }

        public String dataOne { get; set; } = "MYDATA2";
    }

    public class someDataObject
    {
        public someDataObject()
        {

        }

        public String dataOne { get; set; } = "MYDATA";

        public List<someDataObjectTwo> dataitems { get; set; } = new List<someDataObjectTwo>();

        public void setup()
        {
            dataitems.Add(new someDataObjectTwo("test1"));
            dataitems.Add(new someDataObjectTwo("test2"));
            dataitems.Add(new someDataObjectTwo("test3"));
        }
    }

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

        public void setup()
        {
            someDataObject d1 = new someDataObject();
            d1.setup();

            someDataObject d2 = new someDataObject();
            d2.setup();

            someDataObject d3 = new someDataObject();
            d3.setup();
            dataObjects.Add(d1);
            dataObjects.Add(d2);
            dataObjects.Add(d3);
        }

        [fileData(fileDataFilenameMode.memberInfoName, fileDataPropertyMode.XML, fileDataPropertyOptions.itemAsFile)]
        [XmlIgnore]
        public List<someDataObject> dataObjects { get; set; } = new List<someDataObject>();
        


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
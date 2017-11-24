using System;
using System.Collections.Generic;
using System.Linq;
using imbSCI.Core;
using imbSCI.Core.attributes;
using imbSCI.Core.collection;
using imbSCI.Core.data;
using imbSCI.Core.enums;
using imbSCI.Core.extensions.data;
using imbSCI.Core.extensions.io;
using imbSCI.Core.extensions.text;
using imbSCI.Core.extensions.typeworks;
using imbSCI.Core.interfaces;
using imbSCI.Core.reporting;
using imbSCI.Data;
using imbSCI.Data.data;
using imbSCI.Data.enums;
using imbSCI.Data.interfaces;

namespace imbSCI.DataComplex.tests
{
    using imbSCI.Data.enums.fields;
    #region imbVELES USING

    using System.ComponentModel;
    using System.Data;
    using System.Globalization;

    #endregion

    /// <summary>
    /// 2013c: LowLevel resurs
    /// </summary>
    public class testDefinition : imbBindable, IAppendDataFieldsExtended
    {
        

        /// <summary>
        /// Appends its data points into new or existing property collection
        /// </summary>
        /// <param name="data">Property collection to add data into</param>
        /// <returns>Updated or newly created property collection</returns>
        public PropertyCollectionExtended AppendDataFields(PropertyCollectionExtended data =null)
        {
            if (data == null) data = new PropertyCollectionExtended();
            data[templateFieldBasic.test_caption] = caption;
            data[templateFieldBasic.test_description] = description;
            data[templateFieldBasic.test_versionCount] = versionCount;
            data[templateFieldBasic.test_runstamp] = currentRunStamp;
            data[templateFieldBasic.test_runstart] = testStartTime.ToLongTimeString();
            data[templateFieldBasic.test_status] = status;
            if (testFinishTime == testStartTime)
            {
                data[templateFieldBasic.test_runtime] = "Not finished";
            }
            else
            {
                TimeSpan span = testFinishTime.Subtract(testStartTime);

                data[templateFieldBasic.test_runtime] = span.TotalSeconds.getSeconds(2);
            }
            return data;
        }

        PropertyCollection IAppendDataFields.AppendDataFields(PropertyCollection data = null) => (PropertyCollection)AppendDataFields(data as PropertyCollectionExtended);


        public testDefinition()
        {
        }

        /// <summary>
        /// Definition of scientific test
        /// </summary>
        /// <param name="__caption"></param>
        /// <param name="__description"></param>
        /// <param name="_v">Version of the test</param>
        public testDefinition(String __caption, String __description = "", Int32 _v = 1)
        {
            caption = __caption;
            description = __description;
        }



        #region --- testFinishTime ------- Span between test start time and test finished call 
        private DateTime _testFinishTime;
        /// <summary>
        /// Span between test start time and test finished call
        /// </summary>
        public DateTime testFinishTime
        {
            get
            {
                return _testFinishTime;

            }
            set
            {
                _testFinishTime = value;
                OnPropertyChanged("testFinishTime");
            }
        }
        #endregion


        #region --- testStartTime ------- Time at test start 
        private DateTime _testStartTime;
        /// <summary>
        /// Time at test start
        /// </summary>
        internal DateTime testStartTime
        {
            get
            {
                return _testStartTime;
            }
            set
            {
                _testStartTime = value;
                OnPropertyChanged("testStartTime");
            }
        }
        #endregion

        




        #region -----------  description  -------  [Opis testa - opciono]

        private String _description = ""; // = new String();

        /// <summary>
        /// Opis testa - opciono
        /// </summary>
        // [XmlIgnore]
        [Category("testDefinition")]
        [DisplayName("description")]
        [Description("Opis testa - opciono")]
        public String description
        {
            get { return _description; }
            set
            {
                // Boolean chg = (_description != value);
                _description = value;
                OnPropertyChanged("description");
                // if (chg) {}
            }
        }

        #endregion

        #region -----------  caption  -------  [Naslov testa koji se izvrsava]

        private String _caption = "Test"; // = new String();

        /// <summary>
        /// Naslov testa koji se izvrsava
        /// </summary>
        // [XmlIgnore]
        [Category("testDefinition")]
        [DisplayName("caption")]
        [Description("Naslov testa koji se izvrsava")]
        public String caption
        {
            get { return _caption; }
            set
            {
                // Boolean chg = (_caption != value);
                _caption = value;
                OnPropertyChanged("caption");
                // if (chg) {}
            }
        }

        #endregion

        #region -----------  versionCount  -------  [Brojac koja je po redu verzija testa izvrsena]

        private Int32 _versionCount = 1; // = new Int32();

        /// <summary>
        /// Brojac koja je po redu verzija testa izvrsena
        /// </summary>
        // [XmlIgnore]
        [Category("testDefinition")]
        [DisplayName("versionCount")]
        [Description("Brojac koja je po redu verzija testa izvrsena")]
        public Int32 versionCount
        {
            get { return _versionCount; }
            set
            {
                // Boolean chg = (_versionCount != value);
                _versionCount = value;
                OnPropertyChanged("versionCount");
                // if (chg) {}
            }
        }

        #endregion

        #region -----------  currentRunStamp  -------  [Trenutan RunStamp]

        private String _currentRunStamp = ""; // = new String();

        /// <summary>
        /// Trenutan RunStamp
        /// </summary>
        // [XmlIgnore]
        [Category("testDefinition")]
        [DisplayName("currentRunStamp")]
        [Description("Trenutan RunStamp")]
        public String currentRunStamp
        {
            get { return _currentRunStamp; }
            set
            {
                // Boolean chg = (_currentRunStamp != value);
                _currentRunStamp = value;
                OnPropertyChanged("currentRunStamp");
                // if (chg) {}
            }
        }

        #endregion


        /// <summary>
        /// Thread safe test finished update call
        /// </summary>
        /// <param name="successOrFail"></param>
        public void testFinished(Boolean successOrFail)
        {
            testFinishTime = DateTime.Now;

            if (successOrFail)
            {
                status = testStatus.success;
            } else
            {
                status = testStatus.fail;
            }
            throw new NotImplementedException();
        }

       


        #region --- status ------- Status of this test 
        private testStatus _status = testStatus.wait;
        /// <summary>
        /// Status of this test
        /// </summary>
        public testStatus status
        {
            get
            {
                return _status;
            }
            set
            {
                _status = value;
                OnPropertyChanged("status");
            }
        }
        #endregion


        /// <summary>
        /// Generise RunStamp prema prosledjenim podesavanjima - sobijen stamp postavlja u currentRunStamp i vraca dobijenu vrednost
        /// </summary>
        /// <param name="settings">Podesavanja na osnovu kojih definise RunStamp</param>
        /// <returns>Dobijeni runStamp  - kopija je ostala u currentRunStamp</returns>
        public String getRunStamp(testLabelingSettings settings)
        {
            String captionElement = "";
            String versionElement = "";
            String dateElement = "";
            String output = "";

            if (settings.doAbbrevateTitle)
            {
                captionElement = caption.imbGetAbbrevation(settings.titleAbbrevationLength, false);
            }
            else
            {
                captionElement = caption;
            }

            versionElement = versionCount.getSerial(settings.testCountDigitCount, "");

            dateElement = "";
            DateTime current = DateTime.Now;
            testFinishTime = current;
            testStartTime = current;


            if (settings.insertDayInMonth) dateElement += current.Day.getSerial(2, "");
            if (settings.insertMonthTreeLetters) dateElement += current.ToString("MMM", CultureInfo.InvariantCulture);
            if (settings.insertYear) dateElement += current.Year;

            output = captionElement + settings.separator + versionElement + settings.separator + dateElement;

            if (settings.sampleBlockOrdinalNumber > 0)
            {
                output = output.add(settings.sampleBlockOrdinalNumber.ToString("D2"), "_B");
            }

            currentRunStamp = output;
            return output;
        }
    }
}
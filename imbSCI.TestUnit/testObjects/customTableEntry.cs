using System;
using System.Linq;
using System.Collections.Generic;
using imbSCI.DataComplex.tables;
using System.Text;
using System.Threading.Tasks;
using imbSCI.Core.files.fileDataStructure;
using imbSCI.Core.math;
using System.ComponentModel;
using imbSCI.Core.attributes;
using imbSCI.Core.extensions.data;

namespace imbSCI.TestUnit.testObjects
{

    public class customTableEntry
    {
        [Category("GroupA")]
        [DisplayName("Name")]
        [imb(imbAttributeName.measure_letter, "R")]
        [imb(imbAttributeName.basicColor, "#773300")]
        public String name { get; set; } = "someName";

        [Category("GroupA")]
        public Int32 number { get; set; }

        // public Double rate { get; set; }



        /// <summary> Ratio </summary>
        [Category("GroupB")]
        [DisplayName("rate")]
        [imb(imbAttributeName.measure_letter, "R")]
        [imb(imbAttributeName.measure_setUnit, "%")]
        [Description("Ratio")] // [imb(imbAttributeName.measure_important)][imb(imbAttributeName.reporting_valueformat, "")][imb(imbAttributeName.reporting_escapeoff)]
        public Double rate { get; set; } = default(Double);

        [Category("GroupA")]
        public Int32 number2 { get; set; } = 0;

        [Category("GroupA")]
        public Int32 number3 { get; set; }


        [Category("GroupB")]
        public Int32 number4 { get; set; }

        [Category("GroupB")]
        [imb(imbAttributeName.basicColor, "#773300")]
        public Int32 number5 { get; set; }

        [Category("GroupB")]
        public Int32 numberD { get; set; }


        [Category("GroupC")]
        [imb(imbAttributeName.basicColor, "#773300")]
        public Int32 number6 { get; set; }

        [Category("GroupB")]
        public Int32 number7 { get; set; }

        public customTableEntry() {

            name = imbSCI.Core.extensions.text.imbStringGenerators.getRandomString(15);
            
            number = rnd.Next(300);

            rate = number.GetRatio(300);
        }

        public static Random rnd = new Random(52);

        public customTableEntry(String _name)
        {
            if (!_name.isNullOrEmpty()) name = _name;

            
            number = rnd.Next(300);

            rate = number.GetRatio(300);
        }
    }

}
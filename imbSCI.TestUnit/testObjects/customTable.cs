using imbSCI.DataComplex.tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace imbSCI.TestUnit.testObjects
{
    

    public class customTable : objectTableCustom<customTableEntry>
    {
        public override string keyPropertyName
        {
            get
            {
                return nameof(customTableEntry.name);
            }
        }


        public customTable(String __name):base(__name)
        {
            
            getReady();
        }

        public customTable() : base()
        {

        }
    }
}

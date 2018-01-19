using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using imbSCI.Graph.DGML;

namespace imbSCI.Graph.DGML.core
{
    public class Category:GraphNodeElement
    {
        public Category()
        {

        }


        public Category(Int32 id, String label, String basedOn)
        {
            Id = id.ToString();
            Label = label;
            BasedOn = basedOn;
        }


        public Category(String label, String basedOn)
        {
            Label = label;
            Id = label.GetIDFromLabel();

            BasedOn = basedOn;
        }

        public String BasedOn { get; set; }


    }
}

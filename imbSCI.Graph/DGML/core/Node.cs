using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace imbSCI.Graph.DGML.core
{



    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="imbSCI.Graph.DGML.core.GraphNodeElement" />
    public class Node:GraphNodeElement
    {
        public Node()
        {

        }


        public Node(String label)
        {
            Id = label.GetIDFromLabel();
            Label = label;
        }
    }
}

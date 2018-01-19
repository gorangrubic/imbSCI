using imbSCI.Graph.DGML.core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace imbSCI.Graph.DGML.collections
{


    public class NodeCollection:List<Node>
    {
        public NodeCollection()
        {

        }

        public Node AddNode(String id, String name)
        {
            var output = this.FirstOrDefault(x => x.Id == id);
            if (output == null)
            {
                output = new Node(name);
                output.Id = id;
                Add(output);
            }
            return output;
        }

            public Node AddNode(String name)
        {
            var output = this.FirstOrDefault(x => x.Id == name);
            if (output == null)
            {
                output = new Node(name);
                Add(output);
            }
            return output;
        }

        public Node this[String id]
        {
            get
            {
                return this.FirstOrDefault(x => x.Id == id);
            }
        }
    }
}

using System;
using System.Linq;
using System.Collections.Generic;
using imbSCI.Graph.DGML.core;
using System.Text;

namespace imbSCI.Graph.DGML.collections
{

    public class LinkCollection : List<Link>
    {
        public LinkCollection()
        {

        }

        public Link AddLink(Node nodeA, Node nodeB, String linkLabel)
        {
            Link l = new Link(nodeA.Id, nodeB.Id);
            l.Label = linkLabel;
            Add(l);
            return l;
        }
    }

}
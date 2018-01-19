using imbSCI.Core.extensions.data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace imbNLP.PartOfSpeech.TFModels.semanticCloud.core
{


    public class freeGraphLinkBase
    {
        public freeGraphLinkBase()
        {

        }

        public Int32 type { get; set; } = 0;

        public Double weight { get; set; } = 1;

        public String nodeNameA { get; set; } = "";

        public String nodeNameB { get; set; } = "";

        public freeGraphLinkBase GetClone()
        {
            freeGraphLinkBase link = new freeGraphLinkBase();
            link.type = type;
            link.weight = weight;
            link.nodeNameA = nodeNameA;
            link.nodeNameB = nodeNameB;
            return link;
        }
    }

}
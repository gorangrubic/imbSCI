using System;
using System.Linq;
using System.Collections.Generic;
using imbSCI.Core.extensions.data;
using System.Text;
using System.Xml.Serialization;

namespace imbNLP.PartOfSpeech.TFModels.semanticCloud.core
{

    public class freeGraphLink
    {
        public freeGraphLink(freeGraphLinkBase link)
        {
            //type = link.type;
            //weight = link.weight;
            linkBase = link;
        }

        public Boolean IsReady
        {
            get
            {
                if (nodeA == null) return false;
                if (nodeB == null) return false;
                if (linkBase == null) return false;
                return true;
            }
        }

        public freeGraphLinkBase linkBase { get; set; }

        //public Int32 type { get; set; } = 0;

        //public Double weight { get; set; } = 1;

        public freeGraphNodeBase nodeA { get; set; }

        public freeGraphNodeBase nodeB { get; set; }


    }

}
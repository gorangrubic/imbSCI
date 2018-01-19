using System;
using System.Linq;
using System.Collections.Generic;
using imbSCI.Core.extensions.data;
using System.Text;
using System.Xml.Serialization;

namespace imbNLP.PartOfSpeech.TFModels.semanticCloud.core
{

    public class freeGraphNodeAndLinks:List<freeGraphLink>
    {
        public freeGraphNodeBase node { get; set; } = null;

        public Dictionary<String, freeGraphNodeBase> linkedNodeClones { get; set; } = new Dictionary<string, freeGraphNodeBase>();


    }

}
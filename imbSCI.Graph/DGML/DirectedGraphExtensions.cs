using System;
using System.Linq;
using System.Collections.Generic;
using imbSCI.Graph.DGML.collections;
using System.Text;
using System.Xml.Serialization;
using imbSCI.Core.extensions.text;
using imbSCI.Core.extensions.io;

namespace imbSCI.Graph.DGML
{

    public static class DirectedGraphExtensions
    {
        public static String GetIDFromLabel(this String labelString)
        {
            return labelString.getFilename();
        }

    }

}
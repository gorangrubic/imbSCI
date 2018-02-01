using System;
using System.Linq;
using System.Collections.Generic;
using imbSCI.Core.extensions.data;
using imbSCI.Data.collection.graph;
using System.Text;
using System.Xml.Serialization;
using imbSCI.Graph.Converters;
using imbSCI.Core.files;
using System.IO;
using imbSCI.Core.extensions.io;
using imbSCI.Data.enums;

namespace imbSCI.Graph.FreeGraph
{

    /// <summary>
    /// Type of graph ping operation. <see cref="freeGraphExtensions.PingGraphSize(freeGraph, freeGraphNodeBase, bool, freeGraphPingType, int)"/>
    /// </summary>
    public enum freeGraphPingType
    {
        /// <summary>
        /// The maximum ping length: performs ping operation for each <see cref="freeGraphNodeBase"/> separatly, and returns the highest ping length (number of cycles until number of pinged nodes becomes stable)
        /// </summary>
        maximumPingLength,
        /// <summary>
        /// The average ping length: performs ping operation for each <see cref="freeGraphNodeBase"/> separatly, and returns the average ping length (number of cycles until number of pinged nodes becomes stable)
        /// </summary>
        averagePingLength,
        /// <summary>
        /// The unison ping length: performs ping at once from all ping sources
        /// </summary>
        unisonPingLength,
        /// <summary>
        /// The number of pinged nodes: returns number of nodes reached by ping
        /// </summary>
        numberOfPingedNodes

    }

}
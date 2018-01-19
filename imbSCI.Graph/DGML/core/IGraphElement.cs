using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using imbSCI.Graph.DGML.enums;
using System.Xml.Serialization;

namespace imbSCI.Graph.DGML.core
{

    public interface IGraphElement
    {
        
        String Stroke { get; set; }

        
        Int32 StrokeThinkness { get; set; }

        
        String StrokeDashArray { get; set; }

        
        String Label { get; set; } 

        
        String Category { get; set; }

        
        GroupEnum Group { get; set; } 

        
        Visibility Visibility { get; set; }

    }

}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace imbSCI.Graph.DGML.enums
{
    public enum GroupEnum
    {
        Expanded,
        Collapsed
    }

    public enum GraphDirectionEnum
    {
        Sugiyama,
        TopToBottom,
        BottomToTop,
        LeftToRight,
        RightToLeft
    }

    public enum GraphLayoutEnum
    {
        None,
        Sugiyama,
        ForceDirected,
        DependencyMatrix
    }
}

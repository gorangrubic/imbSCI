using System;
using System.Linq;
using System.Collections.Generic;
using imbSCI.Data;
using imbSCI.Graph.Graphics.SvgDocument;
using System.Text;
using System.Collections;
using System.Text.RegularExpressions;
using imbSCI.Core.extensions.text;

namespace imbSCI.Graph.Graphics.SvgAPI.Core
{
    /// <summary>
    /// Used for <see cref="svgPath"/>
    /// </summary>
    public interface ISVGInlineArgument
    {
        String ToString();

        void FromString(String input);
    }

}
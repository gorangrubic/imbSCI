namespace imbSCI.Reporting.meta.data
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using imbSCI.Core;
    using imbSCI.Core.attributes;
    using imbSCI.Core.collection;
    using imbSCI.Core.data;
    using imbSCI.Core.enums;
    using imbSCI.Core.extensions.data;
    using imbSCI.Core.extensions.io;
    using imbSCI.Core.extensions.text;
    using imbSCI.Core.extensions.typeworks;
    using imbSCI.Core.interfaces;
    using imbSCI.Core.reporting;
    using imbSCI.Core.reporting.render;
    using imbSCI.Data;
    using imbSCI.Data.data;
    using imbSCI.Data.enums;
    using imbSCI.Data.interfaces;
    using imbSCI.Reporting.delivery;
    using imbSCI.Reporting.interfaces;
    using imbSCI.Reporting.resources;
    using imbSCI.Reporting.script;
    using imbSCI.Data.enums.appends;
    using imbSCI.Core.reporting.style.core;
    using imbSCI.Core.reporting.colors;

    /// <summary>
    /// Collection of styler settings
    /// </summary>
    /// <seealso cref="System.Data.PropertyCollection" />
    public class dataProviderForStyler:PropertyCollection
    {
        public dataProviderForStyler(cursorVariatorHeadFootFlags headFoot, appendTableOptionFlags tableOps, cursorVariatorOddEvenFlags oddEven, styleFourSide container, acePaletteRole mainColor, acePaletteRole layoutColor)
        {
            this.setColors(mainColor, layoutColor);
            this.setVariatorFlags(headFoot, tableOps, oddEven, container);
        }
    }

}
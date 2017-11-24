namespace imbSCI.Reporting.meta.delivery
{
    using System;
    using System.Collections.Generic;
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
    using imbSCI.Data.collection.nested;

    public class deliveryUnitItemByLevels:aceEnumDictionary<reportElementLevel, List<deliveryUnitItem>>
    {
        public void Add(IEnumerable<reportElementLevel> levels, deliveryUnitItem item)
        {
            foreach (reportElementLevel lev in levels)
            {
                if (this[lev].Contains(item))
                {

                }
                else
                {
                    this[lev].Add(item);
                }
            }
        }
    }

}
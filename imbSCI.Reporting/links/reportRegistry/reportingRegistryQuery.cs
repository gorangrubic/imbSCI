namespace imbSCI.Reporting.links.reportRegistry
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;
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

    public class reportingRegistryQuery
    {

        public static Regex regex_levelExtract = new Regex(@"\$\$\$([\w]+)\:");
        public static Regex regex_pathExtract = new Regex(@"\:([\w\\]+)\$\$\$");


        /// <summary> </summary>
        public string reportLevelString { get; protected set; } = "none";


        /// <summary>
        /// Initializes a new instance of the <see cref="reportingRegistryQuery"/> class.
        /// </summary>
        /// <param name="__path">The path.</param>
        public reportingRegistryQuery(string __path)
        {

            if (regex_levelExtract.IsMatch(__path))
            {
                var m = regex_levelExtract.Match(__path);
                var n = regex_pathExtract.Match(__path);

                string mi = m.Groups[1].Value;
                needle = n.Groups[1].Value;

                //Object obj = Enum.Parse(typeof(reportElementLevel), mi) as reportElementLevel;
                reportElementLevel lev = reportElementLevel.none;
                Enum.TryParse(mi, out lev);
                
                if (lev != reportElementLevel.none)
                {
                    level = lev;
                }
                
            }
            else
            {
                var np = regex_pathExtract.Match(__path);
                needle = np.Groups[0].Value;
            }
        }


        /// <summary> </summary>
        public reportElementLevel level { get; protected set; } = reportElementLevel.none;


        /// <summary>
        /// Creates particular query
        /// </summary>
        /// <param name="__particularID">The particular identifier.</param>
        /// <param name="__needle">The needle.</param>
        public reportingRegistryQuery(string __particularID, string __needle)
        {
            kind = reportRegistryEnum.particular;
            needle = __needle;
            particularID = __particularID;
        }


        /// <summary> </summary>
        public reportRegistryEnum kind { get; set; }


        /// <summary> </summary>
        public string needle { get; set; }


        /// <summary> </summary>
        public string particularID { get; set; }
    }

}
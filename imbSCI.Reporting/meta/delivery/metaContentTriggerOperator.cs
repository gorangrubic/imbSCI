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

    /// <summary>
    /// Operator - the way <see cref="metaContentCriteriaTrigger"/> is evaluated together with other criterias within <see cref="metaContentCriteriaTriggerCollection"/>
    /// </summary>
    public enum metaContentTriggerOperator
    {

        /// <summary>
        /// This <c>trigger</c> will not affect evaluation
        /// </summary>
        ignore,

        /// <summary>
        /// This <c>trigger</c> alone will match if it is happy
        /// </summary>
        master,

        /// <summary>
        /// This <c>trigger</c> musn't be happy
        /// </summary>
        exclude,

        /// <summary>
        /// This <c>trigger</c> must be happy to allow match
        /// </summary>
        mustHave,

        /// <summary>
        /// This <c>trigger</c> will match if happy, if not happy others may decide
        /// </summary>
        mayHave,

    }

}
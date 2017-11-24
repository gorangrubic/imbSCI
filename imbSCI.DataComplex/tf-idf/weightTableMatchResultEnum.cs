namespace imbSCI.DataComplex
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using imbSCI.Core;
    using imbSCI.Core.attributes;
    using imbSCI.Core.collection;
    using imbSCI.Core.data;
    using imbSCI.Core.extensions.data;
    using imbSCI.Core.extensions.text;
    using imbSCI.Core.extensions.typeworks;
    using imbSCI.Core.interfaces;
    using imbSCI.Core.reporting;
    using imbSCI.Data.data;
    using imbSCI.Data.interfaces;

    [Flags]
    public enum weightTableMatchResultEnum
    {
        none=0,
        
        isMatch=1,
        isHostNameMatch = 2,

        isHostInstanceMatch = 4,

        isNeedleNameMatch = 8,

        isNeedleInstanceMatch = 16,

        /// <summary>
        /// The host term name and needle term name: Lemma to Lemma match, i.e. match by name
        /// </summary>
        hostTermName_and_needleTermName = isMatch | isHostNameMatch | isHostNameMatch,
        /// <summary>
        /// The host term name and needle term instance: Lemma to Instance match, i.e. match by semantic cloud
        /// </summary>
        hostTermName_and_needleTermInstance = isMatch | isHostNameMatch | isNeedleInstanceMatch,

        hostTermInstance_and_needleTermName = isMatch | isHostInstanceMatch | isNeedleNameMatch,

        hostTermInstance_and_needleTermInstance = isMatch | isHostInstanceMatch | isNeedleInstanceMatch,
    }

}
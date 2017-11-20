namespace imbSCI.Core.interfaces
{
    using System;
    using imbSCI.Core.math.measureSystem.enums;

    public interface IAceMathUnitDecadic {

        decadeLevel level { get; }

        /// <summary>
        /// Type of basic unit for the decade system
        /// </summary>
        /// <value>
        /// The decade base.
        /// </value>
        Type decadeBase { get; }

    }

}
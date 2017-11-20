namespace imbSCI.Core.math.measureSystem.systems
{
    using System;
    using System.Collections.Generic;
    using imbSCI.Core.math.measureSystem.enums;

    /// <summary>
    /// measure system registry
    /// </summary>
    /// <seealso cref="System.Collections.Generic.Dictionary{System.String, aceCommonTypes.math.measureSystem.measureDecadeSystem}" />
    public class measureDecadeSystemRegistry:Dictionary<string, measureDecadeSystem>
    {
        /// <summary>
        /// Adds the specified system.
        /// </summary>
        /// <param name="system">The system.</param>
        public void Add(measureDecadeSystem system)
        {
            Add(system.name, system);
        }
        /// <summary>
        /// Gets the <see cref="measureDecadeSystem"/> with the specified key.
        /// </summary>
        /// <value>
        /// The <see cref="measureDecadeSystem"/>.
        /// </value>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        /// <exception cref="System.Exception">System not found in the registry! "+key</exception>
        public new measureDecadeSystem this[String key]
        {
            get
            {
                if (!ContainsKey(key))
                {
                    throw new ArgumentOutOfRangeException(nameof(key), "System not found in the registry! "+key);
                }
                return base[key];
            }
            internal set
            {
                Add(key, value);
            }
        }

        /// <summary>
        /// Gets the <see cref="measureDecadeSystem"/> with the specified key.
        /// </summary>
        /// <value>
        /// The <see cref="measureDecadeSystem"/>.
        /// </value>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        public measureDecadeSystem this[measureSystemsEnum key]
        {
            get
            {
                return base[key.ToString()];
            }
            internal set
            {
                Add(key.ToString(), value);
            }
        }
    }

}
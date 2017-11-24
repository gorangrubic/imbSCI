namespace imbSCI.Core.reporting.style.shot
{
    using System;
    using imbSCI.Core.reporting.style.core;
    using imbSCI.Core.reporting.style.enums;
    using imbSCI.Data.enums.appends;

    /// <summary>
    /// Provider for text styling shots
    /// </summary>
    /// <seealso cref="aceCommonTypes.primitives.imbBindable" />
    public class styleTextShotProvider
    {
        protected styleTheme theme;

        public styleTextShotProvider(styleTheme _theme)
        {
            theme = _theme;
        }

        public styleTextShot getShotSet(appendRole role, appendType type=appendType.none)
        {
            String key = styleTextShot.getCodeName(role, type, theme);
            if (!shots.ContainsKey(key))
            {
                styleTextShot tmp = new styleTextShot(role, type, theme);
                shots.Add(key, tmp);
            }
            return shots[key];
        }

        protected styleTextShotCollection shots = new styleTextShotCollection();

    }

}
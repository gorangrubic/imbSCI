namespace imbSCI.Core.reporting.style.shot
{
    using System;
    using imbSCI.Core.reporting.style.core;
    using imbSCI.Core.reporting.style.enums;
    using imbSCI.Data.data;
    using imbSCI.Data.enums.appends;

    public class styleContainerShotProvider:imbBindable
    {
        protected styleTheme theme;

        public styleContainerShotProvider(styleTheme _theme)
        {
            theme = _theme;
        }

        public styleContainerShot getShotSet(appendRole role, appendType type = appendType.none)
        {
            String key = styleContainerShot.getCodeName(role, type, theme);
            if (!shots.ContainsKey(key))
            {
                styleContainerShot tmp = new styleContainerShot(role, type, theme);
                shots.Add(key, tmp);
            }
            return shots[key];
        }

        protected styleContainerShotCollection shots = new styleContainerShotCollection();
    }

}
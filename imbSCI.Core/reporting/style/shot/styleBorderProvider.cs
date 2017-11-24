namespace imbSCI.Core.reporting.style.shot
{
    using System;
    using imbSCI.Core.reporting.style.core;
    using imbSCI.Data.enums.appends;

    public class styleBorderProvider: styleContainerShotProvider
    {
        public styleBorderProvider(styleTheme _theme):base(_theme)
        {

        }

        public styleFourSide getShotSet(appendType type) //, appendType type = appendType.none)
        {
            String key = styleFourSide.getCodeName(type, theme);
            if (!shots.ContainsKey(key))
            {
                styleFourSide tmp = new styleFourSide(theme, type);
                shots.Add(key, tmp);
            }
            return shots[key];
        }

        internal styleBorderCollection shots = new styleBorderCollection();
    }

}
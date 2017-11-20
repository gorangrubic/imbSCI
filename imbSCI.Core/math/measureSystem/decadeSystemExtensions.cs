namespace imbSCI.Core.math.measureSystem
{
    using System;
    using imbSCI.Core.math.measureSystem.enums;
    using imbSCI.Core.extensions.enumworks;

    public static class decadeSystemExtensions
    {

        public static string toLetter(this decadeLevel level)
        {
            switch (level)
            {
                case decadeLevel.tera:
                    return "T";
                    break;
                case decadeLevel.giga:
                    return "G";
                    break;
                case decadeLevel.mega:
                    return "M";
                    break;
                case decadeLevel.kilo:
                    return "k";
                    break;
                case decadeLevel.hecto:
                    return "H";
                    break;
                case decadeLevel.none:
                    return "";
                    break;
                case decadeLevel.deci:
                    return "d";
                    break;
                case decadeLevel.centi:
                    return "c";
                    break;
                case decadeLevel.mili:
                    return "m";
                    break;
                case decadeLevel.micro:
                    return "µ";
                    break;
                case decadeLevel.nano:
                    return "n";
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public static string toPrefix(this decadeLevel level)
        {
            switch (level)
            {
                default:
                    return level.ToString();
                    throw new ArgumentOutOfRangeException();
            }
        }

        /// <summary>
        /// Gets the factor.
        /// </summary>
        /// <param name="to">To.</param>
        /// <returns></returns>
        public static Double toFactor(this decadeLevel to)
        {
            switch (to)
            {
                case decadeLevel.second:
                    return 1/360;
                    break;
                case decadeLevel.none:
                    return 1;
                    break;
                case decadeLevel.minute:
                    return 1/60;
                    break;
                case decadeLevel.oneOf12:
                    return 12;
                    break;
                case decadeLevel.oneOf24:
                    return 24;

                    break;
                case decadeLevel.oneOf365:
                    return 365;

                    break;
                default:

                    Int32 exp = to.ToInt32();
                    return Math.Pow(10, exp);
                    break;
            }
        }
    }

}
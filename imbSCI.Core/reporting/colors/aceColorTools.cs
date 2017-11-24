namespace imbSCI.Core.reporting.colors
{
    using imbSCI.Core.extensions.data;
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Default presets of HTML hex colors
    /// </summary>
    public static class aceColorTools
   {

        /// <summary>
        /// Gets the set of colors.
        /// </summary>
        /// <param name="preset">The preset.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentOutOfRangeException"></exception>
        public static List<String> getSetOfColors(this aceBaseColorSetEnum preset)
        {
            List<String> output = new List<string>();
            switch (preset)
            {
                case aceBaseColorSetEnum.aceBrightAndStrong:
                    output.AddMultiline(@"#FF8DD6D7
#FFFF8B43
#FFD78DD6
#FF88AFFE
#FF75FFAA
#FFE79799
");
                    break;
                case aceBaseColorSetEnum.aceCompany:
                    output.AddMultiline(@"#FF5BBBBE
#FFBE5BBB
#FFAA8FD2
#FFB3B3C1
#FFA3D28F
#FFE79899
");
                    break;
                case aceBaseColorSetEnum.imbScience:
                    output.AddMultiline(@"#FFB0DB24
#FF46C5EC
#FFADC694
#FF94ADC6
#FF99DEDD
#FFCBDCCB");

                    break;
                case aceBaseColorSetEnum.imbSemantics:
                    output.AddMultiline(@"#FF76FEB8
#FF28B3E6
#FFFE76DA
#FF8FA3D2
#FFA3D28F
#FFAA8FD2
");
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            return output;
        }

      
    }
}

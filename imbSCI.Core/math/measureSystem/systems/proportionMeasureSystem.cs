namespace imbSCI.Core.math.measureSystem.systems
{
    using imbSCI.Core.math.measureSystem.enums;

    /// <summary>
    /// Measure system for> percentage, permile, ratios
    /// </summary>
    /// <seealso cref="measureDecadeSystem" />
    public class proportionMeasureSystem : measureDecadeSystem
    {
        public proportionMeasureSystem():base(measureSystemsEnum.proportion)
        {
            AddRole(measureRoleEnum.progress, "P", "⤏");
            AddRole(measureRoleEnum.proportion, "p", ":");
            AddRole(measureRoleEnum.ratio, "r", "÷");
            //AddRole(measureRoleEnum.percent, "P", "÷");
            // AddRole(measureRoleEnum.page, "P", "⤏");

            AddUnit("", 0, "time", "times").setFormat("{0:#.00}", "{0:#.00}");
            AddUnit("", 0, "ratio", "ratio").setFormat("{0:0.0000}", "{0:0.0000}{1}");
            AddUnit("%", 0.01, "percent", "percents").setFormat("{0:#,##0.00}", "{0:#,##0.00} {1}");
            AddUnit("‰", 0.001, "promile", "primiles").setFormat("{0:#,##0.00}", "{0:#,##0.00} {1}");

            doFinalSetup();
        }
        
    }
}
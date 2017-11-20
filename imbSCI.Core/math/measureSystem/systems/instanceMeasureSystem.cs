namespace imbSCI.Core.math.measureSystem.systems
{
    using imbSCI.Core.math.measureSystem.enums;

    /// <summary>
    /// Measure system for> percentage, permile, ratios
    /// </summary>
    /// <seealso cref="measureDecadeSystem" />
    public class instanceMeasureSystem : measureDecadeSystem
    {
        public instanceMeasureSystem() : base(measureSystemsEnum.instance)
        {
            AddRole(instanceMeasureValueEnum.name, "P", "⤏");
            
            AddRole(measureRoleEnum.ratio, "r", "÷");
            //AddRole(measureRoleEnum.percent, "P", "÷");
            // AddRole(measureRoleEnum.page, "P", "⤏");

            AddUnit("", 0, "pc", "pcs").setFormat("{0:#}", "{0:#.00}");
            
        }

    }

}
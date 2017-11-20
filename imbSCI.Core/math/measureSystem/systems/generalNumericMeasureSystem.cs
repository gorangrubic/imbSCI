namespace imbSCI.Core.math.measureSystem.systems
{
    using imbSCI.Core.math.measureSystem.enums;

    public class generalNumericMeasureSystem : measureDecadeSystem
    {
        public generalNumericMeasureSystem() : base(measureSystemsEnum.generalNumeric)
        {
            AddRole(measureRoleEnum.numeric, "n", "#");
            AddRole(measureRoleEnum.items, "Ic", "№");
            AddRole(measureRoleEnum.taskCount, "Tc", "⋆");
            AddRole(measureRoleEnum.sampleCount, "Sc", "⎆");
            AddRole(measureRoleEnum.general, "c", "№");
            AddRole(measureRoleEnum.count, "c", "№").setFormat("{0:#,##0}", "{0:#,###} {1}");
            AddRole(measureRoleEnum.elementCount, "Ic", "№").setFormat("{0:#,##0}", "{0:#,###} {1}").setUnitSufixOverride("pcs");

            AddUnit("", 1, "number", "number").setFormat("{0:#,##0.###}", "{0:#,##0.###}{1}");
            AddUnit("", 1, "#", "#").setFormat("{0:#,##0}", "{0:#,##0}{1}");
            AddUnit("", 1, "pc", "pcs").setFormat("{0:#,##0}", "{0:#,##0} {1}");
            AddUnit("d", 10, "decade", "decades").setFormat("{0:#,##0.#}", "{0:#,##0.#}{1}");
            AddUnit("c", 100, "hundred", "hundreds").setFormat("{0:#,##0.#}", "{0:#,##0.#}{1}");
            AddUnit("k", 1000, "thousand", "thousands").setFormat("{0:#,##0.#}", "{0:#,##0.#}{1}");
            AddUnit("M", 1000000, "million", "millions").setFormat("{0:#,##0.#}", "{0:#,##0.#}{1}");
            AddUnit("B", 1000000000, "billion", "billions").setFormat("{0:#,##0.###}", "{0:#,##0.###}{1}");

            doFinalSetup();
        }

    }
}
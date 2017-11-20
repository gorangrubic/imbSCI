namespace imbSCI.Core.math.measureSystem.systems
{
    ///// <summary>
    ///// Measure system for: count, frequency, index (element out of elements), 
    ///// </summary>
    ///// <seealso cref="aceCommonTypes.math.measureSystem.measureDecadeSystem" />
    //public class countingMeasureSystem : measureDecadeSystem
    //{
    //    public countingMeasureSystem() : base(measureSystemsEnum.counting)
    //    {
    //        AddRole(measureRoleEnum.items, "Ic", "№");
    //        AddRole(measureRoleEnum.taskCount, "Tc", "⋆");
    //        AddRole(measureRoleEnum.sampleCount, "Sc", "⎆");
    //        AddRole(measureRoleEnum.general, "c", "№");

    //        AddUnit("", 0, "item", "items").setFormat("{0:#,###}", "{0:#,###}");
    //        AddUnit("k", 1000, "thousand", "thousands").setFormat("{0:#,###.#}", "{0:#,###.#}{1}");
    //        AddUnit("M", 1000000, "million", "millions").setFormat("{0:#,###.#}", "{0:#,###.#}{1}");
    //        AddUnit("B", 1000000000, "billion", "billions").setFormat("{0:#,###.000}", "{0:#,###.000}{1}");
    //    }
    //}

    public enum enumMeasureRoleEnum
    {
        single,
        flags,
        ordinalEnum,
    }

}
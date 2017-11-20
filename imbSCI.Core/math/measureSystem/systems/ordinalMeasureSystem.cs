namespace imbSCI.Core.math.measureSystem.systems
{
    using imbSCI.Core.math.measureSystem.enums;

    public class ordinalMeasureSystem : measureDecadeSystem
    {
        public ordinalMeasureSystem():base(measureSystemsEnum.ordinal)
        {
            AddRole(ordinalMeasureRole.order, "O", "#");
            AddRole(ordinalMeasureRole.rank, "R", "#");
            AddRole(ordinalMeasureRole.ID8, "ID", "#").setFormat("{0:0000-0000}", "{0:0000-0000}");

            AddUnit(".", 0, "", "").setFormat("{0:#,##0}", "{0:#,##0}{1}");
        }
    }

}
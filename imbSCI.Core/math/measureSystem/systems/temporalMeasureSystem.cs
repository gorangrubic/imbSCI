namespace imbSCI.Core.math.measureSystem.systems
{
    using imbSCI.Core.math.measureSystem.enums;

    /// <summary>
    /// System for time measurement
    /// </summary>
    /// <seealso cref="measureDecadeSystem" />
    public class temporalMeasureSystem : measureDecadeSystem
    {
        public temporalMeasureSystem() : base(measureSystemsEnum.period)
        {
            //AddRole(measureRoleEnum.date, "d", "⌚");
            //AddRole(measureRoleEnum.time, "t", "⌚");
            //AddRole(measureRoleEnum.datetime, "t", "⌚");
            AddRole(measureRoleEnum.period, "T", "⌛");
            AddRole(measureRoleEnum.duration, "T", "⌛");

            
            AddUnit("s", 0, "second", "seconds").setFormat("{0:#,##0.000}", "{0:#,##0.000}{1}");
            AddUnit(decadeLevel.mili).setFormat("{0:#,##0.000}", "{0:#,##0.000}{1}");
            AddUnit(decadeLevel.micro).setFormat("{0:#,##0.000}", "{0:#,##0.000}{1}");
            AddUnit(decadeLevel.nano).setFormat("{0:#,##0.000}", "{0:#,##0.000}{1}");
            
            AddUnit("m", 60, "minut", "minutes").setFormat("{0:#,##0.000}", "{0:#,##0.000}{1}");
            AddUnit("h", 3600, "hour", "hours").setFormat("{0:#,##0.000}", "{0:#,##0.000}{1}");
            AddUnit("d", 86400, "day", "days").setFormat("{0:#,##0.000", "{0:#,##0.000}{1}");
            AddUnit("M", 2592000, "month", "months").setFormat("{0:#,##0.000}", "{0:#,##0.000}{1}");
            AddUnit("Y", 31536000, "year", "years").setFormat("{0:#,##0.000}", "{0:#,##0.000}{1}");

            doFinalSetup();
        }
    }
}
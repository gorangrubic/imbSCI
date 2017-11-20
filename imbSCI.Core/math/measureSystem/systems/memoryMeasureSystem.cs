namespace imbSCI.Core.math.measureSystem.systems
{
    using imbSCI.Core.math.measureSystem.enums;

    public class memoryMeasureSystem:measureDecadeSystem
    {
        public memoryMeasureSystem():base(measureSystemsEnum.memory)
        {
            AddRole(measureRoleEnum.size, "size", "");
            AddRole(measureRoleEnum.available, "fmem", "");
            AddRole(measureRoleEnum.filesize, "s", "");
            
            AddUnit("b", 0, "byte", "bytes").setFormat("{0:#,###}", "{0:#,###}{1}");
            AddUnit("kb", 1024, "kilobyte", "kilobytes").setFormat("{0:#,###.#}", "{0:#,###.0##}{1}");
            AddUnit("mb", 1048576, "megabyte", "megabytes").setFormat("{0:#,###.#}", "{0:#,###.#}{1}");
            AddUnit("gb", 1073741824, "promile", "primiles").setFormat("{0:#,###.000}", "{0:#,###.000}{1}");

            doFinalSetup();
        }
   
    }
}
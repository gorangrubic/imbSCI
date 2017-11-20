namespace imbSCI.Core.math.measureSystem.systems
{
    using imbSCI.Core.math.measureSystem.enums;

    public class enumMeasureSystem:measureDecadeSystem
    {
        public enumMeasureSystem():base(measureSystemsEnum.enums)
        {

            AddRole(enumMeasureRoleEnum.single, "E", "");
            AddRole(enumMeasureRoleEnum.flags, "F", "");
            AddRole(enumMeasureRoleEnum.ordinalEnum, "S", "");

            AddUnit("", 0, "enum", "enums").setFormat("{0}", "{0}{1}");

            doFinalSetup();
        }
    }

}
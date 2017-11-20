namespace imbSCI.Core.math.measureSystem.systems
{
    using imbSCI.Core.math.measureSystem.enums;

    public class spatialMeasureSystem:measureDecadeSystem
    {
        public spatialMeasureSystem():base(measureSystemsEnum.spatial)
        {
            AddRole(measureRoleEnum.length, "l", "↔");
            AddRole(measureRoleEnum.height, "h", "");
            AddRole(measureRoleEnum.width, "w", "↔");
            AddRole(measureRoleEnum.diameter, "D", "↔");
            AddRole(measureRoleEnum.radius, "r", "↔");
            AddRole(measureRoleEnum.thickness, "T", "");

            AddUnit("m", 0, "meter", "meters");
            AddUnit(decadeLevel.deci);
            AddUnit(decadeLevel.centi);
            AddUnit(decadeLevel.mili);
            AddUnit(decadeLevel.micro);
            AddUnit(decadeLevel.kilo);
            AddUnit(decadeLevel.nano);
            doFinalSetup();

        }
    }
}
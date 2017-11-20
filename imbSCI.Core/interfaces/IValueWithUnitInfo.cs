namespace imbSCI.Core.interfaces
{
    using System;
    using imbSCI.Core.math.measureSystem.enums;

    public interface IValueWithUnitInfo
    {
        String unit_sufix { get; }
        String unit_name { get; }
        Double unit_factor { get; }
        measureUnitType unit_type { get; }
        Boolean unit_isUsingBaseValue { get; }
        
    }

}
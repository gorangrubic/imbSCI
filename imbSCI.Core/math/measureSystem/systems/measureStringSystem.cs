namespace imbSCI.Core.math.measureSystem.systems
{
    using System;
    using imbSCI.Core.math.measureSystem.enums;

    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="measureDecadeSystem" />
    public class measureStringSystem : measureDecadeSystem
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="measureStringSystem"/> class.
        /// </summary>
        public measureStringSystem() : base(measureSystemsEnum.text)
        {
            AddRole(measureStringRoleEnum.simple, "T", "⌨").setFormat("{0}", "'{0}'");

            AddRole(measureStringRoleEnum.tokenline, "S", "⎌").setFormat("{0}", "{0}", "-");
            AddRole(measureStringRoleEnum.wrapped, "W", "⌨").setFormat("{0}", "{0}", "-");

            AddRole(measureStringRoleEnum.trimmed, "t", "").setFormat("{0}", "{0}", "-");
            

            AddRole(measureStringRoleEnum.name, "ID", "").setFormat("{0}", "'{0}'");

            AddRole(measureStringRoleEnum.frequency, "frequency", "").setFormat("{0} ({1})", "{0} ({1})", Environment.NewLine);



            AddUnit(".", measureStringEnum.singleline).setFormat("{0}", "{0}");
            AddUnit(".", measureStringEnum.multiline).setFormat("{0}", "{0}");
            //AddUnit(measureStringEnum.xml).setFormat("{0}", "{0}");

            AddUnit(".", measureStringEnum.keyValue).setFormat("{0}", "{0}"); // ", 0, "keyValue", "keyValues").setFormat("{0}", "{0}({1})");
            //AddUnit()
        }
    }
}
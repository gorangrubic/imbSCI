namespace imbSCI.Core.math.measureSystem.core
{
    using imbSCI.Core.math.measureSystem.systems;

    public class measureInfo
    {

        internal void setup(measureSystemUnitEntry __unit, measureSystemRoleEntry __role, measureDecadeSystem __system)
        {
            system = __system;
            unit = __unit;
            role = __role;
        }

        private measureDecadeSystem _system;
        /// <summary>
        /// 
        /// </summary>
        public measureDecadeSystem system
        {
            get { return _system; }
            internal protected set { _system = value; }
        }



        private measureSystemUnitEntry _unitInfo;
        /// <summary>
        /// 
        /// </summary>
        public measureSystemUnitEntry unit
        {
            get { return _unitInfo; }
            internal protected set { _unitInfo = value; }
        }


        private measureSystemRoleEntry _role;
        /// <summary>
        /// 
        /// </summary>
        public measureSystemRoleEntry role
        {
            get { return _role; }
            internal protected set { _role = value; }
        }

    }

}
namespace imbSCI.Core.math.measureSystem.core
{
    using imbSCI.Core.enums;
    using imbSCI.Core.interfaces;
    using System;

    /// <summary>
    /// One element of calculation
    /// </summary>
    public class measureOperand
    {
        public measureOperand(String __operandName, operation __op)
        {
            operationWithOperand = __op;
            operandName = __operandName;
        }

        private operation _operationWithOperand = operation.none;
        /// <summary>
        /// 
        /// </summary>
        public operation operationWithOperand
        {
            get { return _operationWithOperand; }
            set { _operationWithOperand = value; }
        }



        private String _operandName = "";
        /// <summary>
        /// 
        /// </summary>
        public String operandName
        {
            get { return _operandName; }
            set { _operandName = value; }
        }



        private IMeasure _operand;
        /// <summary>
        /// 
        /// </summary>
        public IMeasure operand
        {
            get { return _operand; }
            set { _operand = value; }
        }

    }

}
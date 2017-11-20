namespace imbSCI.Core.math.measureSystem.core
{
    using imbSCI.Core.enums;
    using imbSCI.Core.interfaces;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// 
    /// </summary>
    public class measureOperandList
    {
        


        private List<measureOperand> _items = new List<measureOperand>();
        /// <summary>
        /// 
        /// </summary>
        public List<measureOperand> items
        {
            get { return _items; }
            set { _items = value; }
        }

        // public void reconnect(I)

        public IMeasure execute(IMeasure operandA)
        {
            IMeasure output = null;
            foreach (measureOperand mo in items)
            {
                output = output.calculate(mo.operand, mo.operationWithOperand) as IMeasure;
            }
            return output;
        }


        /// <summary>
        /// Adds the specified index.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <param name="opera">The opera.</param>
        /// <param name="__operand">The operand.</param>
        /// <returns></returns>
        public measureOperand Add(Int32 index, operation opera, IMeasure __operand)
        {
            var output = new measureOperand(__operand.name, opera);
            output.operand = __operand;

            if (index > items.Count() - 1) index = items.Count()-1;
            if (index < 0)
            {
                items.Add(output);
            }
            else
            {
                items.Insert(index, output);
            }
            return output;
        }

        /// <summary>
        /// Adds the specified index.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <param name="opera">The opera.</param>
        /// <param name="operandName">Name of the operand.</param>
        /// <returns></returns>
        public measureOperand Add(Int32 index, operation opera, String operandName)
        {
            var output = new measureOperand(operandName, opera);
            if (index > items.Count()-1) index = items.Count() - 1;
            if (index < 0)
            {
                items.Add(output);
            }
            else
            {
                items.Insert(index, output);
            }
            return output;
        }

       

    }

}
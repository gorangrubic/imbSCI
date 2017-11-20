namespace imbSCI.Core.math.measureUnit
{
    using System;

    public abstract class aceMathUnitBase<T> {

        protected abstract String format { get; }
        //public abstract String ToString();

        public virtual String ToString()
        {
            return String.Format(format, value);
        }

        internal T value = default(T);

    }

}
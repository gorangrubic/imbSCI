namespace imbSCI.Core.math
{
    using System;
    using System.Collections.Generic;

    public static class entropy
    {

        public static Double GetVariance(this IEnumerable<Double> rFreqs)
        {

            throw new NotImplementedException();
        }

        public static Double GetStdDeviation(this IEnumerable<Double> rFreqs)
        {

            throw new NotImplementedException();
        }

        /// <summary>
        /// Calculates entropy, normalizes the output if <c>normalize</c> is <c>true</c>
        /// </summary>
        /// <param name="rFreqs">Unsorted array of relative requencies. Relative requency is calculated as absolute freq. / max. freq. </param>
        /// <param name="eps">The eps.</param>
        /// <param name="normalize">if set to <c>true</c> [normalize].</param>
        /// <returns></returns>
        public static Double GetEntropy(this IEnumerable<Double> rFreqs, double eps = 0.000001, Boolean normalize=true)
        {
            double num1 = 0.0;
            double nl = 0;
            double nlMax = double.MinValue;

            foreach (double num2 in rFreqs)
            {
                nl = Math.Log(num2 + eps);
                if (normalize) nlMax = Math.Max(nl, nlMax);
                num1 += num2 * nl;
            }
            if (normalize) num1 = num1 / nlMax;
            return -num1;
        }
    }
}

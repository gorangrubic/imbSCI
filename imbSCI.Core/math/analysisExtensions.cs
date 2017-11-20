namespace imbSCI.Core.math
{
    using System;
    using System.Collections;

    public static class analysisExtensions
    {
        /// <summary>
        /// Clips to p: from -1 to 1
        /// </summary>
        /// <param name="input">The input.</param>
        /// <param name="minLimit">The minimum limit.</param>
        /// <param name="maxLimit">The maximum limit.</param>
        /// <returns></returns>
        public static Double ClipToP(this Double input, Double minLimit = -1, Double maxLimit = 1)
        {
            if (input < minLimit) input = minLimit;
            if (input > maxLimit) input = maxLimit;
            return input;
        }


        /// <summary>
        /// Clips to k: from 0 to 1
        /// </summary>
        /// <param name="input">The input.</param>
        /// <param name="minLimit">The minimum limit.</param>
        /// <param name="maxLimit">The maximum limit.</param>
        /// <returns></returns>
        public static Double ClipToK(this Double input, Double minLimit=0, Double maxLimit=1)
        {
            if (input < minLimit) input = minLimit;
            if (input > maxLimit) input = maxLimit;
            return input;
        }

        /// <summary>
        /// Gets the ratio of Counts between two <see cref="IList"/> collections
        /// </summary>
        /// <param name="part">The part.</param>
        /// <param name="whole">The whole.</param>
        /// <param name="ifPartIsZero">If part is zero.</param>
        /// <param name="ifWholeIsZeroAndPartNot">If whole is zero and part not.</param>
        /// <returns></returns>
        public static Double GetRatio(this IList part, IList whole, Double ifPartIsZero = 0.0F, Double ifWholeIsZeroAndPartNot = 1.0F) => GetRatio((Double)part.Count, (Double)whole.Count, ifPartIsZero, ifWholeIsZeroAndPartNot);




        /// <summary>
        /// Zero-input safe ratio calculation: part / whole
        /// </summary>
        /// <param name="part">The part - upper part of fraction equasion</param>
        /// <param name="whole">The whole - lower part of fraction equasion</param>
        /// <param name="ifPartIsZero">Value for case when <c>part</c> is 0</param>
        /// <param name="ifWholeIsZeroAndPartNot">Value for case when <c>whole</c> is 0 but part is not zero</param>
        /// <returns>Ratio from 0 to 1</returns>
        public static Double GetRatio(this Double part, Double whole, Double ifPartIsZero = 0.0F, Double ifWholeIsZeroAndPartNot = 1.0F)
        {

            Double output = 0;

            if (part == 0) return ifPartIsZero;
            if (whole == 0)
            {
                if (part > 0) return ifWholeIsZeroAndPartNot;
                return 0;
            }

            return (Double)part / whole;
        }

        /// <summary>
        /// Zero-input safe ratio calculation: part / whole
        /// </summary>
        /// <param name="part">The part - upper part of fraction equasion</param>
        /// <param name="whole">The whole - lower part of fraction equasion</param>
        /// <param name="ifPartIsZero">Value for case when <c>part</c> is 0</param>
        /// <param name="ifWholeIsZeroAndPartNot">Value for case when <c>whole</c> is 0 but part is not zero</param>
        /// <returns>Ratio from 0 to 1</returns>
        public static Double GetRatio(this Int32 part, Double whole, Double ifPartIsZero = 0.0F, Double ifWholeIsZeroAndPartNot = 1.0F) => GetRatio((Double)part, whole, ifPartIsZero, ifWholeIsZeroAndPartNot);


        /// <summary>
        /// Zero-input safe ratio calculation: part / whole
        /// </summary>
        /// <param name="part">The part - upper part of fraction equasion</param>
        /// <param name="whole">The whole - lower part of fraction equasion</param>
        /// <param name="ifPartIsZero">Value for case when <c>part</c> is 0</param>
        /// <param name="ifWholeIsZeroAndPartNot">Value for case when <c>whole</c> is 0 but part is not zero</param>
        /// <returns>Ratio from 0 to 1</returns>
        public static Double GetRatio(this Int32 part, Int32 whole, Double ifPartIsZero = 0.0F, Double ifWholeIsZeroAndPartNot = 1.0F) => GetRatio((Double)part, (Double)whole, ifPartIsZero, ifWholeIsZeroAndPartNot);
        
    }
}

#region USING



#endregion

namespace imbSCI.Core.math.range
{
    #region imbVeles using

    using System;
    using System.Collections.Generic;

    #endregion

    /// <summary>
    /// Matematički alat koji radi sa min-max skalom
    /// konvertuje apsolutni i relativni (ratio) broj
    /// </summary>
    public class imbNumberScale
    {
        /// <summary>
        /// Maksimalna vrednost u skali
        /// </summary>
        public Double maxValue = 100;

        /// <summary>
        /// Minimalna vrednost u skali
        /// </summary>
        public Double minValue = 0;

        /// <summary>
        /// Konstruktor koji postavlja min i max
        /// </summary>
        /// <param name="_min"></param>
        /// <param name="_max"></param>
        public imbNumberScale(Double _min, Double _max)
        {
            minValue = Math.Min(_min, _max);
            maxValue = Math.Max(_min, _max);
        }

        /// <summary>
        /// Konstruktor koji postavlja min i max ali iz Liste 
        /// pri čemu je 0 član min a 1 član max
        /// </summary>
        /// <param name="input"></param>
        public imbNumberScale(List<Double> input)
        {
            if (input.Count > 1)
            {
                minValue = input[0];
                maxValue = input[1];
            }
        }

        /// <summary>
        /// Vraća apsolutni broj za zadati racio
        /// koristeći postavljeni min-max raspon
        /// </summary>
        /// <param name="ratio">koeficijent na osnovu kojeg se dobija absolutni broj</param>
        /// <returns></returns>
        public Double getAbsoluteValue(Double ratio)
        {
            Double range = maxValue - minValue;
            Double output = minValue + (ratio*range);
            return output;
        }

        /// <summary>
        /// Vraća koeficijent na osnovu ranije definisanog raspona
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public Double getRatioValue(Double input)
        {
            Double over = input - minValue;
            Double ratio = over/maxValue;
            return ratio;
        }
    }
}
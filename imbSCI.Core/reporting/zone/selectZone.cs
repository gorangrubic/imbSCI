namespace imbSCI.Core.reporting.zone
{
    using System;

    public struct selectZone
    {
        public selectZone(Int32 _x, Int32 _y, Int32 _w, Int32 _h)
        {
            x = _x;
            y = _y;
            weight = _w;
            height = _h;
            //isDefined = true;
        }
        /// <summary>
        /// Horizontalna pozicija
        /// </summary>
        public Int32 x;
        /// <summary>
        /// Vertikalna pozicija
        /// </summary>
        public Int32 y;

        /// <summary>
        /// Sirina
        /// </summary>
        public Int32 weight;
        /// <summary>
        /// Visina
        /// </summary>
        public Int32 height;

        public Boolean isDefined
        {
            get { return (weight > 0); }
        }
    }
}
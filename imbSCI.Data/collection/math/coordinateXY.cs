namespace imbSCI.Data.collection.math
{
    using System;

    /// <summary>
    /// 2D selection information
    /// </summary>
    public class coordinateXY
    {
       
        private Int32 _x;
        /// <summary>
        /// x position
        /// </summary>
        public virtual Int32 x
        {
            get { return _x; }
            set { _x = value; }
        }


        private Int32 _y;
        /// <summary>
        /// 
        /// </summary>
        public virtual Int32 y
        {
            get { return _y; }
            set { _y = value; }
        }



        /// <summary>
        /// Initializes a new instance of the <see cref="coordinateXY"/> class.
        /// </summary>
        public coordinateXY()
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="coordinateXY"/> class.
        /// </summary>
        /// <param name="__x">The x.</param>
        /// <param name="__y">The y.</param>
        public coordinateXY(Int32 __x, Int32 __y)
        {
            x = __x;
            y = __y;
        }
    }

}
namespace imbSCI.Core.reporting.colors
{
    using imbSCI.Data.data;
    using System;
    using System.Drawing;
    using System.Drawing.Drawing2D;

    /// <summary>
    /// Containes one color/brush/gradient for particular purpose
    /// </summary>
    /// <seealso cref="aceCommonTypes.primitives.imbBindable" />
    internal class acePaletteShotPart : imbBindable
    {
        public acePaletteShotPart(Color inColor, Brush inBrush, String inHexColor, Int32 inIndex)
        {
            color = inColor;
            brush = inBrush;
            hexColor = inHexColor;
            index = inIndex;
        }


        private Int32 _index;
        /// <summary>
        /// 
        /// </summary>
        public Int32 index
        {
            get { return _index; }
            set { _index = value; }
        }


        private Color _color;
        /// <summary>
        /// Color
        /// </summary>
        public Color color
        {
            get { return _color; }
            set { _color = value; }
        }

        private Brush _brush;
        /// <summary>
        /// Solid Color Brush
        /// </summary>
        public Brush brush
        {
            get { return _brush; }
            set { _brush = value; }
        }


        private LinearGradientBrush _gradient;
        /// <summary>
        /// 
        /// </summary>
        public LinearGradientBrush gradient
        {
            get { return _gradient; }
            set { _gradient = value; }
        }


        private Color _bottomColor;
        /// <summary>
        /// 
        /// </summary>
        public Color bottomColor
        {
            get { return _bottomColor; }
            set { _bottomColor = value; }
        }


        private Color _topColor;
        /// <summary>
        /// 
        /// </summary>
        public Color topColor
        {
            get { return _topColor; }
            set { _topColor = value; }
        }




        private String _hexColor = "";
        /// <summary>
        /// Color in hexa decimal
        /// </summary>
        public String hexColor
        {
            get { return _hexColor; }
            set { _hexColor = value; }
        }


    }

}
namespace imbSCI.Core.reporting.colors
{
    using System;
    using System.Collections.Generic;
    using imbSCI.Core.reporting.style.shot;
    using imbSCI.Core.extensions.enumworks;
    using System.Drawing;
    using System.Drawing.Drawing2D;



    /// <summary>
    /// ShotSet is one particular styling situation delivered by <c>acePaletteProvider</c> containing color, brush and gradient for each ShotResEnum member
    /// </summary>
    /// <remarks>
    /// PaletteShotSet will be renderable as: a CSS block
    /// </remarks>
    /// <seealso cref="aceCommonTypes.primitives.imbBindable" />
    public class acePaletteShot:IStyleInstruction
    {


        /// <summary>
        /// Gets code name of the object. CodeName should be unique per each unique set of values of properties. In other words: if two instances of the same class have different CodeName that means values of their key properties are not same.
        /// </summary>
        /// <returns>
        /// Unique string to identify unique values
        /// </returns>
        public String getCodeName()
        {
            return name;
        }

        internal void addAcePaletteShot(acePaletteShotResEnum whatFor, Color inColor, Brush inBrush, LinearGradientBrush inGradient, Color inTopColor, Color inBottomColor)
        {
            String hexColor = ColorTranslator.ToHtml(inColor);
            acePaletteShotPart tmp = new acePaletteShotPart(inColor, inBrush, hexColor, whatFor.ToInt32());
            tmp.gradient = inGradient;
            tmp.topColor = inTopColor;
            tmp.bottomColor = inBottomColor;
            resources.Add(whatFor, tmp);
        }

        private String _name;
        /// <summary>
        /// Unique name for this palete delivery 
        /// </summary>
        public String name
        {
            get { return _name; }
            set { _name = value; }
        }
        
        internal Dictionary<acePaletteShotResEnum, acePaletteShotPart> resources = new Dictionary<acePaletteShotResEnum, acePaletteShotPart>();
        
        
        public Brush getBrush(acePaletteShotResEnum whatFor)
        {
            return resources[whatFor].brush;
        }

        public Color getColor(acePaletteShotResEnum whatFor)
        {
            return resources[whatFor].color;
        }
        public String getColorHex(acePaletteShotResEnum whatFor)
        {
            return resources[whatFor].hexColor;
        }
        public LinearGradientBrush getGradient(acePaletteShotResEnum whatFor)
        {
            return resources[whatFor].gradient;
        }
        public Color getColorTop(acePaletteShotResEnum whatFor)
        {
            return resources[whatFor].topColor;
        }
        public Color getColorBottom(acePaletteShotResEnum whatFor)
        {
            return resources[whatFor].bottomColor;
        }


    }

}
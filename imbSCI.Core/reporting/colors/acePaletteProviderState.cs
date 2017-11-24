

/// <summary>
/// Color management namespace
/// </summary>
namespace imbSCI.Core.reporting.colors
{
    using imbSCI.Core.extensions.math;
    using imbSCI.Core.extensions.typeworks;
    using imbSCI.Data.data;
    using System;

    /// <summary>
    /// Set of properties that drive variations in palette application.
    /// </summary>
    /// \ingroup_disabled report_ll
    /// <seealso cref="aceCommonTypes.primitives.imbBindable" />
    /// <seealso cref="System.ICloneable" />
    internal sealed class acePaletteProviderState:imbBindable, ICloneable
    {
        
        private Int32 _bgIndex = 0;
        /// <summary>
        ///  index pointing to background color/brush
        /// </summary>
        public Int32 bgIndex
        {
            get { return _bgIndex; }
            set { if (value < 0) return; _bgIndex = value; }
        }


        private Int32 _fgIndex;
        /// <summary>
        /// Foreground index
        /// </summary>
        public Int32 fgIndex
        {
            get { return _fgIndex; }
            set { if (value < 0) return; _fgIndex = value; }
        }


        private  Boolean _inverseState;
        /// <summary>
        /// Is foreground/background inversed?
        /// </summary>
        public  Boolean inverseState
        {
            get { return _inverseState; }
            set {  _inverseState = value; }
        }


        private acePaletteRole _active;
        /// <summary>
        /// What palette is currently active?
        /// </summary>
        public acePaletteRole active
        {
            get { return _active; }
            set { if (active == acePaletteRole.none) return; _active = value; }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="acePaletteProviderState"/> class.
        /// </summary>
        public acePaletteProviderState() { }


        /// <summary>
        /// Initializes a new instance of the <see cref="acePaletteProviderState"/> class.
        /// </summary>
        /// <param name="bg">The bg index</param>
        /// <param name="fg">The fg index</param>
        /// <param name="inverse">Inverse (bg/fg) state</param>
        /// <param name="act">Active palette</param>
        public acePaletteProviderState(Int32 bg, Int32 fg, Boolean inverse, acePaletteRole act)
        {
            bgIndex = bg;
            fgIndex = fg;
            inverseState = inverse;
            active = act;
        }


        /// <summary>
        /// Sets the specified parameters (if input is not> -1, unknown, none)
        /// </summary>
        /// <param name="bg">The bg.</param>
        /// <param name="fg">The fg.</param>
        /// <param name="inverse">if set to <c>true</c> [inverse].</param>
        /// <param name="act">The act.</param>
        public void set(Int32 bg, Int32 fg, Boolean inverse, acePaletteRole act = acePaletteRole.none)
        {
            bgIndex = bg;
            fgIndex = fg;
            inverseState = inverse;
            active = act;
        }

        /// <summary>
        /// Creates a new object that is a copy of the current instance.
        /// </summary>
        /// <returns>
        /// A new object that is a copy of this instance.
        /// </returns>
        public object Clone()
        {
            return new acePaletteProviderState(bgIndex, fgIndex, inverseState, active);   
        }




        /// <summary>
        /// Checks the indexes.
        /// </summary>
        /// <param name="ccount">The ccount.</param>
        internal void checkIndexes(Int32 ccount)
        {
            bgIndex.checkRange(ccount, 0, false);
            fgIndex.checkRange(ccount, 0, false);
        }

        /// <summary>
        /// Learns the specified source. Uses <see cref="imbSCI.Core.extensions.typeworks.imbTypeObjectOperations.setObjectBySource(object,object,string[])"/> for default implementation. 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source">The source.</param>
        public void Learn(Object source)
        {
            this.setObjectBySource(source);
        }
    }

}
namespace imbSCI.Core.reporting.style
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using imbSCI.Core.reporting.colors;
    using imbSCI.Core.reporting.style.core;
    using imbSCI.Core.reporting.style.enums;
    using imbSCI.Core.reporting.style.shot;
    using imbSCI.Core.extensions.data;
    using imbSCI.Data.enums.appends;

    /// <summary>
    /// 2017:Complete styling definition for one cell, div or whatever is the unit of styling
    /// </summary>
    public class styleShotSet:IStyleInstruction, IEnumerable
    {
        protected styleShotSet()
        {

        }
        public styleShotSet (appendRole role, appendType type, acePaletteVariationRole colorRole, acePaletteRole paletteRole, Boolean isInverse, styleTheme theme)
        {
            palette = theme.palletes.getShotSet(colorRole, isInverse, paletteRole);
            text = theme.textShotProvider.getShotSet(role, type);
            container = theme.styleContainerProvider.getShotSet(role, type);
        }

        public styleShotSet(styleContainerShot __container, styleTextShot __text, acePaletteShot __palette)
        {
            palette = __palette;
            text = __text;
            container = __container;

        }

        /// <summary>
        /// Performs an implicit conversion from <see cref="styleShotSet"/> to <see cref="styleContainerShot"/>.
        /// </summary>
        /// <param name="m">The m.</param>
        /// <returns>
        /// The result of the conversion.
        /// </returns>
        public static implicit operator styleContainerShot(styleShotSet m)
        {
            return m.container;
        }

        /// <summary>
        /// Performs an implicit conversion from <see cref="styleShotSet"/> to <see cref="styleTextShot"/>.
        /// </summary>
        /// <param name="m">The m.</param>
        /// <returns>
        /// The result of the conversion.
        /// </returns>
        public static implicit operator styleTextShot(styleShotSet m)
        {
            return m.text;
        }

        /// <summary>
        /// Performs an implicit conversion from <see cref="styleShotSet"/> to <see cref="acePaletteShot"/>.
        /// </summary>
        /// <param name="m">The m.</param>
        /// <returns>
        /// The result of the conversion.
        /// </returns>
        public static implicit operator acePaletteShot(styleShotSet m)
        {
            return m.palette;
        }

        /// <summary>
        /// Gets a value indicating whether this <c>styleShotSet</c> is ready, having all tree sub IStyleInstruction non null.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is ready; otherwise, <c>false</c>.
        /// </value>
        public Boolean isReady
        {
            get
            {
                return (container != null) && (text != null) && (palette != null);
            }
        }

        private styleContainerShot _container;
        /// <summary>
        /// 
        /// </summary>
        public styleContainerShot container
        {
            get { return _container; }
            set { _container = value; }
        }



        private styleTextShot _text;
        /// <summary>
        /// 
        /// </summary>
        public styleTextShot text
        {
            get { return _text; }
            set { _text = value; }
        }


        private acePaletteShot _palette;
        /// <summary>
        /// 
        /// </summary>
        public acePaletteShot palette
        {
            get { return _palette; }
            set { _palette = value; }
        }

        /// <summary>
        /// Gets the codename.
        /// </summary>
        /// <returns></returns>
        public string getCodeName()
        {
            return container.getCodeName() + text.getCodeName() + palette.getCodeName();
        }


        /// <summary>
        /// Returns an enumerator that iterates through sub shots.
        /// </summary>
        /// <returns>
        /// An <see cref="T:System.Collections.IEnumerator" /> object to iterate trough all sub style shots.
        /// </returns>
        public IEnumerator GetEnumerator()
        {
            List<IStyleInstruction> tempList = new List<IStyleInstruction>();
            tempList.AddMultiple(container, palette, text);

            return tempList.GetEnumerator();
        }
    }

}
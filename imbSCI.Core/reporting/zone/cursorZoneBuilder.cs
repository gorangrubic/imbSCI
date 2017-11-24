namespace imbSCI.Core.reporting.zone
{
    using imbSCI.Core.extensions.data;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Helps with constructing subzones inside target zone
    /// </summary>
    public class cursorZoneBuilder
    {


       

        /// <summary>
        /// Builder to create subzones in speficied target. Target is <see cref="cursorZoneBuilder"/> class
        /// </summary>
        /// <param name="__target">The target.</param>
        public cursorZoneBuilder(cursorZone __target)
        {
            target = __target;
            c = new cursor(__target, textCursorMode.scroll, textCursorZone.outterZone);

        }
        

        /// <summary>
        /// Builds the columns in targeted zone - respecting provided relative withs
        /// </summary>
        /// <param name="numberOfColumns">Number of columns to build inside the zone. Use small numbers.</param>
        /// <param name="relWidth">Relative width ratio for each column. If less is provided than <c>numberOfColumns</c> the rest of columns will have relWidth=1</param>
        /// <remarks>
        /// <para>Widths are relative to each other. If you want first column to be double in width than each of the other two use:  2,1,1</para>
        /// </remarks>
        public void buildColumns(Int32 numberOfColumns, params Int32[] relWidth)
        {
            List<Int32> widthList = relWidth.getFlatList<Int32>();
            
            Int32 widthsMissing = numberOfColumns - widthList.Count();
            if (widthsMissing > 0)
            {
                for (int i = 0; i < widthsMissing; i++)
                {
                    widthList.Add(1);
                }
            }

            Int32 widthTotal = widthList.Sum();

            if (widthTotal == 0)
            {
                throw new ArgumentOutOfRangeException(nameof(relWidth), "Total relative width is 0 -- ");
            }

            selectRange zw = c.selectToCorner(textCursorZoneCorner.Right);

            decimal widthUnit = Convert.ToDecimal(zw.x / widthTotal);

            c.moveToCorner(textCursorZoneCorner.Left);

            var zSize = c.selectZone();

            Int32 height = zSize.y;

            cursorZone sub = null;
            String key = "";

            foreach (Int32 cWidth in widthList)
            {
                sub = new cursorZone();
                sub.padding.Learn(target.padding);

                sub.margin.left = c.x;
                sub.margin.top = c.y;
                sub.margin.right = 0;
                sub.margin.bottom = 0;
                c.moveInDirection(textCursorZoneCorner.Right, Convert.ToInt32(Math.Ceiling(cWidth * widthUnit)));
                
                sub.width = c.x;
                sub.height = height;
                key = target.subzones.Add(cursorZoneRole.column, sub);
            }
            
            if (sub.innerRightPosition < target.innerRightPosition)
            {
                sub.width += (target.innerRightPosition - sub.innerRightPosition);
            }

        }

        private cursor _cursor;
        /// <summary>
        /// 
        /// </summary>
        protected cursor c
        {
            get { return _cursor; }
            set { _cursor = value; }
        }


        private cursorZone _target;
        /// <summary>
        /// 
        /// </summary>
        protected cursorZone target
        {
            get { return _target; }
            set { _target = value; }
        }


    }

}
namespace imbSCI.Core.reporting.zone
{
    using imbSCI.Core.extensions.text;
    using imbSCI.Data.interfaces;
    using System;

    /// <summary>
    /// Named entry of selectRangeArea, saved for lager use
    /// </summary>
    /// <seealso cref="selectRangeArea" />
    /// <seealso cref="imbSCI.Data.interfaces.IObjectWithPath" />
    /// <seealso cref="imbSCI.Data.interfaces.IObjectWithName" />
    public class selectRangeAreaNamed:selectRangeArea, IObjectWithPath, IObjectWithName
    {


        #region --- name ------- name, last part of path 
        private String _name;
        /// <summary>
        /// name, last part of path
        /// </summary>
        public String name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                OnPropertyChanged("name");
            }
        }
        #endregion


        #region --- path ------- its full path, including name 
        private String _path;
        /// <summary>
        /// its full path, including name
        /// </summary>
        public String path
        {
            get
            {
                return _path;
            }
            protected set
            {
                _path = value;
                OnPropertyChanged("path");
            }
        }
        #endregion


        

        /// <summary>
        /// Initializes a new instance of the <see cref="selectRangeAreaNamed"/> class.
        /// </summary>
        /// <param name="__path">The path.</param>
        /// <param name="x_st">The x st.</param>
        /// <param name="y_st">The y st.</param>
        public selectRangeAreaNamed(String __path, Int32 x_st, Int32 y_st):base(x_st, y_st, x_st+1, y_st+1)
        {
            path = __path;
            name = path.getPathVersion(-1, "\\", true);
            
        }

        /// <summary>
        /// Sets the start of Area
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        public void setStart(Int32 x, Int32 y)
        {
            TopLeft.x = x;
            TopLeft.y = y;
            resize(1, 1);
            isClosed = false;
        }

        /// <summary>
        /// Sets the end of Area and marks it as closed
        /// </summary>
        /// <param name="x_end">The x end.</param>
        /// <param name="y_end">The y end.</param>
        public void setEnd(Int32 x_end, Int32 y_end)
        {
            BottomRight.x = x_end;
            BottomRight.y = y_end;
            setToChanged();
            isClosed = true;
        }


        
        private Boolean _isClosed;
        /// <summary>
        /// TRUE if this area is closed, ready to be applied
        /// </summary>
        public Boolean isClosed
        {
            get
            {
                return _isClosed;
            }
            protected set
            {
                _isClosed = value;
                OnPropertyChanged("isClosed");
            }
        }

        public object parent
        {
            get
            {
                return null;
            }
        }
        

    }

}
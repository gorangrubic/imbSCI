using imbSCI.Data.data;

namespace imbSCI.Core.reporting.zone
{
    /// <summary>
    /// Settings about behaviour of cursor inside a zone
    /// </summary>
    /// <seealso cref="aceCommonTypes.primitives.imbBindable" />
    public class cursorZoneExecutionSettings:imbBindable
    {

 


        #region --- zoneChangeOnNewDocument ------- zone to be applied upod entering or creating new document 
        private textCursorZone _pageScopeInZone = textCursorZone.unknownZone;
        /// <summary>
        /// zone to be applied upod entering or creating new document
        /// </summary>
        public textCursorZone pageScopeInZone
        {
            get
            {
                return _pageScopeInZone;
            }
            set
            {
                _pageScopeInZone = value;
                OnPropertyChanged("zoneChangeOnNewDocument");
            }
        }
        #endregion



        #region --- cursorMode ------- Way that cursor should hangle vertical spacing 
        private textCursorMode _cursorMode = textCursorMode.scroll;
        /// <summary>
        /// Way that cursor should hangle vertical spacing
        /// </summary>
        public textCursorMode cursorMode
        {
            get
            {
                return _cursorMode;
            }
            set
            {
                _cursorMode = value;
                OnPropertyChanged("cursorMode");
            }
        }
        #endregion


        #region --- pageScopeInMove ------- Cursor move once new or existing page is scoped 
        private textCursorZoneCorner _pageScopeInMove = textCursorZoneCorner.UpLeft;
        /// <summary>
        /// Cursor move once new or existing page is scoped
        /// </summary>
        public textCursorZoneCorner pageScopeInMove
        {
            get
            {
                return _pageScopeInMove;
            }
            set
            {
                _pageScopeInMove = value;
                OnPropertyChanged("pageScopeInMove");
            }
        }
        #endregion




        #region --- scopeInMove ------- What movement of cursor it should do on scoping inside child MetaContent 
        private textCursorZoneCorner _scopeInMove = textCursorZoneCorner.Left;
        /// <summary>
        /// What movement of cursor it should do <c>just before</c> scoping inside child MetaContent
        /// </summary>
        public textCursorZoneCorner scopeInMove
        {
            get
            {
                return _scopeInMove;
            }
            set
            {
                _scopeInMove = value;
                OnPropertyChanged("scopeInMove");
            }
        }
        #endregion


        #region --- scopeOutMove ------- Bindable property 
        private textCursorZoneCorner _scopeOutMove = textCursorZoneCorner.Right;
        /// <summary>
        ///  What movement of cursor it should do <c>just before</c> scoping <c>outside</c> child MetaContent
        /// </summary>
        public textCursorZoneCorner scopeOutMove
        {
            get
            {
                return _scopeOutMove;
            }
            set
            {
                _scopeOutMove = value;
                OnPropertyChanged("scopeOutMove");
            }
        }
        #endregion

    }

}
namespace imbSCI.Data.data
{
    using System;

    /// <summary>
    /// Describes changes found by ObjectPathParentAndRootMonitor
    /// </summary>
    public class ObjectScopeChangeReport
    {

        private Boolean isChanged;
        private Boolean isPathChanged;
        private Boolean isRootChanged;
        private Boolean isTargetChanged;
        private Boolean isParentChanged;
        private Boolean isChildrenCountChanged;

        /// <summary>
        /// Gets or sets a value indicating whether this instance is path changed.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is path changed; otherwise, <c>false</c>.
        /// </value>
        public bool IsPathChanged
        {
            get
            {
                return isPathChanged;
            }

            set
            {
                if (isPathChanged != value) isChanged = true;
                isPathChanged = value;
            }
        }

        /// <summary>
        /// If any of properties was changed 
        /// </summary>
        public bool IsChanged
        {
            get
            {
                return isChanged;
            }

            set
            {
                isChanged = value;
            }
        }

        public bool IsRootChanged
        {
            get
            {
                return isRootChanged;
            }

            set
            {
                if (isRootChanged != value) isChanged = true;
                isRootChanged = value;
            }
        }

        public bool IsTargetChanged
        {
            get
            {
                return isTargetChanged;
            }

            set
            {
                if (isTargetChanged != value) isChanged = true;
                isTargetChanged = value;
            }
        }

        public bool IsParentChanged
        {
            get
            {
                return isParentChanged;
            }

            set
            {
                if (isParentChanged != value) isChanged = true;
                isParentChanged = value;
            }
        }

        public bool IsChildrenCountChanged
        {
            get
            {
                return isChildrenCountChanged;
            }

            set
            {
                if (isChildrenCountChanged != value) isChanged = true;
                isChildrenCountChanged = value;
            }
        }
    }

}
namespace imbSCI.Core.syntax.nc.line
{
    using System;
    using System.ComponentModel;

    /// <summary>
    /// Criteria, relative to the primary criteria
    /// </summary>
    public class ncLineRelativeCriteria:ncLineCriteria
    {

        #region -----------  relativePosition  -------  [Targeting relative position from the current ncLine. [0] is disabled, 1 is line after, -1 is line before, 5 is five lines after]
        private Int32 _relativePosition = 1; // = new Int32();
        /// <summary>
        /// Targeting relative position from the current ncLine. [0] is disabled, 1 is line after, -1 is line before, 5 is five lines after
        /// </summary>
        // [XmlIgnore]
        [Category("ncLineRelativeCriteria")]
        [DisplayName("Relative Position")]
        [Description("Targeting relative position from the current ncLine. [0] is disabled, 1 is line after, -1 is line before, 5 is five lines after")]
        public Int32 relativePosition
        {
            get
            {
                return _relativePosition;
            }
            set
            {
                // Boolean chg = (_relativePosition != value);
                _relativePosition = value;
                OnPropertyChanged("relativePosition");
                // if (chg) {}
            }
        }
        #endregion

        #region -----------  relativeType  -------  [Type of relative criteria: ]
        private ncLineRelativeCriteriaType _relativeType = ncLineRelativeCriteriaType.onExactPosition; // = new ncLineRelativeCriteriaType();
        /// <summary>
        /// Type of relative criteria: 
        /// </summary>
        // [XmlIgnore]
        [Category("ncLineRelativeCriteria")]
        [DisplayName("relativeType")]
        [Description("Type of relative criteria: [onExactPosition] tests against ncLine on exact relative position based on Relative Position value; [anywhereWithin] tests against all lines from the current to Relative Position, including line on Relative Position; [disabled] turns off this test")]
        public ncLineRelativeCriteriaType relativeType
        {
            get
            {
                return _relativeType;
            }
            set
            {
                // Boolean chg = (_relativeType != value);
                _relativeType = value;
                OnPropertyChanged("relativeType");
                // if (chg) {}
            }
        }
        #endregion
        
    }
}
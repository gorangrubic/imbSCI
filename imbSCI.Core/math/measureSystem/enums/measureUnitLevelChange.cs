namespace imbSCI.Core.math.measureSystem.enums
{
    /// <summary>
    /// Quality score of the current unit level
    /// </summary>
    public enum measureUnitLevelChange
    {
        
        /// <summary>
        /// The go lower
        /// </summary>
        goLower = -1,
        /// <summary>
        /// Nothing to change
        /// </summary>
        optimum = 0,
        /// <summary>
        /// Unit should be converted to higher level
        /// </summary>
        goHigher = 1,
    }

}
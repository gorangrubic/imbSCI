namespace imbSCI.Core.math
{
    /// <summary>
    /// Tip dogadjaja - za objekat: counter
    /// </summary>
    public enum counterEventType
    {
        unknown,
        error,
        /// <summary>
        /// Counter checked
        /// </summary>
        counterChecked,
        /// <summary>
        /// Counter limit is reached
        /// </summary>
        limitReached,
        /// <summary>
        /// Counter reset
        /// </summary>
        counterReset,
    }
}
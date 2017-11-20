namespace imbSCI.Core.math.measureUnit
{
    /// <summary>
    /// Decimal number with two decimals and thousants separation
    /// </summary>
    /// <seealso cref="aceCommonTypes.math.units.aceMathUnitBase{System.Decimal}" />
    public class money : aceMathUnitBase<decimal>
    {
        protected override string format
        {
            get
            {
                return "{0:0,0.00}";
            }
        }
    }

}
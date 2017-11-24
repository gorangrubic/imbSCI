namespace imbSCI.Data.collection.math
{
    /// <summary>
    /// Delegate that determinate value for a relationship between two items in the <see cref="aceRelationMatrix{TXAxis, TYAxis, TRelation}"/>
    /// </summary>
    /// <typeparam name="TXAxis">The type of the x axis.</typeparam>
    /// <typeparam name="TYAxis">The type of the y axis.</typeparam>
    /// <typeparam name="TRelation">The type of the relation.</typeparam>
    /// <param name="itemX">The item x.</param>
    /// <param name="itemY">The item y.</param>
    /// <returns>An object or value that describes the relation between <c>itemX</c> and <c>itemY</c></returns>
    public delegate TRelation aceRelationValue<TXAxis, TYAxis, TRelation>(TXAxis itemX, TYAxis itemY);
}
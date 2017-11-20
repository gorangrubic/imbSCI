namespace imbSCI.Data.collection.math
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TXAxis">The type of the x axis.</typeparam>
    /// <typeparam name="TYAxis">The type of the y axis.</typeparam>
    /// <typeparam name="TRelation">The type of the relation.</typeparam>
    public class aceRelationMatrixTriple<TXAxis, TYAxis, TRelation>
    {


        private TXAxis _itemX;
        /// <summary>
        /// 
        /// </summary>
        public TXAxis itemX
        {
            get { return _itemX; }
            set { _itemX = value; }
        }


        private TYAxis _itemY;
        /// <summary>
        /// 
        /// </summary>
        public TYAxis itemY
        {
            get { return _itemY; }
            set { _itemY = value; }
        }


        private TRelation _Value;

        
        /// <summary>
        /// 
        /// </summary>
        public TRelation Value
        {
            get { return _Value; }
            set { _Value = value; }
        }

        public aceRelationMatrixTriple(TXAxis __itemX, TYAxis __itemY, TRelation __Value) : base()
        {
            itemX = __itemX;
            itemY = __itemY;
            Value = __Value;
        }


    }

}
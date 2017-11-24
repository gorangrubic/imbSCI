namespace imbSCI.Data.collection.graph
{
    using System;
    using System.Collections.Generic;
    using imbSCI.Data.data.package;
    using imbSCI.Data.interfaces;

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TItem">The type of the item.</typeparam>
    /// <seealso cref="imbSCI.Data.data.package.dataPackage{TItem, aceCommonTypes.collection.nested.graphWrapNode{TItem}}" />
    public class graphDataPackage<TItem> : dataPackage<TItem, graphWrapNode<TItem>>  where TItem : class, IObjectWithName,  new()
    {
        public graphDataPackage() : base()
        {
        }



        public void Store(graphWrapNode<TItem> input, String path)
        {
            List<graphWrapNode<TItem>> chld = new List<graphWrapNode<TItem>>();
            input.getAllChildren().ForEach(x => chld.Add((graphWrapNode<TItem>)x));
            
            AddDataItems(chld, true);

            this.SaveDataPackage(path);
            
        }



        protected override string GetDataPackageID(graphWrapNode<TItem> wrapper)
        {
            return wrapper.path;
        }

        protected override TItem GetInstanceToPack(graphWrapNode<TItem> wrapper)
        {
            return wrapper.item;
        }
    }
}
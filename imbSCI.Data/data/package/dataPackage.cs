using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace imbSCI.Data.data.package
{
    using imbSCI.Data.collection.nested;


    /// <summary>
    /// Serializable data structure package container - base class
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class dataPackage<T, TWrapper>:dataPackageBase where TWrapper: class
        where T: class, new()
    {
        protected dataPackage()
        {
            xSer = new XmlSerializer(typeof(T));
        }


        



        //public static TPackage LoadDataPackage<TPackage>(String path) where TPackage: dataPackage<T, TWrapper>
        //{

        //}
       

        private aceConcurrentBag<dataItemContainer> _bagContent;
        /// <summary>
        /// Concurrent version of the <see cref="content"/>
        /// </summary>
        /// <value>
        /// The content of the bag.
        /// </value>
        private aceConcurrentBag<dataItemContainer> bagContent
        {
            get
            {
                if (_bagContent == null)
                {
                    _bagContent = new aceConcurrentBag<dataItemContainer>();
                    content.ForEach(x => _bagContent.Add(x));
                }
                return _bagContent;
            }
        }

        private XmlSerializer xSer;

        /// <summary>
        /// Makes or takes (unique or not) ID to assign to the item instance wrapped
        /// </summary>
        /// <param name="wrapper">Object that holds the instance</param>
        /// <returns>ID</returns>
        protected abstract String GetDataPackageID(TWrapper wrapper);

        /// <summary>
        /// Takes data item instance from the wrapper
        /// </summary>
        /// <param name="wrapper">Object that holds the instance</param>
        /// <returns>item that was held by the instance</returns>
        protected abstract T GetInstanceToPack(TWrapper wrapper);

        /// <summary>
        /// Serializes and stores an item into <see cref="content"/> collection. , before serialization it calls <see cref="IDataPackageItem.OnBeforeSave"/>
        /// </summary>
        /// <param name="wrapper">The wrapper to use for <see cref="dataItemContainer.id"/> and <see cref="dataItemContainer.instanceXml"/> creation</param>
        /// <param name="xmlSer">The XML serializer to use instead of its own.</param>
        /// <remarks>Makes the container using <see cref="GetInstanceToPack(TWrapper)"/> and <see cref="GetDataPackageID(TWrapper)"/>. Calls <see cref="IDataPackageItem.OnBeforeSave"/> between these two.</remarks>
        /// <returns></returns>
        protected virtual dataItemContainer AddDataItem(TWrapper wrapper, XmlSerializer xmlSer =null)
        {
            dataItemContainer iContainer = new dataItemContainer();
            T item = GetInstanceToPack(wrapper);

            if (item is IDataPackageItem)
            {
                IDataPackageItem item_IDataPackageItem = (IDataPackageItem)item;
                item_IDataPackageItem.OnBeforeSave();

            }


            
            iContainer.id = GetDataPackageID(wrapper);

            TextWriter writer = new StringWriter();
            if (xmlSer == null) xmlSer = xSer;

            xmlSer.Serialize(writer, item);
            writer.Close();

            iContainer.instanceXml = writer.ToString();

            content.Add(iContainer);
            return iContainer;
        }

        /// <summary>
        /// Gets the item.
        /// </summary>
        /// <param name="iContainer">The i container.</param>
        /// <returns></returns>
        protected virtual instanceItemContainer<T> GetItem(dataItemContainer iContainer)
        {
            XmlSerializer deserializer = new XmlSerializer(typeof(T));
            TextReader reader = new StringReader(iContainer.instanceXml);
            object obj = deserializer.Deserialize(reader);
            T output = (T)obj;
            reader.Close();

            return new instanceItemContainer<T>(iContainer.id, output);
        }

        /// <summary>
        /// Adds the data items.
        /// </summary>
        /// <param name="items">The items.</param>
        /// <param name="doInParaller">if set to <c>true</c> [do in paraller].</param>
        /// <returns></returns>
        protected aceConcurrentBag<dataItemContainer> AddDataItems(IEnumerable<TWrapper> items, Boolean doInParaller = true)
        {
            aceConcurrentBag<dataItemContainer> bag = new aceConcurrentBag<dataItemContainer>();
            
            if (doInParaller)
            {
                Parallel.ForEach(items, (i) =>
                {
                    bag.Add(AddDataItem(i));

                });
            
            }
            else
            {
                foreach (var i in items)
                {
                    bag.Add(AddDataItem(i));
                }

            }
            return bag;
        }


        /// <summary>
        /// Deserializes stored data
        /// </summary>
        /// <param name="doInParaller">if set to <c>true</c> [do in paraller].</param>
        /// <returns></returns>
        protected Dictionary<String, T> GetDataItems(Boolean doInParaller = true)
        {
            aceConcurrentBag<instanceItemContainer<T>> bag = new aceConcurrentBag<instanceItemContainer<T>>();
            Dictionary<String, T> output = new Dictionary<String, T>();

            if (doInParaller)
            {
                Parallel.ForEach(bagContent, (i) =>
                {

                    bag.Add(GetItem(i));

                });

            }
            else
            {
                foreach (var i in bagContent)
                {
                    bag.Add(GetItem(i));
                }
            }

            foreach (var i in bag)
            {
                output.Add(i.id, i.instance);
                if (i.instance is IDataPackageItem)
                {
                    IDataPackageItem item_IDataPackageItem = (IDataPackageItem)i.instance;
                    item_IDataPackageItem.OnLoaded();
                }

               
            }

            return output;
        }
        
    }




}

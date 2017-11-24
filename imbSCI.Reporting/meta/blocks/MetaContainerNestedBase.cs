namespace imbSCI.Reporting.meta.blocks
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using imbSCI.Reporting.interfaces;
    using imbSCI.Reporting.meta.core;
    using imbSCI.Core;
    using imbSCI.Core.attributes;
    using imbSCI.Core.collection;
    using imbSCI.Core.data;
    using imbSCI.Core.enums;
    using imbSCI.Core.extensions.data;
    using imbSCI.Core.extensions.io;
    using imbSCI.Core.extensions.text;
    using imbSCI.Core.extensions.typeworks;
    using imbSCI.Core.interfaces;
    using imbSCI.Core.reporting;
    using imbSCI.Core.reporting.render;
    using imbSCI.Data;
    using imbSCI.Data.data;
    using imbSCI.Data.enums;
    using imbSCI.Data.interfaces;
    using imbSCI.Reporting.delivery;
    using imbSCI.Reporting.interfaces;
    using imbSCI.Reporting.resources;
    using imbSCI.Reporting.script;
    using imbSCI.Core.reporting.format;
    using imbSCI.Core.reporting.colors;

    // using imbSCI.Reporting.meta.elements;

    /// <summary>
    /// Base class shared by page content elements and higher
    /// </summary>
    /// <seealso cref="MetaContentNestedBase" />
    public abstract class MetaContainerNestedBase: MetaContentNestedBase, IMetaComposeAndConstruct, IObjectWithPathAndChildSelector, IMetaBlock
    {
        //public override IMetaContentNested SearchForChild(string needle)
        //{
        //    needle = CleanNeedle(needle);
        //    if (this.name == needle) return this;
        //    //if (this.name.StartsWith(needle, StringComparison.CurrentCultureIgnoreCase)) return this;
        //    return null;
        //}

        public override reportElementLevel elementLevel
        {
            get
            {
                return reportElementLevel.block;
            }
        }


        private  string _title;
        /// <summary> </summary>
        public override string title
        {
            get
            {
                return _title;
            }
            set
            {
                _title = value;
                OnPropertyChanged("title");
            }
        }


        public override string logStructure(string prefix = "")
        {
            if (imbSciStringExtensions.isNullOrEmpty(prefix)) prefix = ":";

            string output = prefix;

            output = output.add(name);

            return output;
        }


        /// <summary>
        /// Collects internal data of this container.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns></returns>
        public virtual PropertyCollectionDictionary collect(PropertyCollectionDictionary data = null)
        {
            if (data == null) data = new PropertyCollectionDictionary();

            AppendDataFields(data[path]);

            delivery.deliveryInstance del = context as delivery.deliveryInstance;
            del.collectOperationStart(context, this, data);

            return data;
        }


        /// <summary>
        /// Performs construction (or upgrade) of DOM according to cpecific data set supplied.  
        /// </summary>
        /// <remarks>
        /// <para>This method is meant to be called just after constructor and before <c>compose</c> or other application method. </para>
        /// <para>It is not automatically called by constructor for easier prerequirements handling. </para>
        /// <para>Inside the method it is safe to access <c>parent</c>, <c>page</c>, <c>document</c> or any other automatic property.</para>
        /// <para>This method is meant to be called just once: it should remove any existing dynamically created nodes at beginning of execution - in purpose that any subsequent call produces the same result</para>
        /// </remarks>
        /// <param name="resources"></param>
        public abstract void construct(object[] resources); //compose(IMetaComposer composer, metaDocumentTheme theme, PropertyCollection data, params object[] resources)



        /// <summary>
        /// Composes a set of <c>docScriptInstruction</c> into supplied <c>docScript</c> instance or created blank new instance with <c>name</c> of this metaContainer
        /// </summary>
        /// <param name="script">The script.</param>
        public abstract docScript compose(docScript script=null);


        /// <summary>
        /// 
        /// </summary>
        public acePaletteRole colors { get; set; } = acePaletteRole.colorDefault;


        /// <summary>
        /// 
        /// </summary>
        public blockPosition position { get; set; }


        /// <summary>
        /// 
        /// </summary>
        public blockWidth width { get; set; }

        public virtual reportOutputForm form
        {
            get
            {
                return reportOutputForm.none;
            }
        }



        ///// <summary>
        ///// Gets child <see cref="IMetaContent"/> from the primary children collection using ordinance Int32 key
        ///// </summary>
        ///// <remarks>Better avoid this since ordinance key changes after <c>Sort()</c> invokation. Use String key better.
        ///// </remarks>
        ///// <value>
        ///// A <see cref="IMetaContent"/> child from the primary children collection (some IMetaContent classes have more than one children collection)
        ///// </value>
        ///// <param name="key">The key.</param>
        ///// <returns>A <see cref="IMetaContent"/> child from the primary children collection (some IMetaContent classes have more than one children collection)</returns>
        //public IMetaContent this[int key]
        //{
        //    get
        //    {
        //        return items[key];
        //    }
        //}



        ///// <summary>
        ///// Gets a <see cref="IMetaContent"/> child with <c>name</c> property matching the specified <c>key</c> value.
        ///// </summary>
        ///// <value>
        ///// <see cref="IMetaContent"/>
        ///// </value>
        ///// <param name="key">String <c>key</c> that match <c>name</c> property of wanted child</param>
        ///// <returns>Child member from primary children collection with <c>name</c> matching the <c>key</c></returns>
        //public IMetaContent this[String key]
        //{
        //    get
        //    {
        //        return items[key];
        //    }
        //}


        // public abstract IEnumerator GetEnumerator();



        //public override int indexOf(IMetaContent child)
        //{
        //    return items.IndexOf(child as MetaElementNestedBase);
        //}

        //public override int Count()
        //{
        //    return items.Count();

        //}


    }

}
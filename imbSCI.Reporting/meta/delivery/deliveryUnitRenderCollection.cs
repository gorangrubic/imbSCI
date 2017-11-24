namespace imbSCI.Reporting.meta.delivery
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
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

    /// <summary>
    /// Collection of renders
    /// </summary>
    /// <seealso cref="System.Collections.Generic.IEnumerable{imbSCI.Reporting.meta.delivery.deliveryUnit}" />
    /// <seealso cref="imbSCI.Reporting.reporting.render.IRender"/>
    public class deliveryUnitRenderCollection:IEnumerable<IRender>
    {
        /// <summary>
        /// Gets this instance.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T get<T>() where T:IRender, new() {

            IRender output = items.FirstOrDefault(x => x is T);
            if (output == null) output = new T();


            return (T)output;
        }

        /// <summary>
        /// Gets the text renders.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ITextRender> getTextRenders()
        {
            List<ITextRender> output = new List<ITextRender>();

            foreach (IRender r in items)
            {

                if (r is ITextRender)
                {
                    ITextRender r_ITextRender = (ITextRender)r;
                    output.Add(r_ITextRender);

                }
            }

            return output;
        }

        /// <summary>
        /// 
        /// </summary>
        protected List<IRender> items { get; set; } = new List<IRender>();


        IEnumerator IEnumerable.GetEnumerator() => items.GetEnumerator();

        public IEnumerator<IRender> GetEnumerator()
        {
            return ((IEnumerable<IRender>)items).GetEnumerator();
        }
    }

}
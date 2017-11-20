namespace imbSCI.Core.math.measurement
{
    using imbSCI.Core.collection;
    using imbSCI.Core.interfaces;
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// MeasureSet for external application
    /// </summary>
    public class measureSetExternal:measureSetBase
    {
        public measureSetExternal(Type target, String name, String desc):base(target, name, desc)
        {
            
        }

        ///// <summary>
        ///// Exports this instance.
        ///// </summary>
        ///// <returns></returns>
        //public PropertyCollectionExtendedList export(PropertyCollectionExtendedList output=null)
        //{
        //    if (output == null) output = new PropertyCollectionExtendedList();

        //    output.name = name;
        //    output.description = description;

        //    List<measureDisplayGroup> groups = this.displayGroups.export();

        //    foreach (measureDisplayGroup gr in groups)
        //    {
        //        PropertyCollectionExtended pce = new PropertyCollectionExtended();
        //        pce.name = gr.name;
        //        pce.description = gr.description;
        //        foreach (KeyValuePair<Int32, IMeasure> mes in gr)
        //        {
        //            IMeasure me = mes.Value;
        //            pce.Add(me.name, me);
        //        }
        //        output.Add(pce, pce.name, false);
        //    }

        //    return output;
        //}
    }
}
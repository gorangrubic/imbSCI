namespace imbSCI.Reporting.meta.delivery
{
    using System;
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
    using imbSCI.Core.reporting.style.enums;

    /// <summary>
    /// Criteriae to test <see cref="IMetaContentNested"/> against
    /// </summary>
    public class metaContentCriteriaTriggerCollection
    {
        /// <summary>
        /// 
        /// </summary>
        protected List<metaContentCriteriaTrigger> items { get; set; } = new List<metaContentCriteriaTrigger>();

        /// <summary>
        /// Evaluates the specified test content.
        /// </summary>
        /// <param name="testContent">Content of the test.</param>
        /// <param name="defaultOrLastResult">if set to <c>true</c> [default or last result].</param>
        /// <returns></returns>
        /// <remarks>
        /// <para>Results of multiple <see cref="metaContentCriteriaTrigger"/> instances within the collection are combined with associated <see cref="metaContentTriggerOperator"/> logic operators.</para>
        /// </remarks>
        public bool evaluate(IMetaContentNested testContent)
        {
            bool defaultOrLastResult = true;
            foreach (metaContentCriteriaTrigger trig in items)
            {
                defaultOrLastResult = trig.evaluate(testContent, defaultOrLastResult);
            }

            return defaultOrLastResult;
        }


        /// <summary>
        /// Adds new <see cref="metaContentCriteriaTrigger"/> match rule and its operator
        /// </summary>
        /// <param name="opera">The operator: how this criteria combines with others in this collection</param>
        /// <param name="pathCriteria">The path with <see cref="imbSCI.Data.extensions.data.imbPathExtensions.getChildByPath(IObjectWithChildSelector, string)"/> and to test if it returns the same IElement  </param>
        /// <param name="metaElementTypeToMatch">Type that test instance must be compatibile with</param>
        /// <param name="level">The level of element to test against</param>
        /// <param name="element">The element instance to test against</param>
        /// <returns></returns>
        public metaContentCriteriaTrigger AddCriteria(metaContentTriggerOperator opera, metaModelTargetEnum pathMatchRule = metaModelTargetEnum.scope, string pathCriteria = null, Type metaElementTypeToMatch = null, reportElementLevel level = reportElementLevel.none, IMetaContentNested element = null)
        {
            metaContentCriteriaTrigger trigger = new metaContentCriteriaTrigger();
            trigger.pathMatch = pathCriteria;
            trigger.type = metaElementTypeToMatch;
            trigger.level = level;
            trigger.element = element;
            trigger.triggerOperator = opera;
            trigger.pathMatchRule = pathMatchRule;
            items.Add(trigger);
            return trigger;
        }
    }

}
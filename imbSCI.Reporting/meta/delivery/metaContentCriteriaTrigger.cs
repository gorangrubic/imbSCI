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
    using imbSCI.Data.extensions.data;
    using imbSCI.Core.reporting.style.enums;

    /// <summary>
    /// Criteria to match an <see cref="IMetaContentNested"/>
    /// </summary>
    /// <remarks>
    /// <para>The <see cref="metaContentCriteriaTrigger"/> has multiple <c>OR</c> inner criteria-tests:</para>
    /// <para><see cref="type"/>, <see cref="level"/>, <see cref="element"/>, <see cref="pathMatch"/>  and <see cref="pathMatchRule"/></para>
    /// <para><see cref="evaluateSelf(IMetaContentNested)"/> returns result of these applying <c>OR</c> - <c>||</c> logic operator, the operator is immutable.</para>
    /// <para><see cref="evaluate(IMetaContentNested, bool)"/> is method used for <see cref="metaContentCriteriaTriggerCollection"/> evaluation.</para>
    /// <para>Results of multiple <see cref="metaContentCriteriaTrigger"/> instances within the collection are combined with associated <see cref="metaContentTriggerOperator"/> logic operators.</para>
    /// </remarks>
    public class metaContentCriteriaTrigger
    {

        /// <summary>
        /// Evaluates the specified test content.
        /// </summary>
        /// <param name="testContent">Content of the test.</param>
        /// <param name="defaultOrLastResult">if set to <c>true</c> [default or last result].</param>
        /// <returns></returns>
        /// <remarks>
        /// <para>Results of multiple <see cref="metaContentCriteriaTrigger"/> instances within the collection are combined with associated <see cref="metaContentTriggerOperator"/> logic operators.</para>
        /// </remarks>
        public bool evaluate(IMetaContentNested testContent, bool defaultOrLastResult)
        {
            bool output = defaultOrLastResult;
            switch (triggerOperator)
            {
                case metaContentTriggerOperator.exclude:
                    output = !evaluateSelf(testContent);
                    break;
                case metaContentTriggerOperator.ignore:
                    return defaultOrLastResult;
                    break;
                case metaContentTriggerOperator.master:
                    output = evaluateSelf(testContent);
                    break;
                case metaContentTriggerOperator.mayHave:
                    if (evaluateSelf(testContent)) output = true;
                    break;
                case metaContentTriggerOperator.mustHave:
                    if (evaluateSelf(testContent))
                    {
                        output = defaultOrLastResult;
                    } else
                    {
                        output = false;
                    }
                    break;
            }
            return output;
        }

        /// <summary>
        /// Evaluates it self - returns raw result without applying <see cref="triggerOperator"/>.
        /// </summary>
        /// <param name="testContent">Content of the test.</param>
        /// <returns>Returns <c>true</c> on first criteria matched, otherwise returns <c>false</c></returns>
        public bool evaluateSelf(IMetaContentNested testContent)
        {
            bool output = false;

            if (testContent == null) return false;

            if (type != null)
            {
                if (type.isCompatibileWith(testContent.GetType())) return true;
            }

            if (level != reportElementLevel.none)
            {
                if (level == testContent.elementLevel) return true;
            }

            if (element != null)
            {
                if (testContent == element) return true;
            }

            if (!pathMatch.isNullOrEmptyString())
            {
                IMetaContentNested match = testContent.getChildByPath(pathMatch) as IMetaContentNested;

                bool result = testContent.testScope(match, pathMatchRule);
                if (result) return true;

            }

            return output;
        }


        /// <summary>
        /// 
        /// </summary>
        public string uid { get; protected set; }


        internal metaContentCriteriaTrigger() : base()
        {
            uid = imbStringGenerators.getRandomString(16);
        }

        /// <summary>
        /// 
        /// </summary>
        internal metaContentTriggerOperator triggerOperator { get; set; } = metaContentTriggerOperator.ignore;


        /// <summary>
        /// After <see cref="pathMatch"/> retrieves a targeted <see cref="IMetaContentNested"/> it will be tested if it's inside defined <c>scope</c>
        /// </summary>
        internal metaModelTargetEnum pathMatchRule { get; set; } = metaModelTargetEnum.scope;


        /// <summary>
        /// RegexExpression to match <see cref="IMetaContentNested.path"/> against (path with name)
        /// </summary>
        internal string pathMatch { get; set; } = "";


        /// <summary>
        /// 
        /// </summary>
        internal Type type { get; set; } = null;


        /// <summary>
        /// 
        /// </summary>
        internal reportElementLevel level { get; set; } = reportElementLevel.none;


        /// <summary>
        /// 
        /// </summary>
        internal IMetaContentNested element { get; set; } = null;
    }

}
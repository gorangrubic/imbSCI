namespace imbSCI.Reporting.links.reportRegistry
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
    using imbSCI.DataComplex.data.modelRecords;

    /// <summary>
    /// Global tree content structure registar
    /// </summary>
    /// <seealso cref="System.Collections.Generic.IDictionary{System.String, imbSCI.Reporting.collections.reportRegistry.contentTreeDomainCollection}" />
    public abstract class recordVsReportRegistryBase
    {

        public ILogBuilder logger { get; protected set; }

        /// <summary>
        /// Makes the token.
        /// </summary>
        /// <param name="kind">The kind.</param>
        /// <param name="needle">The needle.</param>
        /// <returns></returns>
        protected virtual string makeToken(reportRegistryEnum kind, string needle)
        {
            string token = kind.ToString() + needle;
            return token;
        }

        /// <summary>
        /// Makes the token.
        /// </summary>
        /// <param name="forRecord">For record.</param>
        /// <returns></returns>
        protected abstract string makeToken(IModelRecord forRecord);

        /// <summary>
        /// Gets the report.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="forRecord">For record.</param>
        /// <returns></returns>
        public virtual T GetReport<T>(IModelRecord forRecord) where T:class
        {
            if (byRecord.ContainsKey(forRecord))
            {
                return byRecord[forRecord] as T;
            }
            return null;
        }

        public virtual IMetaContentNested GetReport(string token)
        {
            if (byToken.ContainsKey(token))
            {
                return byToken[token];
            } else
            {

                if (logger != null) logger.log("GetReport(" + token + ") failed! Token not found!");
                return null;
            }
        }

        public virtual IMetaContentNested GetReport(reportingRegistryQuery query)
        {
            string token = makeToken(query.kind, query.particularID + query.needle);
            return GetReport(token);
        }

        public virtual IMetaContentNested GetByRecord(IModelRecord record)
        {
            if (byRecord.ContainsKey(record)) {
                return byRecord[record];
            } else
            {

                return null;
            }
        }

        public virtual IModelRecord GetByReport(IMetaContentNested report)
        {
            if (byReport.ContainsKey(report))
            {
                return byReport[report];
            }
            else
            {

                return null;
            }
        }

        ///// <summary>
        ///// Gets the general report.
        ///// </summary>
        ///// <param name="needle">The needle.</param>
        ///// <returns></returns>
        //public virtual IMetaContentNested GetGeneralReport(String needle)
        //{
        //    String token = makeToken(reportRegistryEnum.general, needle);
        //    return GetReport(token);
        //}

        /// <summary>
        /// Gets the particular report.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="particularID">The particular identifier.</param>
        /// <param name="needle">The needle.</param>
        /// <returns></returns>
        public virtual T GetParticularReport<T>(string particularID, string needle) where T:class
        {
            string token = makeToken(reportRegistryEnum.particular, particularID + needle);
            if (byToken.ContainsKey(token))
            {
                return (T)byToken[token];
            }
            return null;
        }

        /// <summary>
        /// Registers the general.
        /// </summary>
        /// <param name="needle">The needle.</param>
        /// <param name="content">The content.</param>
        public virtual void registerGeneral(string needle, IMetaContentNested content)
        {
            string token = makeToken(reportRegistryEnum.general, needle);
            if (!byToken.ContainsKey(token))
            {
                byToken.Add(token, content);
            }
        }

        /// <summary>
        /// Registers the particular.
        /// </summary>
        /// <param name="particularID">The particular identifier.</param>
        /// <param name="needle">The needle.</param>
        /// <param name="content">The content.</param>
        public virtual void registerParticular(string particularID, string needle, IMetaContentNested content)
        {
            string token = makeToken(reportRegistryEnum.particular, particularID + needle);
            if (!byToken.ContainsKey(token))
            {
                byToken.Add(token, content);
            }
        }

        /// <summary>
        /// Registers the specified kind.
        /// </summary>
        /// <param name="kind">The kind.</param>
        /// <param name="needle">The needle.</param>
        /// <param name="content">The content.</param>
        public virtual void register(reportRegistryEnum kind, string needle, IMetaContentNested content)
        {
            string token = makeToken(kind, needle);
            if (!byToken.ContainsKey(token))
            {
                byToken.Add(token, content);
            }
        }

        /// <summary>
        /// Registers for record.
        /// </summary>
        /// <param name="record">The record.</param>
        /// <param name="content">The content.</param>
        public virtual void registerForRecord(IModelRecord record, IMetaContentNested content)
        {
            
           // String token = makeToken(record);
            byRecord.Add(record, content);
            //if (!byToken.ContainsKey(token))
            //{
            //    byToken.Add(token, content);
            //} else
            //{
            //    aceLog.log("Duplicate token in the registry: " + token);
            //}
            
        }

        //public T GetReport<T>(reportRegistryEnum type, )

        /// <summary>
        /// 
        /// </summary>
        protected Dictionary<IModelRecord, IMetaContentNested> byRecord { get; set; } = new Dictionary<IModelRecord, IMetaContentNested>();


        /// <summary>
        /// 
        /// </summary>
        protected Dictionary<IMetaContentNested, IModelRecord> byReport { get; set; } = new Dictionary<IMetaContentNested,IModelRecord>();


        /// <summary>
        /// 
        /// </summary>
        protected Dictionary<string, IMetaContentNested> byToken { get; set; } = new Dictionary<string, IMetaContentNested>();
    }

}
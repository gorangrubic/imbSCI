namespace imbSCI.DataComplex.data.modelRecords
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using imbSCI.Core;
    using imbSCI.Core.attributes;
    using imbSCI.Core.collection;
    using imbSCI.Core.data;
    using imbSCI.Core.extensions.data;
    using imbSCI.Core.extensions.text;
    using imbSCI.Core.extensions.typeworks;
    using imbSCI.Core.interfaces;
    using imbSCI.Core.reporting;
    using imbSCI.Data.data;
    using imbSCI.Data.interfaces;

    /// <summary>
    /// Model for Record that is allowed to be started and finished with direct call, have no childen -- use it for the end nodes
    /// </summary>
    /// <typeparam name="TInstance">The type of the instance.</typeparam>
    /// <seealso cref="modelRecordBase" />
    /// <seealso cref="IAppendDataFields" />
    /// <seealso cref="IAppendDataFieldsExtended" />
    /// <seealso cref="IModelRecord" />
    /// <seealso cref="aceCommonTypes.interfaces.IAutosaveEnabled" />
    /// <seealso cref="imbSCI.Core.interfaces.ILogable" />
    /// <seealso cref="IConsoleControl" />
    public abstract class modelRecordStandaloneBase<TInstance> : modelRecordBase, IAppendDataFields, IAppendDataFieldsExtended, IModelStandaloneRecord<TInstance>, IAutosaveEnabled, ILogable, IConsoleControl
        where TInstance : class, IObjectWithName, IObjectWithDescription, IObjectWithNameAndDescription
    {
        /// <summary>
        /// Sets testrunstamp and the instance referece <see cref="modelRecordStandaloneBase{TInstance}"/> class.
        /// </summary>
        /// <param name="__testRunStamp">The test run stamp.</param>
        /// <param name="__instance">The instance.</param>
        protected modelRecordStandaloneBase(string __testRunStamp, TInstance __instance) : base(__testRunStamp,__instance)
        {
            testRunStamp = __testRunStamp;
            instance = __instance;
        }

        private TInstance _instance;
        /// <summary> </summary>
        public TInstance instance
        {
            get
            {
                return _instance;
            }
            internal set
            {
                _instance = value;
                OnPropertyChanged("instance");
            }
        }


        private IModelParentRecord _parent;
        /// <summary> </summary>
        public IModelParentRecord parent
        {
            get
            {
                return _parent;
            }
            set
            {
                _parent = value;
                OnPropertyChanged("parent");
            }
        }


        /// <summary>
        /// Records the start. Make sure to call <see cref="_recordStart"/> at beginning of the method
        /// </summary>
        public abstract void recordStart(string __testRunStamp, string __instanceID, params object[] resources);


        /// <summary>
        /// Records the finish. Make sure to call <see cref="_recordFinish"/> at the end of the method
        /// </summary>
        public abstract void recordFinish(params object[] resources);


    }

}
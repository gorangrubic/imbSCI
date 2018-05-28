// --------------------------------------------------------------------------------------------------------------------
// <copyright file="modelRecordSummaryParentBase.cs" company="imbVeles" >
//
// Copyright (C) 2018 imbVeles
//
// This program is free software: you can redistribute it and/or modify
// it under the +terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
//
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
//
// You should have received a copy of the GNU General Public License
// along with this program.  If not, see http://www.gnu.org/licenses/. 
// </copyright>
// <summary>
// Project: imbSCI.DataComplex
// Author: Goran Grubic
// ------------------------------------------------------------------------------------------------------------------
// Project web site: http://blog.veles.rs
// GitHub: http://github.com/gorangrubic
// Mendeley profile: http://www.mendeley.com/profiles/goran-grubi2/
// ORCID ID: http://orcid.org/0000-0003-2673-9471
// Email: hardy@veles.rs
// </summary>
// ------------------------------------------------------------------------------------------------------------------
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

    public abstract class modelRecordSummaryParentBase<TInstance, TChildInstance, TChildRecord, TSideInstance, TSideRecord> : modelRecordParentBase<TInstance, TChildInstance, TChildRecord>, IModelRecordSummary<TSideInstance,TSideRecord>
        where TInstance : class, IObjectWithName, IObjectWithDescription, IObjectWithNameAndDescription
        where TChildInstance : class, IObjectWithName, IObjectWithDescription, IObjectWithNameAndDescription
        where TChildRecord : modelRecordBase, IModelStandalone
        where TSideRecord : modelRecordBase, IModelStandaloneRecord<TSideInstance>
    {

        public override modelRecordMode VAR_RecordModeFlags
        {
            get
            {
                return modelRecordMode.multiStarter | modelRecordMode.obligationDataSet | modelRecordMode.obligationBuildSummaryStatistics | modelRecordMode.summaryScope;
            }
        }

        public modelRecordSummaryParentBase(string __testRunStamp, TInstance __instance) : base(__testRunStamp, __instance)
        {
        }

        /// <summary>
        /// Finish this summary record
        /// </summary>
        public void summaryFinished()
        {
            _summaryFinished();
            _doOnRealFinish();
        }

        /// <summary>
        /// Boing to be executed before <see cref="modelRecordBase.datasetBuildOnFinish"/> and <see cref="modelRecordBase.datasetBuildOnFinishDefault"/>
        /// </summary>
        protected abstract void _summaryFinished();

        private modelSideRecordSetCollection<TSideInstance, TSideRecord> _sideRecordSets = new modelSideRecordSetCollection<TSideInstance, TSideRecord>();
        /// <summary> </summary>
        public modelSideRecordSetCollection<TSideInstance, TSideRecord> sideRecordSets
        {
            get
            {
                return _sideRecordSets;
            }
            protected set
            {
                _sideRecordSets = value;
                OnPropertyChanged("sideRecordSets");
            }
        }



        public virtual void AddSideRecord(TSideRecord __sideRecord)
        {
            
            sideRecordSets.AddRecord(__sideRecord.instance, __sideRecord);
        }

        public override void _recordFinish()
        {
            base._recordFinish();
            _doOnRealFinish();
        }
    }

}
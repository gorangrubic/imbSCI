﻿namespace imbSCI.DataComplex.data.dataUnits.core
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
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
    using imbSCI.DataComplex.exceptions;

    /// <summary>
    /// Base data unit for simple representation of an object, without being processed as table
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class dataUnitRow<TInstance>: INotifyPropertyChanged, IDataUnitSeriesEntry, IDataUnitRow
        where TInstance:class
    {


        private DateTime _rowCreated = new DateTime();
        /// <summary> </summary>
        public DateTime rowCreated
        {
            get
            {
                return _rowCreated;
            }
            protected set
            {
                _rowCreated = value;
                OnPropertyChanged("rowCreated");
            }
        }

        /// <summary>
        /// Time in minutes since last entry created
        /// </summary>
        /// <value>
        /// The since last minimum.
        /// </value>
        public double sinceLastMin
        {
            get
            {
                if (lastEntry == null) return 0;

                return rowCreated.Subtract(lastEntry.rowCreated).TotalMinutes;

            }
        }

        public dataUnitRow()
        {
            rowCreated = DateTime.Now;
        }

        public void prepare(dataUnitRowMonitoring __monitor, dataUnitBase __parent)
        {
            monitor = __monitor;
            parent = __parent;
        }

        public bool checkData(dataUnitRowMonitoring __monitor=null)
        {
            return monitor.checkData(this);
        }

        public abstract void setData(TInstance source);
        
        private dataUnitBase _parent;
        /// <summary> </summary>
        public dataUnitBase parent
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

        public IDataUnitSeriesEntry lastEntry
        {
            get
            {
                IdataUnitSeries series = parent as IdataUnitSeries;
                return series.lastEntry;
            }
        }


        private dataUnitRowMonitoring _monitor = new dataUnitRowMonitoring();
        /// <summary> </summary>
        protected dataUnitRowMonitoring monitor
        {
            get
            {
                return _monitor;
            }
            set
            {
                _monitor = value;
                OnPropertyChanged("monitor");
            }
        }


        private int _iteration;
        /// <summary>
        /// 
        /// </summary>
        public int iteration
        {
            get { return _iteration; }
            set {
                OnPropertyChanged("iteration");
                _iteration = value;
            }
        }

        /// <summary>
        /// Kreira event koji obaveštava da je promenjen neki parametar
        /// </summary>
        /// <remarks>
        /// Neće biti kreiran event ako nije spremna aplikacija: imbSettingsManager.current.isReady
        /// </remarks>
        /// <param name="name"></param>
        public void OnPropertyChanged(string name)
        {
            monitor.AddInstance(name, "OnPropertyChanged at dataUnitRow<TInstance>");
            if (monitor[name] > 1)
            {
                throw new dataException("dataUnitRow<" + typeof(TInstance).Name + "> changed property [" + name + "] [" + monitor[name] + "] times. Possible algorithm error  / overwrite.", null, this, "dataUnitRow field overwriten");
            }
            PropertyChangedEventHandler handler = PropertyChanged;

        }

        public event PropertyChangedEventHandler PropertyChanged;

    }

}
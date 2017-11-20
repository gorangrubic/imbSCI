using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace imbSCI.Data.data.package
{
    /// <summary>
    /// Interface for object instance that is used with <see cref="dataPackage{T, TWrapper}"/> serialization model
    /// </summary>
    public interface IDataPackageItem
    {
        /// <summary>
        /// Called before item is saved
        /// </summary>
        void OnBeforeSave();

        /// <summary>
        /// Called after item is loaded
        /// </summary>
        void OnLoaded();

    }

}
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
using imbSCI.Data;
using imbSCI.Data.data;
using imbSCI.Data.enums;
using imbSCI.Data.interfaces;

namespace imbSCI.Core.files.fileDataStructure
{
    using System.IO;
    using System.Reflection;

    /// <summary>
    /// Common base class for <see cref="fileDataPropertyDescriptor"/> and <see cref="fileDataStructureDescriptor"/>
    /// </summary>
    /// <seealso cref="IObjectWithNameAndDescription" />
    public abstract class fileDataDescriptorBase : IObjectWithNameAndDescription
    {

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public String name { get; set; } = "";

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public String description { get; set; } = "";



        /// <summary>
        /// Gets or sets the name or property path.
        /// </summary>
        /// <value>
        /// The name or property path.
        /// </value>
        public String nameOrPropertyPath { get; protected set; } = "";

        /// <summary>
        /// Gets or sets the filename mode.
        /// </summary>
        /// <value>
        /// The filename mode.
        /// </value>
        public fileDataFilenameMode filenameMode { get; protected set; } = fileDataFilenameMode.propertyValue;

        /// <summary>
        /// Gets or sets the mode.
        /// </summary>
        /// <value>
        /// The mode.
        /// </value>
        public fileDataPropertyMode formatMode { get; set; } = fileDataPropertyMode.autoTextOrXml;

        /// <summary>
        /// Resolved file name
        /// </summary>
        /// <value>
        /// The filename.
        /// </value>
        public String filename { get; protected set; }

        /// <summary>
        /// Descriptive information on the memberInfo
        /// </summary>
        /// <value>
        /// The s mi.
        /// </value>
        public settingsMemberInfoEntry memberMetaInfo { get; protected set; }

        public Type type { get; protected set; }

        //public Boolean typeIsDataStructure { get; protected set; }

        public fileDataPropertyOptions options { get; protected set; } = fileDataPropertyOptions.none;


        public abstract String GetFilepath(String path = "", IFileDataStructure instance = null, Boolean appendPathInOutput = false);


        /// <summary>
        /// Saves the data file.
        /// </summary>
        /// <param name="instance">The instance.</param>
        /// <param name="fullpath">The fullpath.</param>
        /// <param name="output">The output.</param>
        /// <param name="preventThrow">if set to <c>true</c> it will prevent throwing exception.</param>
        /// <exception cref="System.NotImplementedException">JSON not implemented yet
        /// or
        /// binary file not implemented yet</exception>
        protected void SaveDataFile(Object instance, String fullpath, ILogBuilder output=null, Boolean preventThrow=false)
        {
            fullpath = fullpath.getWritableFile(getWritableFileMode.overwrite).FullName;

            try
            {
                switch (formatMode)
                {
                    case fileDataPropertyMode.XML:
                        objectSerialization.saveObjectToXML(instance, fullpath);
                        break;
                    case fileDataPropertyMode.JSON:
                        throw new NotImplementedException("JSON not implemented yet");
                        break;
                    case fileDataPropertyMode.binary:
                        throw new NotImplementedException("binary file not implemented yet");
                        break;
                    case fileDataPropertyMode.text:
                        String text = "";// openBase.openFileToString(filepath, false);

                        if (type == typeof(List<String>))
                        {
                            List<String> list = (List<String>)instance;
                            text = list.toCsvInLine(ListStringSeparator);
                        }
                        else if (type == typeof(String))
                        {
                            text = instance as String;
                        }
                        else
                        {
                            throw new InvalidDataException("Format type [" + formatMode + "] not supported for type [" + type.Name + "] "+ "Format not supported - SaveDataFile");
                        }

                        text.saveStringToFile(fullpath, getWritableFileMode.overwrite);

                        break;
                }
            } catch (Exception ex) {

                //if (output == null && preventThrow) output = aceLog.loger;

                output.log("Error saving [" + fullpath + "] of type: " + instance.GetType().Name + " [" + ex.Message + "]");

                if (!preventThrow) throw;
            }
        }

        //public String ListStringSeparator = ";" + Environment.NewLine;


        private String _ListStringSeparator = ";" + Environment.NewLine;
        /// <summary>
        /// 
        /// </summary>
        public String ListStringSeparator
        {
            get { return _ListStringSeparator; }
            set { _ListStringSeparator = value; }
        }


        /// <summary>
        /// Loads the data file.
        /// </summary>
        /// <param name="filepath">The filepath.</param>
        /// <param name="output">The output.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException">
        /// JSON not implemented yet
        /// or
        /// binary file not implemented yet
        /// </exception>
        protected Object LoadDataFile(String filepath, ILogBuilder output=null, Type itemType=null)
        {
            Object instance = null;
            if (itemType == null) itemType = type;
            if (File.Exists(filepath))
            {

                switch (formatMode)
                {
                    case fileDataPropertyMode.XML:
                        instance = objectSerialization.loadObjectFromXML(filepath, itemType);
                        break;
                    case fileDataPropertyMode.JSON:
                        throw new NotImplementedException("JSON not implemented yet");
                        break;
                    case fileDataPropertyMode.binary:
                        throw new NotImplementedException("binary file not implemented yet");
                        break;
                    case fileDataPropertyMode.text:
                        String text = openBase.openFileToString(filepath, false);

                        if (type == typeof(List<String>))
                        {
                            instance = imbSciStringExtensions.SplitSmart(text, ListStringSeparator, "", false, true);
                        }
                        else if (type == typeof(String)) { 
                            instance = text;
                        } else {

                            throw new InvalidDataException("Format type [" + formatMode + "] not supported for type [" + type.Name + "]"+ "Format not supported - LoadDataFile");
                        }
                        
                        
                        break;
                }
            }
            else
            {
               // if (output == null) output = aceLog.loger;
                if (output != null) output.log("Loading [" + filepath + "] failed as file not found (" + itemType.Name + ")");


            }

            return instance;
        }


       


        /// <summary>
        /// Deploys the descriptor base.
        /// </summary>
        /// <param name="memberInfo">The member information.</param>
        /// <param name="attribute">The attribute.</param>
        /// <param name="instance">The instance.</param>
        protected void deployDescriptorBase(MemberInfo memberInfo, fileDataBaseAttribute attribute, Object instance=null)
        {
            filenameMode = attribute.filenameMode;
            nameOrPropertyPath = attribute.nameOrPropertyPath;
            options = attribute.options; 
            memberMetaInfo = new settingsMemberInfoEntry(memberInfo);

            name = memberMetaInfo.displayName.or(memberInfo.Name);
            description = memberMetaInfo.description;
            formatMode = attribute.formatMode;

            if (memberInfo is PropertyInfo)
            {
                PropertyInfo pi = memberInfo as PropertyInfo;
                type = pi.PropertyType;

                if (formatMode == fileDataPropertyMode.autoTextOrXml) {

                    if (type == typeof(String))
                    {
                        formatMode = fileDataPropertyMode.text;
                    } else if (type == typeof(List<String>))
                    {
                        if (options.HasFlag(fileDataPropertyOptions.itemAsFile))
                        {
                            formatMode = fileDataPropertyMode.text;
                        } else
                        {
                            formatMode = fileDataPropertyMode.XML;
                        }
                        
                    } else
                    {
                        formatMode = fileDataPropertyMode.XML;
                    }
                }

            } else if (memberInfo is Type)
            {
                type = memberInfo as Type;

                if (formatMode == fileDataPropertyMode.autoTextOrXml)
                {
                    formatMode = fileDataPropertyMode.XML;
                }
            }


            switch (filenameMode)
            {
                case fileDataFilenameMode.customName:
                    filename = attribute.nameOrPropertyPath;
                    break;
                case fileDataFilenameMode.memberInfoName:
                    filename = memberInfo.Name.getCleanFilepath("");
                    break;
                case fileDataFilenameMode.propertyValue:
                    if (instance != null)
                    {
                        PropertyExpression pexp = new PropertyExpression(instance, attribute.nameOrPropertyPath);
                        filename = pexp.getValue().toStringSafe(memberInfo.Name).getCleanFilepath("");

                    } else
                    {
                        filename = attribute.nameOrPropertyPath.getCleanFilepath("");
                    }
                    break;
            }
            
        }
    }

}
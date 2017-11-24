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
    using System.Collections;
    using System.IO;
    using System.Reflection;
    using imbSCI.Core.files.folders;

    /// <summary>
    /// Descriptor for a property within <see cref="fileDataStructure"/> class, defined by <see cref="fileDataAttribute"/>
    /// </summary>
    /// <seealso cref="fileDataDescriptorBase" />
    public class fileDataPropertyDescriptor:fileDataDescriptorBase
    {

        /// <summary>
        /// The willcard sufix added to filename, before extension
        /// </summary>
        public const String WILLCARD_SUFIX = "____";
        /// <summary>
        /// Gets the filepath. Optionally sets instance property if <see cref="path"/> contains filename. In the most cases you want to use this without parameters
        /// </summary>
        /// <param name="path">Optional target path information, may provide property value if <see cref="fileDataFilenameMode.propertyValue"/> mode is set</param>
        /// <param name="instance">Optionally, instance to set property value if <see cref="fileDataFilenameMode.propertyValue"/> mode is used</param>
        /// <param name="appendPathInOutput">if set to true it will use <paramref name="path"/> as prefix to output.</param>
        /// <returns>filename with extension, optionally full path with prefix <paramref name="path"/></returns>
        public override String GetFilepath(String path = "", IFileDataStructure instance = null, Boolean appendPathInOutput = false)
        {
            String filepath = "";
            switch (filenameMode)
            {
                case fileDataFilenameMode.memberInfoName:
                case fileDataFilenameMode.customName:
                    filepath = filename;
                    break;
                case fileDataFilenameMode.propertyValue:

                    filepath = Path.GetFileNameWithoutExtension(path);
                    path = path.getPathVersion(1, "\\");
                    if (instance != null)
                    {
                        PropertyExpression pexp = new PropertyExpression(instance, nameOrPropertyPath);
                        pexp.setValue(filename);
                    }
                    break;
                default:

                    // 
                    //throw new NotImplementedException("File Data Structure can't have filename by property value");
                    break;
            }

            if (options.HasFlag(fileDataPropertyOptions.itemAsFile))
            {
                filepath = filepath + WILLCARD_SUFIX;
            }


            filepath = filepath.ensureEndsWith(formatMode.GetExtension());

            if (appendPathInOutput) { path = path.add(filepath, "\\"); } else { path = filepath; }

            return path;
        }


        internal static Boolean doAutoInstanceOnSaveData = false;

        /// <summary>
        /// Saves the data for instance
        /// </summary>
        /// <param name="instance">The instance.</param>
        /// <param name="parentFolder">The parent folder.</param>
        /// <param name="output">The output.</param>
        /// <exception cref="imbACE.Core.core.exceptions.aceGeneralException">Type [" + memberMetaInfo.relevantTypeName + "] of property [" + memberMetaInfo.name + "] has no parameterless constructor. - null - Property [" + memberMetaInfo.name + "] is not new() type</exception>
        internal void SaveData(IFileDataStructure instance, folderNode parentFolder = null, ILogBuilder output = null)
        {
           // if (output == null) output = aceLog.loger;
            Boolean normalHandling = isNormalHandling();

            Object vl = instance.imbGetPropertySafe(memberMetaInfo.memberInfo as PropertyInfo, type.GetDefaultValue());

            
            if (vl == null)
            {
                if (doAutoInstanceOnSaveData)
                {
                    if (!type.hasParameterlessConstructor())
                    {
                        throw new InvalidOperationException("Type [" + memberMetaInfo.relevantTypeName + "] of property [" + memberMetaInfo.name + "] has no parameterless constructor, and the property value is null. SaveData failed for property [" + memberMetaInfo.name + "] that is not new() type");
                    }
                    else
                    {
                        vl = type.getInstance();
                        //vl = // // type.CreateInstance();
                    }
                } else
                {
                    return;
                }
            }

            String fp = GetFilepath("", instance, false);

            fp = parentFolder.pathFor(fp, getWritableFileMode.none);

            if (normalHandling)
            {
                               
                SaveDataFile(vl, fp, output);

            }
            else
            {
                IList vlList = vl as IList;
                if (vlList != null)
                {
                    Int32 i = 0;
                    foreach (Object item in vlList)
                    {
                        String pth = fp.Replace(WILLCARD_SUFIX, i.ToString("D4"));
                        SaveDataFile(item, pth, output);
                        i++;
                    }

                }

            }
        }

        private Boolean isNormalHandling()
        {
            Boolean normalHandling = true;
            Type interfaceType = type.GetInterface("IList");
            if (interfaceType != null)
            {
                if (options.HasFlag(fileDataPropertyOptions.itemAsFile))
                {
                    normalHandling = false;
                }
            }
            else
            {


            }
            return normalHandling;
        }

        internal void LoadDataAndSet(IFileDataStructure instance, folderNode parentFolder = null, ILogBuilder output = null)
        {
            
           // if (output == null) output = aceLog.loger;
            Boolean normalHandling = isNormalHandling();
           
            
            if (normalHandling)
            {
                String fp = GetFilepath("", instance, false);
                fp = parentFolder.pathFor(fp, getWritableFileMode.none);
                Object vl = LoadDataFile(fp, output, type);
                if (vl == null)
                {
                    PropertyInfo pi = memberMetaInfo.memberInfo as PropertyInfo;
                    vl = pi.PropertyType.getInstance();
                }
                instance.imbSetPropertySafe(memberMetaInfo.memberInfo as PropertyInfo, vl, true);
            } else
            {
                IList vlList = type.getInstance() as IList;
                Type itemType = type.GetGenericArguments().FirstOrDefault();
                String fpattern = GetFilepath("", instance, false);

                List<String> found = parentFolder.findFiles(fpattern, System.IO.SearchOption.TopDirectoryOnly);

                foreach (String fnd in found)
                {
                    if (File.Exists(fnd))
                    {
                        vlList.Add(LoadDataFile(fnd, output, itemType));

                    } else
                    {
                        output.log("File previously detected [" + parentFolder.path + " with " + fpattern + "] can't be found !");
                    }
                }

                instance.imbSetPropertySafe(memberMetaInfo.memberInfo as PropertyInfo, vlList, true);
            }
        }



      //  public fileDataPropertyMode mode { get; protected set; } = fileDataPropertyMode.autoTextOrXml;



        public fileDataPropertyDescriptor(PropertyInfo memberInfo, fileDataAttribute attribute, Object instance)
        {
            deployDescriptor(memberInfo, attribute, instance);
        }


        internal void deployDescriptor(PropertyInfo memberInfo, fileDataAttribute attribute, Object instance)
        {

            deployDescriptorBase(memberInfo, attribute, instance);
        }
        
    }

}
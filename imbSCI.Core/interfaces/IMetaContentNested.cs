namespace imbSCI.Core.interfaces
{
    using System.Collections.Generic;
    using imbSCI.Data.interfaces;
    using imbSCI.Core.reporting.template;
    using imbSCI.Core.reporting;
    using imbSCI.Core.reporting.render;
    using imbSCI.Core.reporting.style.enums;

    /// <summary>
    /// Interaface for all metaContent model classes
    /// </summary>
    public interface IMetaContentNested: IObjectWithIDandName, IObjectWithParent, IObjectWithPath, IObjectWithChildSelector, IAppendDataFields, IObjectWithPathAndChildSelector,IObjectWithReportLevel, IObjectWithNameAndDescription
    {
      //  MetaContentNested SearchForChild(String needle);

        string title { get; set; }

        string description { get; set; }


        /// <summary>
        /// Number of child items
        /// </summary>
        /// <returns></returns>
        int Count();

        /// <summary>
        /// Sorts children in ascending order using id/priority information
        /// </summary>
        void sortChildren();

        /// <summary>
        /// checks if this instance is page closest to document
        /// </summary>
        bool isThisRootPage { get; }

        /// <summary>
        /// checks if this instance is DocumentSet
        /// </summary>
        bool isThisRoot { get; }

        /// <summary>
        /// checks if this instance is Document 
        /// </summary>
        bool isThisDocument { get; }


        /// <summary>
        /// Is visibility changed?
        /// </summary>
        /// <param name="newValue">Value of visibility to be set</param>
        /// <returns></returns>
        bool setVisibility(bool newValue);

        /// <summary>
        /// Path from root object to this object - including this
        /// </summary>
        string path { get; }

        /// <summary>
        /// Reference to top parent object
        /// </summary>
        IMetaContentNested root { get; }


        /// <summary>
        /// reference to root context reference
        /// </summary>
        /// <value>
        /// The context.
        /// </value>
        IRenderExecutionContext context { get; set; }


        string logStructure(string prefix = "");

        /// <summary>
        /// getChild by path
        /// </summary>
        /// <param name="path">The path.</param>
        /// <returns></returns>
        //IMetaContent getChild(String path);

        /// <summary>
        /// Make relative path to target object
        /// </summary>
        /// <param name="target">The target.</param>
        /// <returns></returns>
        // String getPathTo(IMetaContent target);

        // String getPathToParent(IMetaContent target, String prefix = "");

        ///// <summary>
        ///// Child selector by <c>name</c> <see cref="IMetaContent"/> - one-layer deep
        ///// </summary>
        ///// <value>
        ///// The <see cref="IMetaContent"/>.
        ///// </value>
        ///// <param name="name">The name.</param>
        ///// <returns>Direct child from primary collection</returns>
      //  IMetaContent this[String name] { get; }


        /// <summary>
        /// Reference to containing page -- first page in parent hierarchy
        /// </summary>
        IMetaContentNested page { get; }


        /// <summary>
        /// Reference to containing document -- first document in parent hierarchy
        /// </summary>
        IMetaContentNested document { get; }



        /// <summary>
        /// reference to item parent object
        /// </summary>
        IMetaContentNested parent { get; set; }

        /// <summary>
        /// Text content of the meta item. For headers it is written below description block. For footers it comes before bottomline
        /// </summary>
// [XmlIgnore]
        List<string> content { get; set; }

        /// <summary>
        /// Priority defines order of blocks
        /// </summary>
        int priority { get; set; }

        /// <summary>
        /// Controls render visibility of the content block
        /// </summary>
        bool visible { get; set; }

        List<IMetaContentNested> resolve(metaModelTargetEnum target, string needle, IMetaContentNested output);

        // string relPathToParent(IMetaContent target, string prefix);
    }
}
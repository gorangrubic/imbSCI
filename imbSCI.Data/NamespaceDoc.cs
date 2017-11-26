using System;
using System.Linq;
using System.Collections.Generic;
namespace imbSCI.Data
{
    using imbSCI.Data.collection.graph;
    using imbSCI.Data.data.package;
    using imbSCI.Data.extensions.data;
    using System.Collections;
    using System.Text.RegularExpressions;


    /// <summary>
    /// The namespace provides the core layer of shared: enumerations, interfaces and extensions as well as a number of thread-safe collections and data structures.
    /// </summary>
    /// <remarks>
    /// <para>The main purpose of this library is to basic set of building blocks, shared by wide range of imbVeles projects.</para>
    /// <para>Here are thread-safe multidimensional collections and dictionaries consumed on many layers of the imbSCI and imbACE frameworks.</para>
    ///   <list type = "bullet" >
    ///     <listheader>
    ///         <term>Namespace overview</term>
    ///         <description>Brief description on key features of the imbSCI.Core namespace</description>
    ///     </listheader>
    ///     <item>
    ///         <term>Extensions for: <see cref="String"/>s, <see cref="Enum"/>s, directed <see cref="graph"/>s, and paths (<see cref="imbPathExtensions"/>)</term>
    ///         <description>Very elementary extension methods, performing the most frequent operations.</description>
    ///     </item>
    ///     <item>
    ///         <term><see cref="imbSCI.Data.data"/>: fundamentals</term>
    ///         <description>Bindable primitives, <see cref="Regex"/>-based string parsers, complex data-structure load/save mechanism and <see cref="Type"/> to <see cref="Type"/> property auto-mappings</description>
    ///     </item>
    ///     <item>
    ///         <term><see cref="imbSCI.Data.collection"/>: multidimensional and thread-safe</term>
    ///         <description>Generic and non-generic directed graph, layered stacks, 2D+ relational matrices, dictionaries...</description>
    ///     </item>
    ///     <item>
    ///         <term>Common <see cref="imbSCI.Data.enums"/> and <see cref="imbSCI.Data.interfaces"/></term>
    ///         <description>Mostly revolving around reporting, data annotation and core framework options</description>
    ///     </item>
    /// </list>
    /// </remarks>
    /// <example>
    ///     Several extensions, combined for textual representation of all flags in specified Enum <c>en</c>.
    ///     <code>
    ///     String output = "";       
    ///     foreach (Enum eni in en.getEnumListFromFlags()) {
    ///         output = output.add(eni.toStringSafe().imbTitleCamelOperation(), ", ");
    ///     }
    ///     </code>
    /// </example>
    /// <seealso>
    /// <para>Few recommended namespace members to learn more about</para>
    /// <see cref="imbSCI.Data.imbSciEnumExtensions.getEnumListFromFlags(Enum)"/>
    /// <see cref="imbSCI.Data.collection.graph.graphWrapNode{TItem}"/>
    /// <see cref="imbSCI.Data.imbGraphExtensions.getDeepest(IEnumerable{interfaces.IObjectWithPathAndChildren}, int)"/>
    /// <see cref="imbSCI.Data.imbGraphExtensions.getFilterOut(IEnumerable{interfaces.IObjectWithPathAndChildren}, System.Text.RegularExpressions.Regex, System.Text.RegularExpressions.Regex)"/>
    /// <see cref="imbSCI.Data.extensions.data.imbPathExtensions.getPathTo(interfaces.IObjectWithPathAndChildSelector, interfaces.IObjectWithPathAndChildSelector)"/>
    /// <see cref="imbSCI.Data.data.changeBindableBase"/>
    /// <see cref="imbSCI.Data.data.maps.mapping.propertyMappingTools.getValuesFromMappedSource(object, data.maps.mapping.propertyMap)"/>
    /// <see cref="imbSCI.Data.collection.nested.aceEnumDictionarySet2D{TEnum, TD1Key, TD2Key, TValue}"/>
    /// </seealso>
    public class NamespaceDoc
    {

    }

}
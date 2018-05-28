using System;
using System.Linq;
using System.Collections.Generic;
namespace imbSCI.Core.attributes
{
    using imbSCI.Core.math.range;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;


    /// <summary>
    /// <para>Extensive Scientific Data annotation-purpose tools.</para>
    /// </summary>
    /// <remarks>
    /// <para>The <see cref="imbAttribute"/> is used to declare meta information for data agregation, reporting, user-help content creation and similar.</para>
    /// <list>
    /// 	<listheader>
    ///			<term>Key points</term>
    ///		</listheader>
    ///		<item>
    ///			<term>Declare meta annotation for your classes</term>
    ///			<description>Use <see cref="imbAttribute"/> with <see cref="imbAttributeName"/> te control table/column format and legend-content of a property or whole class</description>
    ///		</item>
    ///		<item>
    ///			<term>Aggregate data</term>
    ///			<description>Use <see cref="imbSCI.Core.extensions.table"/> and <see cref="imbSCI.Core.extensions.data"/> to aggregate data</description>
    ///		</item>
    ///		<item>
    ///			<term>Generate spreadsheet reports</term>
    ///			<description>Use <see cref="imbSCI.DataComplex.tables"/> to easly generate feature rich Excel, CSV... reports from object collections</description>
    ///		</item>
    ///		<item>
    ///			<term>Generate text reports</term>
    ///			<description>Use <see cref="imbSCI.Core.data.settingsEntriesForObject"/> to generate textual description of your (setup, or data report summaries) objects</description>
    ///		</item>
    /// </list>
    /// <example>
    /// .NET Framework's basic attributes are used when possible: <see cref="DisplayNameAttribute"/>, <see cref="DescriptionAttribute"/>,
    /// <see cref="CategoryAttribute"/>
    /// <code>
    /// [Category("Switch")]
    /// [DisplayName("doSomething")]
    /// [Description("If true it will do something")]
    /// public Boolean doSomething { get; set; } = true;
    /// </code>
    /// But for more specifics, you can use <see cref="imbAttribute"/> (<c>_imbSCI*</c> snippets)
    /// <code>
    /// [imb(imbAttributeName.measure_letter, "V")] // --- letter we use in our sci article for some parameter
    /// [imb(imbAttributeName.measure_setUnit, "sec")] // ----- unit of measure, associated with the property
    /// [imb(imbAttributeName.reporting_columnWidth, 50)] // ----- width of column in the report spreadsheet
    /// [imb(imbAttributeName.measure_important)] // ----- tells that this column/property is important, resulting in application of highlighted style in the report
    /// [imb(imbAttributeName.reporting_valueformat, "#.0")] // --- specifies number format to be applied for cell value, in the report 	
    /// </code>
    /// </example>
    /// </remarks>
    /// <seealso cref="imbAttribute" />
    /// <seealso cref="imbAttributeName" />
    [CompilerGenerated]
    class NamespaceDoc
    {
    }

}
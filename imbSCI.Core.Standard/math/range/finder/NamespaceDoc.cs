using System;
using System.Linq;
using System.Collections.Generic;
using imbSCI.Core.attributes;
using imbSCI.Core.math;
using imbSCI.Core.extensions.table;
using imbSCI.Core.extensions.enumworks;
using imbSCI.Core.extensions.io;
using imbSCI.Core.extensions.text;
using imbSCI.Core.collection;
using imbSCI.Core.math.aggregation;
using imbSCI.Core.enums;
using System.ComponentModel;
using System.Data;
using System.Text;
using imbSCI.Core.extensions.typeworks;
using imbSCI.Core.extensions.data;
using imbSCI.Core.collection;
using imbSCI.Data;

namespace imbSCI.Core.math.range.finder
{

    /// <summary>
    /// <para>Range finders are utility objects, used to make descriptive statistics from collection of numbers and add agregate rows and conditional formatting to DataTable reports</para>
    /// </summary>
    /// <remarks>
    /// <para>rangeFinder comes in three flavors</para>
    /// <list>
    /// 	<item>
    ///			<term>Lightweight</term>
    ///			<description>basic <see cref="rangeFinder"/> finds min, max, avg, sum and count</description>
    ///		</item>
    ///		<item>
    ///			<term>Record keeper</term>
    ///			<description><see cref="rangeFinderWithData"/> keeps all values sent trough <see cref="rangeFinder.Learn(double)"/> method, taking some memory to have ability to compute standard deviation, entropy ... etc.</description>
    ///		</item>
    ///		<item>
    ///			<term>Report utility</term>
    ///			<description><see cref="rangeFinderForDataTable"/> is capable to scan and modify <see cref="DataTable"/> by adding agregate rows and conditional formatting for min and max rows</description>
    ///		</item>
    /// </list>
    /// </remarks>
    /// <seealso cref="DataTableExtensions" />
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    class NamespaceDoc
    {
    }

}
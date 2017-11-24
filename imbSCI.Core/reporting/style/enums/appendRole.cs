namespace imbSCI.Core.reporting.style.enums
{
    /// <summary>
    /// appendRole -- convertable to Tuple: acePaletteRole + acePaletteVariationRole
    /// </summary>
    public enum appendRole
    {

        /// <summary>
        /// The none - undefined role
        /// </summary>
        none,


        /// <summary>
        /// Role of this styling option is to affect complete table or section container
        /// </summary>
        i_container,

        /// <summary>
        /// Role of this styling option is to be used for margin enforcement on left, right, top and bottom
        /// </summary>
        i_margin,


        /// <summary>
        /// The horizontal line
        /// </summary>
        i_line,

        source,


        comment,


        /// <summary>
        /// The merged header: acePaletteRole.colorA + acePaletteVariationRole.header
        /// </summary>
        mergedHead,
        /// <summary>
        /// The merged content: acePaletteRole.colorA + acePaletteVariationRole.odd / even
        /// </summary>
        mergedContent,
        /// <summary>
        /// The merged footer: acePaletteRole.colorA + acePaletteVariationRole.normal
        /// </summary>
        mergedFoot,

        /// <summary>
        /// The section head: acePaletteRole.colorB + acePaletteVariationRole.header
        /// </summary>
        sectionHead,

        /// <summary>
        /// The section content: acePaletteRole.colorB + acePaletteVariationRole.odd / even
        /// </summary>
        sectionContent,
        /// <summary>
        /// The section foot: acePaletteRole.colorB + acePaletteVariationRole.normal
        /// </summary>
        sectionFoot,

        /// <summary>
        /// The major heading: acePaletteRole.colorA + acePaletteVariationRole.heading
        /// </summary>
        majorHeading,
        /// <summary>
        /// The minor heading: acePaletteRole.colorB + acePaletteVariationRole.heading
        /// </summary>
        minorHeading,

        /// <summary>
        /// The paragraph: acePaletteRole.colorDefault + acePaletteVariationRole.normal
        /// </summary>
        paragraph,

        /// <summary>
        /// The remark: acePaletteRole.colorDefault + acePaletteVariationRole.heading
        /// </summary>
        remark, 




        /// <summary>
        /// The table head: acePaletteRole.colorC + acePaletteVariationRole.header
        /// </summary>
        tableHead,
        /// <summary>
        /// The table column head - the first cell with column name: acePaletteRole.colorC + acePaletteVariationRole.heading
        /// </summary>
        tableColumnHead,
        /// <summary>
        /// The table column foot - last cell at end of column: acePaletteRole.colorC + acePaletteVariationRole.normal
        /// </summary>
        tableColumnFoot,
        /// <summary>
        /// The table cell value:: acePaletteRole.colorC + acePaletteVariationRole.odd / even
        /// </summary>
        tableCellValue,
        /// <summary>
        /// The table cell note: : acePaletteRole.colorC + acePaletteVariationRole.heading
        /// </summary>
        tableCellAnnotation,
        /// <summary>
        /// The table cell novalue : : acePaletteRole.colorDefault + acePaletteVariationRole.normal
        /// </summary>
        tableCellNovalue,
        /// <summary>
        /// The table between - intermediate information: : acePaletteRole.colorDefault + acePaletteVariationRole.normal
        /// </summary>
        tableBetween,
        /// <summary>
        /// The table foot - merged space where footer is printed : acePaletteRole.colorC + acePaletteVariationRole.normal
        /// </summary>
        tableFoot,


    }

}
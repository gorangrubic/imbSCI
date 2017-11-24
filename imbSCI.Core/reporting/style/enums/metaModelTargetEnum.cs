namespace imbSCI.Core.reporting.style.enums
{ 

    /// <summary>
    /// Enumerates possible targets of Apply/Append/Compose/Construct calls
    /// </summary>
    /// <remarks>
    /// Primarly created for ApplyStyle() method of <c>IDocumentRender</c> implementations
    /// </remarks>
    public enum metaModelTargetEnum
    {
        none,
        /// <summary>
        /// Targets whatever is predefined as default target on level of <c>IRender</c> implementation class
        /// </summary>
        defaultTarget,
        /// <summary>
        /// The current document
        /// </summary>
        document,
        /// <summary>
        /// The current page
        /// </summary>
        page,
        /// <summary>
        /// The current scope
        /// </summary>
        scope,
        /// <summary>
        /// The parent of current scope
        /// </summary>
        scopeParent,
        /// <summary>
        /// Each child of the current scope
        /// </summary>
        scopeEachChild,

        /// <summary>
        /// a child element of the current scope, needs key/id param
        /// </summary>
        scopeChild,
        /// <summary>
        /// Any metaContent element existing on a path, relative to scope. Supports apsolute paths too
        /// </summary>
        scopeRelativePath,
    /// <summary>
    /// Area pointed by <c>cursor.pencil</c> 
    /// </summary>

    pencil,
    /// <summary>
    /// The last append line/segment/section/node/cell
    /// </summary>
    lastAppend,
    /// <summary>
    /// It will be applied after next append call
    /// </summary>
    nextAppend,
    /// <summary>
    /// Set it to standard (for this <c>render</c> instance
    /// </summary>
    setStandard,
    /// <summary>
    /// Unset the standard config of this <c>render</c> instance
    /// </summary>
    unsetStandard,
    /// <summary>
    /// The set named standard - defines a preset on <c>styleTheme</c> level, globally accessable by any <c>render</c>
    /// </summary>
    setNamedStandard,
    /// <summary>
    /// The deletes a named standard defined as preset on <c>styleTheme</c> level
    /// </summary>
    unsetNamedStandard,
    /// <summary>
    /// Appends content representing configuration/settings/data used by targeting. 
    /// </summary>
    /// <remarks>
    /// Example: in case of ApplyStyle() - it will Append description of style into content
    /// </remarks>
    asAppend,

}

}
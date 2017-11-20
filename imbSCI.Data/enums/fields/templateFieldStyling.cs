namespace imbSCI.Data.enums.fields
{
    
    using imbSCI.Data.enums;
    
    /// <summary>
    /// Color pallete
    /// </summary>
    public enum templateFieldStyling
    {
        color_name,
        color_base,
        color_path,

        /// <summary>
        /// The text rotation - <see cref="aceCommonTypes.reporting.style.enums.styleTextRotationEnum"/>
        /// </summary>
        text_rotation,

        /// <summary>
        /// The text vertical aligment - <see cref="aceCommonTypes.zone.printVertical"/>
        /// </summary>
        text_verticalAligment,

        /// <summary>
        /// The text horizontal aligment <see cref="aceCommonTypes.zone.printHorizontal"/>
        /// </summary>
        text_horizontalAligment,

        /// <summary>
        /// The aligment - <see cref="aceCommonTypes.zone.textCursorZoneCorner"/> expected or string: "top", "center" "bottom"
        /// </summary>
        text_aligment,

        /// <summary>
        /// The color palette role - <see cref="aceCommonTypes.colors.acePaletteRole"/>
        /// </summary>
        color_paletteRole,
        /// <summary>
        /// The color variation role - <see cref="aceCommonTypes.colors.acePaletteVariationRole"/> 
        /// </summary>
        color_variationRole,
        color_variationAdjustment,
        render_isHidden,
    }
}
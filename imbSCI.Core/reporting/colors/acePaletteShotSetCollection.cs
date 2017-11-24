namespace imbSCI.Core.reporting.colors
{
    using System.Collections.Generic;

    /// <summary>
    /// ShotSet collection
    /// </summary>
    /// <seealso cref="System.Collections.Generic.Dictionary{System.String, aceCommonTypes.colors.acePaletteShot}" />
    internal class acePaletteShotSetCollection : Dictionary<string, acePaletteShot> 
    {
        
        internal void Add(acePaletteShot input)
        {
            
            Add(input.name, input);
        }
        
    }

}
namespace imbSCI.Core.syntax.codeSyntax
{
    /// <summary>
    /// Vrsta strukture sindakse
    /// </summary>
    public enum syntaxDeclarationStructureType
    {
        /// <summary>
        /// Nakon naslova> niz linija sa param/parovima, nema strukture
        /// </summary>
        lines,
        /// <summary>
        /// Niz linija koji moze sadrzati grupisane pod linije
        /// </summary>
        linesWithGroups,
        /// <summary>
        /// Sadrzaj je grupisan u blokove - kao JSON, ali otvorenog tipa
        /// </summary>
        blocks,
        /// <summary>
        /// Sadrzaj je dat u vidu CSV / tekstualnog prikaza tabele
        /// </summary>
        table,
        /// <summary>
        /// Sadrzaj je strogo hijearhijski dat - slicno> JSON, XML ili source code formatu
        /// </summary>
        codeHierarchy,
        /// <summary>
        /// Sadrzaj je pre svega testualnog tipa - strukturiran u pasose i liste radi lakseg citanja.
        /// </summary>
        text
    }

}
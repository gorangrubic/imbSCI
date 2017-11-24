namespace imbSCI.Core.reporting.render
{
    using System;

    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="ITabLevelControler" />
    /// \ingroup_disabled report_int
    public interface IStyleRender : ITabLevelControler, IRender
    {
        /// <summary>
        /// Renders key-> value pair 
        /// </summary>
        /// <param name="key">Property name or collection key</param>
        /// <param name="value">ToString value</param>
        /// <param name="breakLine">should break line </param>
        void AppendPair(String key, Object value, Boolean breakLine = true, String between = " = ");

      

        /// <summary>
        /// Prefix koji se dodaje ispred svake linije
        /// </summary>
        String linePrefix { get; set; }

        /// <summary>
        /// Vraca sadrzaj u String obliku
        /// </summary>
        /// <returns></returns>
        String ToString();

        /// <summary>
        /// Zatvara sve tagove koji su trenutno otvoreni
        /// </summary>
        //void closeAll();
    }
}
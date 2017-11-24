namespace imbSCI.Core.reporting
{
    using System;
    using imbSCI.Core.reporting.render.core;

    public interface ITabLevelControler
    {
        /// <summary>
        /// Prefix koji se dodaje ispred teksta -- tabovi
        /// </summary>
        String tabInsert { get; }

        /// <summary>
        /// nivo na kome je tab sada
        /// </summary>
        Int32 tabLevel { get; set; }

        /// <summary>
        /// Prefix koji se dodaje ispred svake linije
        /// </summary>
        String linePrefix { get; set; }

        void Clear();

        /// <summary>
        /// Prelazi u sledeci tab level
        /// </summary>
        void nextTabLevel();

        /// <summary>
        /// Prebacuje u prethodni tabLevel
        /// </summary>
        void prevTabLevel();

        void rootTabLevel();

        /// <summary>
        /// Vraca sadrzaj u String obliku
        /// </summary>
        /// <returns></returns>
        String ToString();

       // void open(String tag, String title = "", String description = "");


        tagBlock open(String tag, String title = "", String description = "");


        /// <summary>
        /// Dodaje HTML zatvaranje taga -- zatvara poslednji koji je otvoren
        /// </summary>
        /// <remarks>
        /// Ako je prosledjeni tag none onda zatvara poslednji tag koji je otvoren.
        /// </remarks>
        /// <param name="tag"></param>
        tagBlock close(String tag = "none");

        /// <summary>
        /// Zatvara sve tagove koji su trenutno otvoreni
        /// </summary>
        void closeAll();
    }
}
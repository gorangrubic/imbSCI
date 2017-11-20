namespace imbSCI.Core.collection
{
    #region imbVeles using

    using System;
    using System.Collections.Specialized;
    using System.ComponentModel;

    #endregion

    public interface IOneOrMore : INotifyCollectionChanged, INotifyPropertyChanged
    {
        /// <summary>
        /// informacije o tipu koji je smesten i jedini dozvoljen u kolekciji
        /// </summary>
        Type iTI { get; set; }

        /// <summary>
        /// TRUE kad nema nista u kolekciji, ali je inicijalizovana
        /// </summary>
        Boolean isNothing { get; }

        /// <summary>
        /// Kontra od isNothing - tj. da ima nesto u sebi
        /// </summary>
        Boolean isSomething { get; }

        /// <summary>
        /// neposredan pristup prvom itemu
        /// </summary>
        Object Value { get; set; }
    }
}
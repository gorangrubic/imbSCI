namespace imbSCI.Data.collection
{
    using System;
    using System.Collections;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    /// <summary>
    /// Tipizirana kolekcija
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class aceCollection<T>:ObservableCollection<T>, IAceCollection<T>
    {

        public  Boolean Any()
        {
            return Count > 0;
        }

        protected System.Type itemType;

        protected aceCollection()
        {
            _autoInit();
        }

        /// <summary>
        /// Inicijalizacija koja se pokrece sama nakon instanciranja
        /// </summary>
        public virtual void _autoInit()
        {
            itemType = typeof (T);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Returns an enumerator that iterates through a collection.
        /// </summary>
        /// <returns>
        /// An <see cref="T:System.Collections.IEnumerator"/> object that can be used to iterate through the collection.
        /// </returns>
        /// <filterpriority>2</filterpriority>
        public IEnumerator GetEnumerator()
        {
            return base.GetEnumerator();
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
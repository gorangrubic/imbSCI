namespace imbSCI.Data.collection
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Collections.Specialized;
    using System.ComponentModel;

    public interface IAceCollection : INotifyPropertyChanged, IList, ICollection
    {
        /*
    
        Boolean Any();



        event PropertyChangedEventHandler PropertyChanged;
        void Move(int oldIndex, int newIndex);
        event NotifyCollectionChangedEventHandler CollectionChanged;
        void Add(Object item);
        void Clear();
        void CopyTo(object[] array, int index);
        bool Contains(Object item);
        IEnumerator GetEnumerator();
        int IndexOf(Object item);
        void Insert(int index, Object item);
        bool Remove(Object item);
        void RemoveAt(int index);
        int Count { get; }
        Object this[int index] { get; set; }*/
    }


    public interface IAceCollection<T> : INotifyPropertyChanged, IList<T>, ICollection<T>
    {
        Boolean Any();

        /// <summary>
        /// Inicijalizacija koja se pokrece sama nakon instanciranja
        /// </summary>
        void _autoInit();

        event PropertyChangedEventHandler PropertyChanged;
        void Move(int oldIndex, int newIndex);
        event NotifyCollectionChangedEventHandler CollectionChanged;
        void Add(T item);
        void Clear();
        void CopyTo(T[] array, int index);
        bool Contains(T item);
        IEnumerator GetEnumerator();
        int IndexOf(T item);
        void Insert(int index, T item);
        bool Remove(T item);
        void RemoveAt(int index);
        int Count { get; }
        T this[int index] { get; set; }
    }
}
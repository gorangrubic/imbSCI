namespace imbSCI.Data.collection.math
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Threading;

    /// <summary>
    /// Concurrent Enumerator by Brian Murphy-Booth @ stackoverflow
    /// </summary>
    /// <remarks>
    /// <para>Original source for this class: https://stackoverflow.com/a/23446622/4034192 </para>
    /// <para>Author: Brian Murphy-Booth, https://stackoverflow.com/users/3023288/brian-murphy-booth </para>
    /// </remarks>
    /// <typeparam name="T"></typeparam>
    /// <seealso cref="System.Collections.Generic.IList{T}" />
    /// <seealso cref="System.IDisposable" />
    public class ConcurrentEnumerator<T> : IEnumerator<T>
        {
            #region Fields
            private readonly IEnumerator<T> _inner;
            private readonly ReaderWriterLockSlim _lock;
            #endregion

            #region Constructor
            public ConcurrentEnumerator(IEnumerable<T> inner, ReaderWriterLockSlim @lock)
            {
                this._lock = @lock;
                this._lock.EnterReadLock();
                this._inner = inner.GetEnumerator();
            }
            #endregion

            #region Methods
            public bool MoveNext()
            {
                return _inner.MoveNext();
            }

            public void Reset()
            {
                _inner.Reset();
            }

            public void Dispose()
            {
                this._lock.ExitReadLock();
            }
            #endregion

            #region Properties
            public T Current
            {
                get { return _inner.Current; }
            }

            object IEnumerator.Current
            {
                get { return _inner.Current; }
            }
            #endregion
        }

}
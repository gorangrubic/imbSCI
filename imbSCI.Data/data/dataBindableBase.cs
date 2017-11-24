namespace imbSCI.Data.data
{
    using System.ComponentModel;

    /// <summary>
    /// Base class for objects implementing the <see cref="INotifyPropertyChanged"/> interface, thus making class ready for DataBinding
    /// </summary>
    /// <seealso cref="System.ComponentModel.INotifyPropertyChanged" />
    public abstract class dataBindableBase : INotifyPropertyChanged
    {


        /// <summary>
        /// Called when a property is changed.
        /// </summary>
        /// <param name="name">The name.</param>
        public void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs(name));
        }

        /// <summary>
        /// Occurs when a property value changes.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
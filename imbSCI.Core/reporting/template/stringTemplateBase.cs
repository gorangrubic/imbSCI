namespace imbSCI.Core.reporting.template
{
    #region imbVeles using

    using System.ComponentModel;

    #endregion

    /// <summary>
    /// Osnovna klasa koju dele svi stringTemplate objekti
    /// </summary>
    public abstract class stringTemplateBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}
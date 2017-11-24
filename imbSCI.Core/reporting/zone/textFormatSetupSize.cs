namespace imbSCI.Core.reporting.zone
{
    using System;
    using System.ComponentModel;

    public abstract class textFormatSetupSize: selectRange, INotifyPropertyChanged
    {
        protected Int32 _width = 85;
        protected Int32 _height = 1;

        /// <summary>
        /// maksimalna spoljna sirina formata (innerWidth+padding+margin = Windows.width) 
        /// </summary>
        public virtual Int32 width
        {
            get
            {
                return _width;
            }
            set
            {
                _width = value;
                OnPropertyChanged("width");
            }
        }

        /// <summary>
        /// maksimalna spoljna visina formata (innerHeight+padding+margin=Windows.Height)
        /// </summary>
        public virtual Int32 height
        {
            get
            {
                return _height;
            }
            set
            {
                _height = value;
                OnPropertyChanged("height");
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
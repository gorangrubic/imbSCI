namespace imbSCI.Data.data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;

    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="System.ComponentModel.INotifyPropertyChanged" />
    public class changeBindableBase : INotifyPropertyChanged
    {
        /// <summary>
        /// Sets current state of the object to be Changed (i.e. from now on the object will know it had some changes since last <see cref="Accept"/> call);
        /// </summary>
        public void InvokeChanged()
        {
            if (!HasChanges) Changes.Add("External change invoke");
        }


        /// <summary>
        /// Gets the changes.
        /// </summary>
        /// <param name="andAccept">if set to <c>true</c> [and accept].</param>
        /// <returns></returns>
        public List<String> GetChanges(Boolean andAccept)
        {
            var l2 = Changes.ToList(); //.Clone();
            if (andAccept)
            {
                Changes.Clear();
            }
            return l2;
        }

        /// <summary>
        /// Clears all changes recorded since object creation or last Accept()
        /// </summary>
        /// <returns></returns>
        protected virtual Boolean Accept()
        {
            if (Changes.Count > 0)
            {

                Changes.Clear();
                return true;
            }

            return false;
        }


        /// <summary>
        /// Gets a value indicating whether this instance has changes.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance has changes; otherwise, <c>false</c>.
        /// </value>
        public Boolean HasChanges
        {
            get
            {
                return (Changes.Count > 0);
            }
        }


        /// <summary>
        /// The changes
        /// </summary>
        private List<string> _Changes = new List<string>();
        /// <summary>
        /// Gets or sets the changes.
        /// </summary>
        /// <value>
        /// The changes.
        /// </value>
        public List<string> Changes
        {
            get
            {

                return _Changes;
            }
            protected set
            {
                _Changes = value;
                OnPropertyChanged("Changes");
            }
        }



        /// <summary>
        /// Kreira event koji obaveštava da je promenjen neki parametar
        /// </summary>
        /// <remarks>
        /// Neće biti kreiran event ako nije spremna aplikacija: imbSettingsManager.current.isReady
        /// </remarks>
        /// <param name="name"></param>
        public void OnPropertyChanged(string name)
        {
            if (!Changes.Contains(name)) Changes.Add(name);

            PropertyChangedEventHandler handler = PropertyChanged;

        }

        public event PropertyChangedEventHandler PropertyChanged;
    }

}
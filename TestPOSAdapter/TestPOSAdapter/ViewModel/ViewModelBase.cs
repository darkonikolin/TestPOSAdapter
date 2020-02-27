using System.ComponentModel;

namespace TestPOSAdapter.ViewModel
{
    class ViewModelBase : INotifyPropertyChanged
    {
        /// <summary>
        /// Property Changed event.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// On Property Changed
        /// </summary>
        /// <param name="name">Name #</param>
        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}


namespace BitcoinApp.ViewModel
{
    using System.ComponentModel;
    using System.Runtime.CompilerServices;

    class MainViewModel : INotifyPropertyChanged
    {
        private double _price;

        public MainViewModel()
        {
            _price = 1.5;
        }

        public double Price
        {
            get
            {
                return _price;
            }
            set
            {
                _price = value;
                NotifyPropertyChanged("Price");
            }
        }

        public string PriceText
        {
            get
            {
                return _price.ToString();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void NotifyPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

    }
}

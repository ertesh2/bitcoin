using GalaSoft.MvvmLight;
using System.ComponentModel;

namespace BitcoinApp.ViewModel
{
    class MainViewModel : ViewModelBase
    {
        public MainViewModel()
        {
            _price = 1.5;
        }

        private double _price;
        public double Price
        {
            get { return _price; }
            set { Set(ref _price, value); }
        }

        public string PriceText
        {
            get { return _price.ToString(); }
        }
    }
}

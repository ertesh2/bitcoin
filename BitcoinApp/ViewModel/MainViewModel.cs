using GalaSoft.MvvmLight;
using System.ComponentModel;
using System;
using System.Net;
using System.Runtime.Serialization.Json;
using System.IO;
using System.Threading.Tasks;
using Windows.Data.Json;

namespace BitcoinApp.ViewModel
{
    class MainViewModel : ViewModelBase
    {
        public MainViewModel()
        {
            // TODO: Add dispatcher
            //GetPrice().ContinueWith(t => Price = t.Result);
        }

        private async Task<double> GetPrice()
        {
            //rest sharp?

            string requestUrl = "http://api.coindesk.com/v1/bpi/currentprice.json";
            HttpWebRequest request = WebRequest.Create(requestUrl) as HttpWebRequest;
            using (HttpWebResponse response = await request.GetResponseAsync() as HttpWebResponse)
            {
                if (response.StatusCode != HttpStatusCode.OK)
                {
                    throw new Exception("Unexpected response: " + response.StatusCode);
                }
                using (var reader = new StreamReader(response.GetResponseStream()))
                {
                    try
                    {
                        string data = reader.ReadToEnd();
                        JsonValue jsonValue = JsonValue.Parse(data);
                        var time = jsonValue.GetObject().GetNamedValue("time");
                        var bpi = jsonValue.GetObject().GetNamedValue("bpi");
                        var usd = bpi.GetObject().GetNamedValue("USD");
                        var rate = usd.GetObject().GetNamedString("rate");
                        return Double.Parse(rate);
                    }
                    catch (Exception e)
                    {
                        return 0.0;
                    }
                }
            }
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

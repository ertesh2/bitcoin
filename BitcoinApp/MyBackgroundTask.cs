using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitcoinApp
{
    using Windows.ApplicationModel.Background;

    using BitcoinApp.ViewModel;

    class MyBackgroundTask : IBackgroundTask
    {
        private double _val;

        private TileManager _manager;
        
        MyBackgroundTask()
        {
            _manager = new TileManager();
            _val = 0;
        }
        
        public void Run(IBackgroundTaskInstance taskInstance)
        {
            BackgroundTaskDeferral deferral = taskInstance.GetDeferral();

            //var feed = await GetMSDNBlogFeed();
            _val += 1.0;

            // Update the live tile with the feed items.
            _manager.UpdateTile(_val);

            deferral.Complete();
        }
    }
}

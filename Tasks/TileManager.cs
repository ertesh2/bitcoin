using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasks
{
    using Windows.UI.Notifications;

    class TileManager
    {
        public void UpdateTile(double d)
        {
            string msg = "Current: " + d;

            var content = TileUpdateManager.GetTemplateContent(TileTemplateType.TileSquareText01);

            //var image = content.GetElementsByTagName("image");
            //((XmlElement)image[0]).SetAttribute("src", "ms-appx:///Images/tiles/badge.png");

            var tileAttributes = content.GetElementsByTagName("text");
            tileAttributes[0].AppendChild(content.CreateTextNode(msg));

            var newTile = new TileNotification(content);

            TileUpdater tileUpdater = TileUpdateManager.CreateTileUpdaterForApplication();
            tileUpdater.EnableNotificationQueue(false);
            tileUpdater.Update(newTile);
        }
    }
}

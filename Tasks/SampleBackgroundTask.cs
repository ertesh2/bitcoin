// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF
// ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO
// THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
// PARTICULAR PURPOSE.
//
// Copyright (c) Microsoft Corporation. All rights reserved

using System;
using System.Diagnostics;
using System.Threading;
using Windows.ApplicationModel.Background;
using Windows.Foundation;
using Windows.Storage;
using Windows.System.Threading;

//
// The namespace for the background tasks.
//
namespace Tasks
{
    //
    // A background task always implements the IBackgroundTask interface.
    //
    public sealed class SampleBackgroundTask : IBackgroundTask
    {
        private readonly TileManager _tileManager = new TileManager();

        private double _val = 0.0;

        public void Run(IBackgroundTaskInstance taskInstance)
        {
            Debug.WriteLine("Background " + taskInstance.Task.Name + " Starting...");

            var defferal = taskInstance.GetDeferral();

            _val += 1.0;
            _tileManager.UpdateTile(_val);

            defferal.Complete();
        }
    }
}

using Foundation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UIKit;
using XAM.Contracts;

namespace XAM.iOS
{
    public class AppleDeviceService : IDeviceService
    {
        public string Identify()
        {
            return "iOS";
        }
    }
}
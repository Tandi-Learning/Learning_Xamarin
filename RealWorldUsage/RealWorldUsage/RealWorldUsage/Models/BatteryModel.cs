using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;

namespace RealWorldUsage.Models
{
    public class BatteryModel
    {
        public double ChargeLevel { get; set; }
        public BatteryState State { get; set; }
    }
}

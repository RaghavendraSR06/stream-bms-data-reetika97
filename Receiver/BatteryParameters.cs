using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMSReceiver
{
    public class BatteryParameters
    {
        private static double _minimum = double.MaxValue;
        private static double _maximum = double.MinValue;
        public static double TemperatureMaximumValue {
            get { return _maximum; }
            set { _maximum = value; } 
        }
        public static double TemperatureMinimumValue {
            get { return _minimum; }
            set { _minimum = value; }
        }

        public static double StateOfChargeMaximumValue {
            get { return _maximum; }
            set { _maximum = value; }
        }

        public static double StateofChargeMinimumValue {
            get { return _minimum; }
            set { _minimum = value; }
        }

        public static double TemperatureMovingAverage { get; set; }
        public static double StateOfChargeMovingAverage { get; set; }
    }
}

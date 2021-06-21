using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMSReceiver
{
    public class BatteryProcessor : IBatteryProcessor
    {       
        public void CalculateMinimumAndMaximumValue(BatteryProperties batteryProperties)
        {           
            GetMinimumValue(batteryProperties);
            GetMaximumValue(batteryProperties);            
        }

        public static void GetMinimumValue(BatteryProperties properties)
        {        
            if(properties == null)
            {
                return;
            }
            BatteryParameters.TemperatureMinimumValue = Math.Min(BatteryParameters.TemperatureMinimumValue, properties.Temperature);
            BatteryParameters.StateofChargeMinimumValue = Math.Min(BatteryParameters.StateofChargeMinimumValue, properties.StateOfCharge);
           
        }

        public static void GetMaximumValue(BatteryProperties properties)
        {
            if (properties == null)
            {
                return;
            }

            BatteryParameters.TemperatureMaximumValue = Math.Max(BatteryParameters.TemperatureMaximumValue, properties.Temperature);
            BatteryParameters.StateOfChargeMaximumValue = Math.Max(BatteryParameters.StateOfChargeMaximumValue, properties.StateOfCharge);           
        }

        public void GetMovingAverageValue(List<BatteryProperties> propertiesValue)
        {
            if (propertiesValue.Count <= 0)
                return;

            double totalTemperature = 0;
            double totalStateOfCharge = 0;
            foreach (var battery in propertiesValue)
            {
                totalTemperature += battery.Temperature;
                totalStateOfCharge += battery.StateOfCharge;
            }
            BatteryParameters.TemperatureMovingAverage = totalTemperature / propertiesValue.Count;
            BatteryParameters.StateOfChargeMovingAverage = totalStateOfCharge / propertiesValue.Count;            
        }
    }
}

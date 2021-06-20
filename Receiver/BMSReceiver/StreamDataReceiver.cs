using System.Collections.Generic;
using System.Linq;

namespace BMSReceiver
{
    public class StreamDataReceiver: IStreamDataReceiver
    {
        public BatteryProperties GetDataFromReceiver(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return null;
            }

            var data = input.Split(',').ToList();
            
            BatteryProperties batteryProperties = new BatteryProperties();
            batteryProperties.Temperature = double.Parse(data[0]);
            batteryProperties.StateOfCharge = double.Parse(data[1]);           
            return batteryProperties;
        }
    }
}

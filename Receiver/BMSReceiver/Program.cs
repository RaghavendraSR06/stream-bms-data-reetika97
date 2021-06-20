using System;
using System.Collections.Generic;
using System.IO;

namespace BMSReceiver
{
    class Program
    {
        static void Main(string[] args)
        {
            IStreamDataReceiver streamDataReceiver = new StreamDataReceiver();
            IBatteryProcessor batteryProcessor = new BatteryProcessor();
            int count = 0;
            List<BatteryProperties> batteryValues = new List<BatteryProperties>();

            string inputValues = string.Empty;        
            while ((inputValues = Console.ReadLine()) != null)         
            {
                var receiverData = streamDataReceiver.GetDataFromReceiver(inputValues);                
                count++;
                batteryValues.Add(receiverData);
                batteryProcessor.CalculateMinimumAndMaximumValue(receiverData);

                Console.WriteLine($"MinimumTemperate:{BatteryParameters.TemperatureMinimumValue},  " +
                    $"MaximumTemperature:{BatteryParameters.TemperatureMaximumValue},  " +
                    $"MinimumStateOfCharge:{BatteryParameters.StateofChargeMinimumValue}  " +
                    $"MaximumStateOfCharge:{BatteryParameters.StateOfChargeMaximumValue}  ");

                if (count == 5)
                {
                    batteryProcessor.GetMovingAverageValue(batteryValues);
                    Console.WriteLine($"TemperatureMovingAverageValue:{BatteryParameters.TemperatureMovingAverage},  " + 
                        $"StateOfChargeMovingAverageValue:{BatteryParameters.StateOfChargeMovingAverage}");
                    batteryValues = new List<BatteryProperties>();
                    count = 0;
                }
            }
        }       
    }
}

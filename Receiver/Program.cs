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
           // string inputValues = GenerateRandomNumbers();
            //var inputList = inputValues.Split('\n');
            while ((inputValues = Console.ReadLine()) != null)
           // foreach(var value in inputList)
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

        public static string GenerateRandomNumbers()
        {
            var input = string.Empty;
            using (StringWriter str = new StringWriter())
            {
                var originalStream = Console.Out;
                Console.SetOut(str);
                Random num = new Random();
                for (int i = 0; i < 5; i++)
                {
                    Console.WriteLine($"{num.Next(1, 100)},{num.Next(1, 100)}");
                }
                Console.SetOut(originalStream);
                input = str.ToString();
            }

            return input;
        }
    }
}

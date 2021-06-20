using System.Collections.Generic;

namespace BMSReceiver
{
    public interface IBatteryProcessor
    {
        void CalculateMinimumAndMaximumValue(BatteryProperties battery);
        void GetMovingAverageValue(List<BatteryProperties> propertiesValue);
    }
}

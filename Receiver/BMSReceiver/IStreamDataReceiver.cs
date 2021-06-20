using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMSReceiver
{    public interface IStreamDataReceiver
    {
        BatteryProperties GetDataFromReceiver(string input);
    }
}

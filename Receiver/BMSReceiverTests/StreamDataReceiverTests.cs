using BMSReceiver;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BMSReceiverTests
{
    [TestClass]
    public class StreamDataReceiverTests
    {
        [TestMethod]
        public void GivenBatteryInput_WhenBatteryDataInputIsNull_ThenReturnNull()
        {
            IStreamDataReceiver receiver = new StreamDataReceiver();
            var result = receiver.GetDataFromReceiver(null);
            Assert.IsNull(result);
        }

        [TestMethod]
        public void GivenBatteryInput_WhenBatteryDataInputIsEmpty_ThenReturnNull()
        {
            IStreamDataReceiver receiver = new StreamDataReceiver();
            var result = receiver.GetDataFromReceiver("");
            Assert.IsNull(result);
        }

        [TestMethod]
        public void GivenBatteryInput_WhenBatteryDataInputIsValid_ThenReturnInstanceOfBatteryProperties()
        {
            IStreamDataReceiver receiver = new StreamDataReceiver();           
            var result = receiver.GetDataFromReceiver("23,12");
            Assert.IsInstanceOfType(result,typeof(BatteryProperties));
        }
    }
}

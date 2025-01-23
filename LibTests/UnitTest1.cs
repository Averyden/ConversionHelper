using ConversionHelper;

namespace LibTests
{
    [TestClass]
    public class ConvertoTest
    {
        Converto c;


        [TestMethod]
        public void RGBToHex_ActuallyReturnsTheProperHexCode_ForWhenAllValuesAre255()
        {
            c = new Converto();

            Assert.AreEqual("#FFF", c.RGBToHex(255, 255, 255));
        }
    }
}
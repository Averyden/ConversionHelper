using ConversionHelperLibrary;

namespace LibTests
{
    [TestClass]
    public class ConvertoTest
    {
        ConversionHelper c;


        [TestMethod]
        public void RGBToHex_ActuallyReturnsTheProperHexCode_ForWhenAllValuesAre255()
        {
            c = new ConversionHelper();

            Assert.AreEqual("#FFF", c.RGBToHex(255, 255, 255));
        }

        [TestMethod]
        public void RGBToHex_ReturnsFullHexCode_WhenNotAllValuesAreTheSame()
        {
            c = new ConversionHelper();

            Assert.AreEqual("#00B621", c.RGBToHex(0, 182, 33));
        }
    }
}
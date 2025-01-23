using ConversionHelperLibrary;

namespace LibTests
{
    [TestClass]
    public class ConvertoTest
    {
        ConversionHelper c;

        // RGB to hex tests
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

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void RGBToHex_ReturnsAppropriateExceptionForInvalidValues()
        {
            c = new ConversionHelper();

            c.RGBToHex(275, 255, 255);
        }

        // Hex To RGB tests

        [TestMethod]
        public void HexToRGBReturnsMaxedValuesWhenFFFIsEntered()
        {
            c = new ConversionHelper();

            Assert.AreEqual("(255, 255, 255)", c.HexToRGB("#FFF"));

        }

        [TestMethod] 
        public void HexToRGBIsAbleToHandleEnteredHexValuesWithoutTheHashtagIntheFront()
        {
            c = new ConversionHelper();

            Assert.AreEqual("(255, 255, 255)", c.HexToRGB("FFF"));
        }

        [TestMethod]
        public void HexToRGBCanUnderstandRGBFormat()
        {
            c = new ConversionHelper();

            Assert.AreEqual("(170, 204, 255)", c.HexToRGB("#AACCFF"));
        }

        [TestMethod]
        public void HexToRGBCanUnderstandRRGGBBFormat()
        {
            c = new ConversionHelper();

            Assert.AreEqual("(69, 117, 78)", c.HexToRGB("45754e"));
        }



    }
}
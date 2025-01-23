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

            Assert.AreEqual("(170, 204, 255)", c.HexToRGB("#ACF"));
        }

        [TestMethod]
        public void HexToRGBCanUnderstandRRGGBBFormat()
        {
            c = new ConversionHelper();

            Assert.AreEqual("(69, 117, 78)", c.HexToRGB("45754e"));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void HexToRGBErrorsWhenNothingIsProvided()
        {
            c = new ConversionHelper();

            c.HexToRGB("");
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))] 
        public void HexToRGBErrorsOnInvalidFormatBecauseHexCodeIsTooShort()
        {
            c = new ConversionHelper();

            c.HexToRGB("ff");
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void HexToRGBErrorsOnInvalidFormatBecauseHexCodeIsTooShortButNotBelowThreeInLength()
        {
            c = new ConversionHelper();

            c.HexToRGB("#ff33");
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void HexToRGBErrorsOnInvalidFormatBecauseHexCodeIsTooLong()
        {
            c = new ConversionHelper();

            c.HexToRGB("#45754edf");
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void HexToRGBErrorsOnInvalidFormatBecauseTheHexCodeContainsALetterNotSupported()
        {
            c = new ConversionHelper();

            c.HexToRGB("#UUU");
        }


        // HSL to RGB tests

        [TestMethod]
        public void HSLToRGBReturnsCorrectRGBWhenHueIs0AndFullSaturation()
        {
            c = new ConversionHelper();

            Assert.AreEqual("(255, 0, 0)", c.HSLToRGB(0, 1, 0.5));
        }

        [TestMethod]
        public void HSLToRGBReturnsCorrectRGBWhenHueIs120AndFullSaturation()
        {
            c = new ConversionHelper();

            Assert.AreEqual("(0, 255, 0)", c.HSLToRGB(120, 1, 0.5));
        }

        [TestMethod]
        public void HSLToRGBReturnsCorrectRGBWhenHueIs240AndFullSaturation()
        {
            c = new ConversionHelper();

            Assert.AreEqual("(0, 0, 255)", c.HSLToRGB(240, 1, 0.5));
        }

        [TestMethod]
        public void HSLToRGBReturnsCorrectRGBWhenHueIs180AndHalfSaturation()
        {
            c = new ConversionHelper();

            Assert.AreEqual("(64, 191, 191)", c.HSLToRGB(180, 0.5, 0.5));
        }

        [TestMethod]
        public void HSLToRGBReturnsCorrectRGBWhenHueIs30AndHalfSaturation()
        {
            c = new ConversionHelper();

            Assert.AreEqual("(191, 127, 64)", c.HSLToRGB(30, 0.5, 0.5));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void HSLToRGBThrowsExceptionWhenHueIsNegative()
        {
            c = new ConversionHelper();

            c.HSLToRGB(-10, 1, 0.5);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void HSLToRGBThrowsExceptionWhenHueIsGreaterThan360()
        {
            c = new ConversionHelper();

            c.HSLToRGB(370, 1, 0.5);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void HSLToRGBThrowsExceptionWhenSaturationIsLessThanZero()
        {
            c = new ConversionHelper();

            c.HSLToRGB(180, -0.1, 0.5);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void HSLToRGBThrowsExceptionWhenSaturationIsGreaterThanOne()
        {
            c = new ConversionHelper();

            c.HSLToRGB(180, 1.5, 0.5);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void HSLToRGBThrowsExceptionWhenLightnessIsLessThanZero()
        {
            c = new ConversionHelper();

            c.HSLToRGB(180, 1, -0.1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void HSLToRGBThrowsExceptionWhenLightnessIsGreaterThanOne()
        {
            c = new ConversionHelper();

            c.HSLToRGB(180, 1, 1.1);
        }

        // ToBase64 tests

        [TestMethod]
        public void ToBase64ReturnsCorrectBase64ForNormalString()
        {
            c = new ConversionHelper();

            Assert.AreEqual("SGVsbG8gd29ybGQ=", c.ToBase64("Hello world"));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ToBase64ReturnsExceptionFromEmptyString()
        {
            c = new ConversionHelper();

            Assert.AreEqual("", c.ToBase64(""));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ToBase64ThrowsExceptionForNullString()
        {
            c = new ConversionHelper();

            c.ToBase64(null);
        }

    }
}
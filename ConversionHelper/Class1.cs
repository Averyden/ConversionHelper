namespace ConversionHelperLibrary
{
    /* 
         Converto is the class name for the conversion helper library
        Coded in C# using .NET we will only be making use of methods here, no properties.
         */
    public class ConversionHelper
    {
        public string RGBToHex(int red, int green, int blue) 
        {
            string output = "";
            string checkString = $"{red:X2}{green:X2}{blue:X2}";

            if (checkString == String.Concat(Enumerable.Repeat(checkString[0], 6)))
            {
                output = String.Concat(Enumerable.Repeat(checkString[0], 3));
            }


            return $"#{output}";
        }

        public string HexToRGB(string hexCode)
        {
            string output = "";
            return output;
        }

    }
}

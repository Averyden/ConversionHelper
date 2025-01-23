using System.Drawing;

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
            } else
            {
                output = checkString;
            }


            return $"#{output}";
        }

        public string HexToRGB(string hexCode)
        {
            if (hexCode[0] != '#')
            {
                hexCode = $"#{hexCode}"; // Yes i am petty by doing this, but fuck you!
            }

            /* TODO:
             * Find a way to reverse the process, WITHOUT using aspose. I dont want to install shit on my machine
              */
            string output = "";

            return output;
        }

    }
}

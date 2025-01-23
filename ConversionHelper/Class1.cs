﻿using System.Drawing;

namespace ConversionHelperLibrary
{
    /* 
         Converto is the class name for the conversion helper library
        Coded in C# using .NET we will only be making use of methods here, no properties.
         */
    public class ConversionHelper
    {
        // PRIVATE METHODS TO HELP WITH INTERNAL LOGIC INSTEAD OF MAKING A METHOD BE DISGUSTINGLY UGLY.

        private bool validRGBInput(params int[] nums)
        {
            return nums.All(value => value >= 0 && value <= 255);
        }



        // PUBLIC METHODS THAT SHOULD BE ACCESSIBLE FOR USAGE OF LIBRARY

        public string RGBToHex(int red, int green, int blue) 
        {
            if (!validRGBInput(red, green, blue))
            {
                throw new ArgumentOutOfRangeException("RGB values must be positive and must not exceed 255");
            }

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
            if (string.IsNullOrEmpty(hexCode))
            {
                throw new ArgumentNullException("Hex code cannot be null or empty.");
            }

            if (hexCode[0] != '#')
            {
                hexCode = $"#{hexCode}"; // Yes i am petty by doing this, but fuck you!
            }

            if (hexCode.Length != 4 || hexCode.Length != 7)
            {
                throw new FormatException("Hex code must be in #RGB or #RRGGBB format, no inbetween.");
            }


            /* TODO:
             * Find a way to reverse the process, WITHOUT using aspose. I dont want to install shit on my machine
              */
            string output = "";

            return output;
        }

    }
}

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

        private bool validHSLInput(double hue, double saturation, double lightness)
        {
            return hue >= 0 && hue <= 360 &&
                   saturation >= 0 && saturation <= 1 &&
                   lightness >= 0 && lightness <= 1;
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


            if (!System.Text.RegularExpressions.Regex.IsMatch(hexCode, @"^#([0-9a-fA-F]{3}|[0-9a-fA-F]{6})$"))
            {
                throw new FormatException("Hex code contains invalid characters. Only 0-9 and A-F (case insensitive) are supported in hex codes.");
            }



            if (hexCode.Length != 4 && hexCode.Length != 7)
            {
                throw new FormatException("Hex code must be in #RGB or #RRGGBB format, no inbetween.");
            }

            int red, green, blue;

            if (hexCode.Length == 4)
            {
                red = Convert.ToInt32($"{hexCode[1]}{hexCode[1]}", 16);
                green = Convert.ToInt32($"{hexCode[2]}{hexCode[2]}", 16);
                blue = Convert.ToInt32($"{hexCode[3]}{hexCode[3]}", 16);
            } else
            {
                red = Convert.ToInt32($"{hexCode[1]}{hexCode[2]}", 16);
                green = Convert.ToInt32($"{hexCode[3]}{hexCode[4]}", 16);
                blue = Convert.ToInt32($"{hexCode[5]}{hexCode[6]}", 16);
            }

            return $"({red}, {green}, {blue})";
        }

        public string HSLToRGB(double hue, double saturation, double lightness)
        {
            if (!validHSLInput(hue,saturation, lightness))
            {
                throw new ArgumentOutOfRangeException("Invalid HSL values. \nMake sure the hue value is between 0 and 360, meanwhile the saturation and lightness should both be from 0 to 1.");
            }

            double c = (1 - Math.Abs(2 * lightness - 1)) * saturation;
            double x = c * (1 - Math.Abs((hue / 60) % 2 - 1));
            double m = lightness - c / 2;

            double red = 0, green = 0, blue = 0;

            if (hue >= 0 && hue < 60) { red = c; green = x; blue = 0; }
            else if (hue >= 60 && hue < 120) { red = x; green = c; blue = 0; }
            else if (hue >= 120 && hue < 180) { red = 0; green = c; blue = x; }
            else if (hue >= 180 && hue < 240) { red = 0; green = x; blue = c; }
            else if (hue >= 240 && hue < 300) { red = x; green = 0; blue = c; }
            else { red = c; green = 0; blue = x; }

            red = (red + m) * 255;
            green = (green + m) * 255;
            blue = (blue + m) * 255;

            red = (red % 1 >= 0.7) ? Math.Ceiling(red) : red;
            green = (green % 1 >= 0.7) ? Math.Ceiling(green) : green;
            blue = (blue % 1 >= 0.7) ? Math.Ceiling(blue) : blue;

            red = Math.Min(255, Math.Max(0, red));
            green = Math.Min(255, Math.Max(0, green));
            blue = Math.Min(255, Math.Max(0, blue));

            return $"({(int)red}, {(int)green}, {(int)blue})";
        }


        public string RGBtoHSL(int red, int green int blue)
        {
            if (!validRGBInput(red, green, blue))
            {
                throw new ArgumentOutOfRangeException("RGB values must be positive and must not exceed 255");
            }

            double r = red / 255;
            double g = green / 255;
            double b = blue / 255;

            double max = Math.Max(r, Math.Max(g, b));
            double min = Math.Min(r, Math.Min(g, b));
            double delta = max - min;

            double hue = 0;

            if (delta != 0)
            {
                if (max == r)
                {
                    hue = 60 * (((g - b) / delta) % 6);
                } else if (max == g)
                {
                    hue = 60 * (((b - r) / delta) % 6);
                } else if (max == b) {
                    hue = 60 * (((r - g) / delta) % 6);
                }
            }

            if (hue < 0) hue += 360;

            double light = (max + min) / 2;

            double saturation = 0;

            if (delta != 0)
            {
                saturation = delta / (1 - Math.Abs(2 * light - 1));
            }

            return $"({Math.Round(hue, 2)}, {Math.Round(saturation, 2)}, {Math.Round(light, 2)})";
        }
        
        public string ToBase64(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                throw new ArgumentNullException(nameof(input), "Input cannot be null or empty.");
            }

            byte[] bytes = System.Text.Encoding.UTF8.GetBytes(input);
            return Convert.ToBase64String(bytes);
        }

        public string FromBase64(string input) 
        {
            if (string.IsNullOrEmpty(input))
            {
                throw new ArgumentNullException(nameof(input), "Input cannot be null or empty.");
            }

            byte[] bytes = Convert.FromBase64String(input);
            return System.Text.Encoding.UTF8.GetString(bytes);
        }

    }
}

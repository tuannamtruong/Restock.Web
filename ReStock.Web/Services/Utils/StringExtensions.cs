using System;
using System.Globalization;
using System.Linq;

namespace ReStock.Web.Services.Utils
{
    public static class StringExtensions
    {
        public static string ToUpperFirstChar(this string input) =>
        input switch
        {
            null => throw new ArgumentNullException(nameof(input)),
            "" => throw new ArgumentException($"{nameof(input)} cannot be empty", nameof(input)),
            _ => input.First().ToString().ToUpper() + input.Substring(1)
        };

        public static string ToUpperFirstCharEachLetter(this string input)
        {
            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(input.ToLower());
        }
    }
}

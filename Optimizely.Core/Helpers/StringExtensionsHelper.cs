
namespace Optimizely.Core.Helpers
{
    public static class StringExtensionsHelper
    {
        public static string MakeCompactString(this string str, int maxLength = 30, string suffix = "...")
        {
            var newStr = string.IsNullOrEmpty(str) ? string.Empty : str;
            var strLength = string.IsNullOrEmpty(str) ? 0 : str.Length;
            if (strLength > maxLength)
            {
                newStr = str?.Substring(0, maxLength);
            }

            return newStr + suffix;
        }
    }
}

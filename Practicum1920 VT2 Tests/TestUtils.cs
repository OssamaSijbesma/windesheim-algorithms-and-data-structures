using System.Text.RegularExpressions;

namespace Practicum1920_VT2_Tests
{
    public class TestUtils
    {
        public static string StringWithoutSpaces(string s)
        {
            return Regex.Replace(s, @"\s+", "").Trim();
        }
    }
}

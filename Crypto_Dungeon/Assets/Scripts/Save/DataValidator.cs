using System.Text.RegularExpressions;

namespace Assets.Scripts.Save
{
    public class DataValidator
    {
        public static bool IsIPAddressValid(string ip)
        {
            Regex pattern = new Regex(@"^((25[0-5]|(2[0-4]|1\d|[1-9]|)\d)\.?\b){4}$");

            return pattern.IsMatch(ip);
        }

        public static bool IsIPPortValid(string port)
        {
            Regex pattern = new Regex(@"^\d{1,4}$");

            return pattern.IsMatch(port);
        }
    }
}

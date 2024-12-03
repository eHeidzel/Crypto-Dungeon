using System.Text.RegularExpressions;

namespace Assets.Scripts
{
    public class TextConverter
    {
        public static string TextToUnderlinedFormat(string text)
        {
            string res = "";

            foreach (var sym in text)
                res += CharToUnderLineFormat(sym);

            return res;
        }

        public static string TextToUnderlinedFormat(string text, string textMask)
        {
            int needLen = TextToNoFormat(textMask).Length;

            if (text.Length > needLen)
                text = text.Substring(0, needLen);

            string res = TextToUnderlinedFormat(text);

            while (TextToNoFormat(res).Length < needLen)
            {
                if (res.Length > 0 && res[^1] == ' ')
                    res += $"<u>?</u>";
                else 
                    res += ' ';
            }

            return res;
        }

        public static string TextToNoFormat(string text)
        {
            string res = text;
            res = RemoveUnderlineTags(res);

            return res.Replace(" ", "");
        }

        static string RemoveUnderlineTags(string input)
        {
            string pattern = @"<\/?u>";
            return Regex.Replace(input, pattern, "");
        }

        private static string CharToUnderLineFormat(char sym)
        {
            if (sym != ' ')
                return $"<u>{sym}</u> ";
            else
                return " ";
        }
    }
}

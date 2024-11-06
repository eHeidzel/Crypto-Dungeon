namespace Assets.Scripts.Ciphers.Additional
{
    internal class Helper
    {
        public static string GenerateFullKey(string key, string message)
        {
            string fullKey = "";

            for (int i = 0; i < message.Length; i++)
                fullKey += key[i % key.Length];

            return fullKey;
        }

        public static int GetCharIndexInAlphabet(char ch, char firstChInAlphabet)
        {
            var charIndex = ch - (int)firstChInAlphabet;

            if ((int)ch == 1025)
                charIndex = 6;
            if ((int)ch > 1045)
                charIndex++;

            return charIndex;
        }
    }
}

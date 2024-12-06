using System;
using UnityEngine;
using static System.Runtime.CompilerServices.RuntimeHelpers;

namespace Assets.Scripts.Cyphers
{
    internal class AlphabetManager
    {
        public static char[] GetAlphabet(Alphabet alphabet)
        {
            switch (alphabet)
            {
                case Alphabet.RU:
                    return new char[] { 'А', 'Б', 'В', 'Г', 'Д', 'Е', 'Ё', 'Ж', 'З', 'И', 'Й', 'К', 'Л', 'М', 'Н', 'О', 'П', 'Р', 'С', 'Т', 'У', 'Ф', 'Х', 'Ц', 'Ч', 'Ш', 'Щ', 'Ъ', 'Ы', 'Ь', 'Э', 'Ю', 'Я' };
                case Alphabet.EN:
                    return new char[] { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
                default:
                    throw new ArgumentException();
            }
        }

        public static char[] GetAlphabet(Localization localization) => GetAlphabet(GetAlphabetType(localization));

        public static Alphabet GetAlphabetType(Localization localization)
        {
            switch (localization)
            {
                case Localization.EN:
                    return Alphabet.EN;
                case Localization.RU:
                    return Alphabet.RU;
                default:
                    throw new ArgumentException();
            }
        }

        public static char? ConvertToLetter(KeyCode keyCode, Localization localization)
        {
            switch (localization)
            {
                case Localization.RU:
                    return ConvertToRU(keyCode);
                case Localization.EN:
                    return ConvertToEN(keyCode);
                default:
                    throw new ArgumentException();
            }
        }

        private static char? ConvertToEN(KeyCode keyCode)
        {
            if (keyCode >= KeyCode.A && keyCode <= KeyCode.Z)
                return keyCode.ToString()[0];
            else
                return null;
        }

        private static char? ConvertToRU(KeyCode keyCode)
        {
            switch (keyCode)
            {
                case KeyCode.A: return 'Ф';
                case KeyCode.B: return 'И';
                case KeyCode.C: return 'С';
                case KeyCode.D: return 'В';
                case KeyCode.E: return 'У';
                case KeyCode.F: return 'А';
                case KeyCode.G: return 'П';
                case KeyCode.H: return 'Р';
                case KeyCode.I: return 'Ш';
                case KeyCode.J: return 'О';
                case KeyCode.K: return 'Л';
                case KeyCode.L: return 'Д';
                case KeyCode.M: return 'Ь';
                case KeyCode.N: return 'Т';
                case KeyCode.O: return 'Щ';
                case KeyCode.P: return 'З';
                case KeyCode.Q: return 'Й';
                case KeyCode.R: return 'К';
                case KeyCode.S: return 'Ы';
                case KeyCode.T: return 'Е';
                case KeyCode.U: return 'Г';
                case KeyCode.V: return 'М';
                case KeyCode.W: return 'Ц';
                case KeyCode.X: return 'Ч';
                case KeyCode.Y: return 'Н';
                case KeyCode.Z: return 'Я';
                case KeyCode.LeftBracket:
                case KeyCode.LeftCurlyBracket: return 'Х';
                case KeyCode.RightBracket:
                case KeyCode.RightCurlyBracket: return 'Ъ';
                case KeyCode.Semicolon:
                case KeyCode.Colon: return 'Ж';
                case KeyCode.Quote:
                case KeyCode.DoubleQuote: return 'Э';
                case KeyCode.Comma:
                case KeyCode.Less: return 'Б';
                case KeyCode.Period:
                case KeyCode.Greater: return 'Ю';
                case KeyCode.BackQuote:
                case KeyCode.Tilde: return 'Ё';
                default:
                    return null;
            }
        }
    }
}

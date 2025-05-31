using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace practic_13
{
    /*class TextOperations
    {
        #region Основные операции с текстом
        public static string RemoveTextInBrackets(string text)
        {
            int start, end;
            while ((start = text.IndexOf('(')) != -1 && (end = text.IndexOf(')')) != -1 && end > start)
            {
                text = text.Remove(start, end - start + 1);
            }
            return text;
        }
        public static int CountWordOccurrences(string text, string word)
        {
            return text.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                      .Count(w => w.Equals(word, StringComparison.OrdinalIgnoreCase));
        }
        public static string ReplaceSpacesWithCommas(string text)
        {
            return string.Join(", ", text.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries));
        }
        #endregion
        #region Анализ текста
        public static double PercentageOfWordsStartingWithK(string text)
        {
            var words = text.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (words.Length == 0) return 0;
            return (double)words.Count(w => w.StartsWith("К", StringComparison.OrdinalIgnoreCase)) / words.Length * 100;
        }
        public static bool ContainsNonLettersOrSpaces(string text)
        {
            return text.Any(c => !char.IsLetter(c) && !char.IsWhiteSpace(c));
        }
        #endregion
        #region Преобразования строк

        public static string RemoveDigits(string text)
        {
            return new string(text.Where(c => !char.IsDigit(c)).ToArray());
        }
        public static string RemoveCharsInAsciiRange(string text)
        {
            return new string(text.Where(c => c < 70 || c > 75).ToArray());
        }
        public static bool ContainsTwoFoursInRow(string text)
        {
            return text.Contains("44");
        }
        public static string InsertSpaceAfterDigits(string text)
        {
            var sb = new StringBuilder();
            foreach (char c in text)
            {
                sb.Append(c);
                if (char.IsDigit(c)) sb.Append(' ');
            }
            return sb.ToString();
        }
        public static string IncrementDigits(string text)
        {
            return new string(text.Select(c =>
                char.IsDigit(c) ? (char)((c - '0' + 1) % 10 + '0') : c).ToArray());
        }
        public static string ReorderDigitsAndLetters(string text)
        {
            var digits = text.Where(char.IsDigit);
            var letters = text.Where(char.IsLetter);
            return new string(digits.Concat(letters).ToArray());
        }
        public static string ToUpper(string text)
        {
            return text.ToUpper();
        }
        public static string ShiftLetters(string word)
        {
            if (string.IsNullOrEmpty(word)) return word;
            return word[^1] + word[..^1];
        }
        public static string FormatDigitsInGroups(string digits)
        {
            var cleanDigits = new string(digits.Where(char.IsDigit).ToArray());
            var sb = new StringBuilder();
            for (int i = 0; i < cleanDigits.Length; i++)
            {
                sb.Append(cleanDigits[i]);
                if ((i + 1) % 5 == 0) sb.Append(' ');
            }
            return sb.ToString().Trim();
        }
        public static string ShiftAsciiCodes(string text)
        {
            return new string(text.Select(c => (char)(c + 3)).ToArray());
        }
        #endregion
        #region Функции для работы с цифрами
        public static int[] SumOfDigitsDivisibleByThree(params string[] texts)
        {
            return texts.Select(text =>
                text.Where(char.IsDigit)
                   .Select(c => c - '0')
                   .Where(d => d % 3 == 0)
                   .Sum()).ToArray();
        }
        public static (int sum1, int sum2) SumOfDigitsInStrings(string text1, string text2)
        {
            int SumDigits(string t) => t.Where(char.IsDigit).Sum(c => c - '0');
            return (SumDigits(text1), SumDigits(text2));
        }
        public static int CountCharsWithAsciiOver70(string text)
        {
            return text.Count(c => c >= 70);
        }
        #endregion
        #region Процедуры для модификации строк
        public static void AppendChars(ref string text, int count, char symbol)
        {
            text += new string(symbol, count);
        }
        public static void RemoveSpaces(ref string text)
        {
            text = text.Replace(" ", "");
        }
        public static void ReverseWord(ref string word)
        {
            word = new string(word.Reverse().ToArray());
        }
        public static string[] SplitIntoLines(string text, int k)
        {
            return Enumerable.Range(0, (text.Length + k - 1) / k)
                           .Select(i => text.Substring(i * k, Math.Min(k, text.Length - i * k)))
                           .ToArray();
        }
        public static void InsertSpacesEveryN(ref string text, int n, int k)
        {
            var sb = new StringBuilder();
            for (int i = 0; i < text.Length; i++)
            {
                sb.Append(text[i]);
                if ((i + 1) % n == 0) sb.Append(' ', k);
            }
            text = sb.ToString();
        }
        public static void ReplaceWord(ref string text, string a1, string a2)
        {
            text = text.Replace(a1, a2);
        }
        public static void ReplaceCharInWord(ref string word, char oldChar, char newChar)
        {
            word = word.Replace(oldChar, newChar);
        }
        public static void NormalizeSpaces(ref string text)
        {
            text = string.Join(" ", text.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries));
        }
        public static void ReplaceCharInStrings(ref string s1, ref string s2, ref string s3, char oldChar, char newChar)
        {
            s1 = s1.Replace(oldChar, newChar);
            s2 = s2.Replace(oldChar, newChar);
            s3 = s3.Replace(oldChar, newChar);
        }
        public static void InsertExclamationAfterDigits(ref string s1, ref string s2, ref string s3)
        {
            s1 = InsertAfterDigits(s1, '!');
            s2 = InsertAfterDigits(s2, '!');
            s3 = InsertAfterDigits(s3, '!');

            static string InsertAfterDigits(string s, char c)
            {
                var sb = new StringBuilder();
                foreach (char ch in s)
                {
                    sb.Append(ch);
                    if (char.IsDigit(ch)) sb.Append(c);
                }
                return sb.ToString();
            }
        }
        public static void ReplaceSpacesWithUnderscores(ref string text)
        {
            text = text.Replace(' ', '_');
        }
        public static void RemoveChars(ref string text, params char[] charsToRemove)
        {
            text = new string(text.Where(c => !charsToRemove.Contains(c)).ToArray());
        }
        #endregion
    }
    class Program
    {
        static void Main()
        {
            string text = "Пример (текста в скобках) для теста";
            Console.WriteLine(TextOperations.RemoveTextInBrackets(text));

            Console.WriteLine(TextOperations.CountWordOccurrences("раз два три раз", "раз"));

            string digits = "1234567890";
            Console.WriteLine(TextOperations.IncrementDigits(digits));

            string word = "шифр";
            TextOperations.ReverseWord(ref word);
            Console.WriteLine(word);

            string s1 = "a1", s2 = "b2", s3 = "c3";
            TextOperations.ReplaceCharInStrings(ref s1, ref s2, ref s3, '1', 'X');
            Console.WriteLine($"{s1}, {s2}, {s3}");
        }
    }*/
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EncryptingApp
{
    public static class Encrypting
    {
        /// <summary>
        /// Return encrypted string
        /// </summary>
        /// <param name="text">Input string</param>
        /// <param name="n">Repeats of encrypting</param>
        /// <returns></returns>
        public static string Encrypt(string text, int n)
        {
            if (string.IsNullOrEmpty(text) || n <= 0)
            {
                return text;
            }

            text = text.ToLower();

            while (n != 0)
            {
                string outputTextPart2 = default;
                string outputTextPart1 = default;
                string outputText = default;

                n--;

                for (int i = 0; i < text.Length; i++)
                {
                    if (i % 2 == 0)
                    {
                        outputTextPart2 += text[i];
                    }
                    else
                    {
                        outputTextPart1 += text[i];
                    }
                    outputText = outputTextPart1 + outputTextPart2;
                }

                text = outputText;
            }

            return text;
        }

        /// <summary>
        /// Return decrypted string
        /// </summary>
        /// <param name="encryptedText">Input string</param>
        /// <param name="n">Repeats of decrypting</param>
        /// <returns></returns>
        public static string Decrypting(string encryptedText, int n)
        {
            if (string.IsNullOrEmpty(encryptedText) || n <= 0)
            {
                return encryptedText;
            }

            encryptedText = encryptedText.ToLower();

            while (n != 0)
            {
                string outputText = default;
                int middle = (encryptedText.Length / 2);

                n--;

                for (int i = 0; i < middle; i++)
                {
                    outputText += encryptedText[i + middle];
                    outputText += encryptedText[i];

                    if (encryptedText.Length % 2 != 0 && i == middle - 1)
                    {
                        outputText += encryptedText[encryptedText.Length - 1];
                    }
                }

                encryptedText = outputText;
            }

            return encryptedText;
        }

        /// <summary>
        /// Return 3 most common word
        /// </summary>
        /// <param name="text">Input string</param>
        /// <returns></returns>
        public static string[] MostCommonWords(string text)
        {
            text = text.ToLower();

            char[] separators = { '\\', '/', ',', '.', '?', '!', ';', '{', '}', '[', ']', ':', '*', '@', '#', '$', '№', '&', '+', '<', '>', '|', '~', '`', '"', '_', '^', '(', ')', ' ' };

            var newText = text.Split(separators, StringSplitOptions.RemoveEmptyEntries).ToList();

            for (int i = newText.Count -1 ; i >= 0; i--)
            {
                if (newText[i].Equals("-"))
                {
                    newText.RemoveAt(i); ;
                }
            }

            int[] counter = new int[newText.Count];
            List<(string word, int number)> textList = new List<(string myString, int myInt)>();

            for (int i = newText.Count - 1; i >= 0; i--)
            {
                for (int j = i - 1; j >= 0; j--)
                {
                    if (newText[i].Equals(newText[j]))
                    {
                        counter[i] += 1;
                    }
                }
                textList.Add((newText[i], counter[i]));
            }
            var topThreeWords = textList.Distinct().OrderByDescending(x => x.number).Take(3).Where(x => x.number > 0);
            var sortedArray = topThreeWords.Select(x => x.word).ToArray();

            if (sortedArray.Length < 3)
            {
                Array.Clear(sortedArray, 0, sortedArray.Length);
                return sortedArray;
            }

            return sortedArray;
        }
    }
}

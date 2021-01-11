using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

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
                StringBuilder outputTextPart2 = new StringBuilder();
                StringBuilder outputTextPart1 = new StringBuilder();
                string outputText = default;

                n--;

                for (int i = 0; i < text.Length; i++)
                {
                    if (i % 2 == 0)
                    {
                        outputTextPart2.Append(text[i]);
                        //outputTextPart2 += text[i];
                    }
                    else
                    {
                        outputTextPart1.Append(text[i]);
                        //outputTextPart1 += text[i];
                    }
                    outputText = outputTextPart1.ToString() + outputTextPart2.ToString();
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
        public static string Decrypt(string encryptedText, int n)
        {
            if (string.IsNullOrEmpty(encryptedText) || n <= 0)
            {
                return encryptedText;
            }

            encryptedText = encryptedText.ToLower();

            while (n != 0)
            {
                StringBuilder outputText = new StringBuilder();
                int middle = (encryptedText.Length / 2);

                n--;

                for (int i = 0; i < middle; i++)
                {
                    outputText.Append(encryptedText[i + middle]);
                    outputText.Append(encryptedText[i]);

                    if (encryptedText.Length % 2 != 0 && i == middle - 1)
                    {
                        outputText.Append(encryptedText[encryptedText.Length - 1]);
                    }
                }

                encryptedText = outputText.ToString();
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

            Regex regex = new Regex("[a-z]{1,}[',-][a-z]{1,}|[a-z]{1,}", RegexOptions.IgnoreCase);
            var newText = regex.Matches(text).ToList();

            for (int i = newText.Count - 1; i >= 0; i--)
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
                    if (newText[i].Value.Equals(newText[j].Value))
                    {
                        counter[i] += 1;
                    }
                }
                textList.Add((newText[i].Value, counter[i]));
            }

            var orderedList = textList.OrderByDescending(x => x.number).ToList();

            for (int i = 0; i < 3; i++)
            {
                if (orderedList.Count < 3)
                {
                    Array.Clear(orderedList.ToArray(), 0, orderedList.Count);
                    break;
                }

                else if (orderedList[i].word.Equals(orderedList[i + 1].word))
                {
                    orderedList.RemoveAt(1);
                    i--;
                }
            }

            var sortedArray = orderedList.Take(3).Select(x => x.word).ToArray();

            return sortedArray;
        }
    }
}

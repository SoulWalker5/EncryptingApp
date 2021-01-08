using System;

namespace EncryptingApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Encrypted string is: " + Encrypting.Encrypt("", 1));
            Console.WriteLine("Decrypted string is: " + Encrypting.Decrypting("", 1));
            Console.WriteLine("Encrypted string is: " + Encrypting.Encrypt(null, 1));
            Console.WriteLine("Decrypted string is: " + Encrypting.Decrypting(null, 1));
            Console.WriteLine("Encrypted string is: " + Encrypting.Encrypt("Abcdefghij", 1));
            Console.WriteLine("Decrypted string is: " + Encrypting.Decrypting("bdfhacegi", 1));
            Console.WriteLine("Encrypted string is: " + Encrypting.Encrypt("Abcdefghi", 1));
            Console.WriteLine("Decrypted string is: " + Encrypting.Decrypting("bdfhjacegi", 1));
            Console.WriteLine("Encrypted string is: " + Encrypting.Encrypt("Abcdefghij", 2));
            Console.WriteLine("Decrypted string is: " + Encrypting.Decrypting("dhcgbfaei", 2));

            var hz = "ajhsgfuyatgiuyf two-way two-way - -";
            foreach (var item in Encrypting.MostCommonWords(hz))
            {
                Console.WriteLine(item);
            }

            var hz1 = "Lorem Ipsum is simply dummy text of the printing and typesetting industry." +
                " Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, " +
                "when an unknown printer took a galley of type and scrambled it to make a type specimen book. " +
                "It has survived not only five centuries, but also the leap into electronic typesetting," +
                " remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset" +
                " sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like" +
                " Aldus PageMaker including versions of Lorem Ipsum.";

            foreach (var item in Encrypting.MostCommonWords(hz1))
            {
                Console.WriteLine(item);
            }
        }
    }
}

using System;
using System.Text.RegularExpressions;
using System.Linq;
//using System.Collections.Generic;

namespace Task02_Emoji_Detector
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            string numbersPatern = @"\d";
            Regex extractNumber = new Regex(numbersPatern);

            MatchCollection numbersInText = extractNumber.Matches(text);

            long coolThreshold = 1;

            foreach (Match item in numbersInText)
            {
                coolThreshold *= int.Parse(item.Value);
            }

            Console.WriteLine($"Cool threshold: {coolThreshold}");

            string emojiesPatern = @"(\*\*|::)([A-Z][a-z]{2,})(\1)";
            Regex extractEmojies = new Regex(emojiesPatern);

            MatchCollection emojiesInText = extractEmojies.Matches(text);

            Console.WriteLine($"{emojiesInText.Count} emojis found in the text. The cool ones are:");

            foreach (Match item in emojiesInText)
            {
                int sumASCII = 0;
                int count = 1;
                foreach (char letter in item.Value)
                {
                    if (1 < count && count < item.Value.Length - 2)
                    {
                        sumASCII += letter;
                    }
                    count++;
                }

                if (sumASCII >= coolThreshold)
                {
                    Console.WriteLine(item);
                }
            }

            /*
            List<string> coolEmojies = new List<string>();
            
            foreach (Match item in emojiesInText)
            {
                int sumASCII = 0;
                int count = 1;
                foreach (char letter in item.Value)
                {
                    if(1 < count && count < item.Value.Length - 2)
                    {
                        sumASCII += letter;
                    }
                    count++;
                }

                if(sumASCII >= coolThreshold)
                {
                    coolEmojies.Add(item.Value);
                }
            }

            if(coolEmojies.Count > 0)
            {
                Console.WriteLine($"{emojiesInText.Count} emojis found in the text. The cool ones are:");
                foreach (var item in coolEmojies)
                {
                    Console.WriteLine(item);
                }
            }
            */
        }
    }
}

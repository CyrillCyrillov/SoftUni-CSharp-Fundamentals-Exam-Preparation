using System;
using System.Text;

namespace Exam_Preparatione
{
    class Program
    {
        static void Main(string[] args)
        {
            string rawActivationKey = Console.ReadLine();

            while (true)
            {
                string nextComandsLine = Console.ReadLine();

                if(nextComandsLine.ToUpper() == "GENERATE" )
                {
                    break;
                }


                string[] nextComand = nextComandsLine.Split(">>>", StringSplitOptions.RemoveEmptyEntries);

                switch (nextComand[0])
                {
                    case "Contains":

                        string substring = nextComand[1];

                        if(rawActivationKey.Contains(substring))
                        {
                            Console.WriteLine($"{rawActivationKey} contains {substring}");
                        }
                        else
                        {
                            Console.WriteLine("Substring not found!");
                        }

                        break;

                    
                    case "Flip":

                        string typeFlip = nextComand[1].ToUpper();
                        int startIndex = int.Parse(nextComand[2]);
                        int endIndex = int.Parse(nextComand[3]);

                        string firstPart = rawActivationKey.Substring(0, startIndex);
                        string flipPart = rawActivationKey.Substring(startIndex, endIndex - startIndex);
                        string lastPart = rawActivationKey.Substring(endIndex, rawActivationKey.Length - endIndex);
                        

                        if(typeFlip == "UPPER")
                        {
                            flipPart = flipPart.ToUpper();
                        }
                        else
                        {
                            flipPart = flipPart.ToLower();
                        }

                        rawActivationKey = firstPart + flipPart + lastPart;

                        Console.WriteLine(rawActivationKey);

                        break;

                    
                    case "Slice":
                        
                        int startIndexSlice = int.Parse(nextComand[1]);
                        int endIndexSlice = int.Parse(nextComand[2]);

                        rawActivationKey = rawActivationKey.Remove(startIndexSlice, endIndexSlice - startIndexSlice);

                        Console.WriteLine(rawActivationKey);

                        break;

                    default:
                        break;
                }
            }

            Console.WriteLine($"Your activation key is: {rawActivationKey}");
        }
    }
}

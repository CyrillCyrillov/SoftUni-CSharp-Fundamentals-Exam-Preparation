using System;
using System.Linq;
using System.Collections.Generic;

namespace Task03_P_rates
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<int>> cityTargets = new Dictionary<string, List<int>>();

            while (true)
            {
                                
                string[] cityDatas = Console.ReadLine().Split("||", StringSplitOptions.RemoveEmptyEntries);

                if(cityDatas[0].ToUpper() == "SAIL")
                {
                    break;
                }

                string name = cityDatas[0];
                int people = int.Parse(cityDatas[1]);
                int gold = int.Parse(cityDatas[2]);

                if(cityTargets.ContainsKey(name))
                {
                    cityTargets[name][0] += people;
                    cityTargets[name][1] += gold;
                }
                else
                {
                    cityTargets.Add(name, new List<int> { people, gold });
                }

            }

            /*
            foreach (var item in cityTargets)
            {
                Console.WriteLine($"{item.Key} : {item.Value[0]} : {item.Value[1]}");
            }
            */


            while (true)
            {
                string[] action = Console.ReadLine().Split("=>", StringSplitOptions.RemoveEmptyEntries);

                if(action[0].ToUpper() == "END")
                {
                    break;
                }

                string typeAction = action[0];

                switch (typeAction.ToUpper())
                {
                    case "PLUNDER":
                        string name = action[1];
                        int people = int.Parse(action[2]);
                        int gold = int.Parse(action[3]);

                        cityTargets[name][0] -= people;
                        cityTargets[name][1] -= gold;

                        Console.WriteLine($"{name} plundered! {gold} gold stolen, {people} citizens killed.");

                        if (cityTargets[name][0] <= 0 || cityTargets[name][1] <= 0)
                        {
                            cityTargets.Remove(name);
                            Console.WriteLine($"{name} has been wiped off the map!");
                        }
                        break;

                    case "PROSPER":
                        name = action[1];
                        gold = int.Parse(action[2]);

                        if(gold < 0)
                        {
                            Console.WriteLine($"Gold added cannot be a negative number!");
                        }
                        else
                        {
                            cityTargets[name][1] += gold;
                            Console.WriteLine($"{gold} gold added to the city treasury. {name} now has {cityTargets[name][1]} gold.");
                        }

                        break;

                    default:
                        break;
                }
            }

            /*
            foreach (var item in cityTargets)
            {
                Console.WriteLine($"{item.Key} : {item.Value[0]} : {item.Value[1]}");
            }
            */

            if(cityTargets.Count > 0)
            {
                Console.WriteLine($"Ahoy, Captain! There are {cityTargets.Count} wealthy settlements to go to:");
                foreach (var item in cityTargets.OrderByDescending(x => x.Value[1]).ThenBy(x => x.Key))
                {
                    Console.WriteLine($"{item.Key} -> Population: {item.Value[0]} citizens, Gold: {item.Value[1]} kg");
                }
            }
            else
            {
                Console.WriteLine("Ahoy, Captain! All targets have been plundered and destroyed!");
            }
        }
    }
}

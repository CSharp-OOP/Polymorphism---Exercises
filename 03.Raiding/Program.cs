using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Raiding
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int numberOfHeroes = int.Parse(Console.ReadLine());
            List<BaseHero> baseHeroes = new List<BaseHero>();

            while (baseHeroes.Count != numberOfHeroes)
            {
                string heroName = Console.ReadLine();
                string heroType = Console.ReadLine();

                switch (heroType)
                {
                    case "Druid":
                        baseHeroes.Add(new Druid(heroName));
                        break;
                    case "Paladin":
                        baseHeroes.Add(new Paladin(heroName));
                        break;
                    case "Rogue":
                        baseHeroes.Add(new Rogue(heroName));
                        break;
                    case "Warrior":
                        baseHeroes.Add(new Warrior(heroName));
                        break;
                    default:
                        Console.WriteLine("Invalid hero!");
                        break;
                }
            }

            int bossPower = int.Parse(Console.ReadLine());

            foreach (var hero in baseHeroes)
            {
                Console.WriteLine(hero.CastAbility());
            }

            int totalHeroesPower = baseHeroes.Sum(x => x.Power);

            if (totalHeroesPower >= bossPower)
            {
                Console.WriteLine("Victory!");
            }
            else
            {
                Console.WriteLine("Defeat...");
            }
        }
    }
}

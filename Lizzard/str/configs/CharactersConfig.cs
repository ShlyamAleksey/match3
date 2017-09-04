using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lizzard.str
{
    public class CharactersConfig
    {    
        public List<Character> characters;
        public int playerHealth = 300;
        public int playerPower = 5;
        public int totalEnemyEnergy = 200;
        public float energyPerTick = 20;
        private float _fullEnergyTime = 10000;
        public float tickTime = 25;
        static public int VS_COUNT = 6;

        public CharactersConfig()
        {
            characters = new List<Character>();
            energyPerTick = totalEnemyEnergy * tickTime / _fullEnergyTime;

            switch (Configuration.DIFFICULT)
            {
                case Configuration.CHEAT:
                    characters.Add(new Character("swamp fright", 3, 10));
                    characters.Add(new Character("boar", 3, 12));
                    characters.Add(new Character("werewolf", 3, 15));
                    characters.Add(new Character("mutant crocodile", 3, 18));
                    characters.Add(new Character("scavenger", 3, 21));
                    characters.Add(new Character("bone fear", 3, 24));
                    characters.Add(new Character("gorgon eater", 3, 27));
                    characters.Add(new Character("cyborg", 3, 30));
                    characters.Add(new Character("twins", 3, 33));
                    characters.Add(new Character("smoky preclinical", 3, 35));
                    characters.Add(new Character("the rebels horror", 3, 40));
                    break;
                case Configuration.EASY:
                    characters.Add(new Character("swamp fright", 7, 10));
                    characters.Add(new Character("boar", 15, 12));
                    characters.Add(new Character("werewolf", 23, 15));
                    characters.Add(new Character("mutant crocodile", 38, 18));
                    characters.Add(new Character("scavenger", 50, 21));
                    characters.Add(new Character("bone fear", 70, 24));
                    characters.Add(new Character("gorgon eater", 100, 27));
                    characters.Add(new Character("cyborg", 140, 30));
                    characters.Add(new Character("twins", 200, 33));
                    characters.Add(new Character("smoky preclinical", 300, 35));
                    characters.Add(new Character("the rebels horror", 500, 40));
                    break;
                case Configuration.MEDIUM:
                    characters.Add(new Character("swamp fright", 7, 10));
                    characters.Add(new Character("boar", 15, 12));
                    characters.Add(new Character("werewolf", 23, 15));
                    characters.Add(new Character("mutant crocodile", 38, 18));
                    characters.Add(new Character("scavenger", 55, 21));
                    characters.Add(new Character("bone fear", 80, 24));
                    characters.Add(new Character("gorgon eater", 130, 27));
                    characters.Add(new Character("cyborg", 200, 30));
                    characters.Add(new Character("twins", 300, 33));
                    characters.Add(new Character("smoky preclinical", 500, 35));
                    characters.Add(new Character("the rebels horror", 750, 40));
                    break;
                case Configuration.HARD:
                    characters.Add(new Character("swamp fright", 7, 10));
                    characters.Add(new Character("boar", 15, 12));
                    characters.Add(new Character("werewolf", 23, 15));
                    characters.Add(new Character("mutant crocodile", 38, 18));
                    characters.Add(new Character("scavenger", 61, 21));
                    characters.Add(new Character("bone fear", 99, 24));
                    characters.Add(new Character("gorgon eater", 160, 27));
                    characters.Add(new Character("cyborg", 259, 30));
                    characters.Add(new Character("twins", 419, 33));
                    characters.Add(new Character("smoky preclinical", 678, 35));
                    characters.Add(new Character("the rebels horror", 1000, 40));
                    break;
                default:
                    characters.Add(new Character("swamp fright", 7, 10));
                    characters.Add(new Character("boar", 15, 12));
                    characters.Add(new Character("werewolf", 23, 15));
                    characters.Add(new Character("mutant crocodile", 38, 18));
                    characters.Add(new Character("scavenger", 61, 21));
                    characters.Add(new Character("bone fear", 99, 24));
                    characters.Add(new Character("gorgon eater", 160, 27));
                    characters.Add(new Character("cyborg", 259, 30));
                    characters.Add(new Character("twins", 419, 33));
                    characters.Add(new Character("smoky preclinical", 678, 35));
                    characters.Add(new Character("the rebels horror", 1000, 40));
                    break;
            }        
        }
    }

    public class Character
    {
        public int health;
        public int power;
        public string name;

        public Character(string _name, int _health, int _power)
        {
            this.name = _name;
            this.health = _health;
            this.power = _power;
        }
    }
}

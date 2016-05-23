using System;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Samohra
{
    class Character
    {
        public string race { get; set; }
        public string prof { get; set; }
        public string name { get; set; }
        
        public int _attack;
        public int _defense;
        public int hp;
        public int playerHpFull;
        public int playerAttackDef;
        public int playerDefenseDef;
        Random gen = new Random();

        public void showDetails()
        {
            Console.Clear();
            Console.WriteLine("*****=====*****=====*****=====*****====*****=====*****=====*****=====*****====*****=====*****\n");
            Console.WriteLine("S.P.G ~~ Self-Playing Game");
            Console.WriteLine("--------------------------\n");
            Console.WriteLine(" >> OVERVIEW <<\n");
            Console.WriteLine("Name:       {0}", name);
            Console.WriteLine("Race:       {0}", race);
            Console.WriteLine("Profession: {0}", prof);
            Console.WriteLine("Health:     {0}", hp);
            Console.WriteLine("Attack:     {0}", _attack);
            Console.WriteLine("Defense:    {0}\n", _defense);
            Console.WriteLine("*****=====*****=====*****=====*****====*****=====*****=====*****=====*****====*****=====*****\n");
        }
        public void genStats()
        {
            _attack = gen.Next(20, 24);
            _defense = gen.Next(13, 18);
            playerAttackDef = _attack;
            playerDefenseDef = _defense;
        }
        public void statsToDefault()
        {
            hp = playerHpFull;
            _attack = playerAttackDef;
            _defense = playerDefenseDef;

        }

        public int playerAttackNumber()
        {
            int modifier = 0;
            switch (prof)
            {
                case "Warrior":
                    modifier = gen.Next(1, 7);
                    break;
                case "Rogue":
                    modifier = gen.Next(1, 10);
                    break;
                case "Mage":
                    modifier = gen.Next(1, 13);
                    break;
            }
            _attack = playerAttackDef + modifier;
            return _attack;
        }
        public int playerDefenseNumber()
        {
            int modifier = 0;
            switch (prof)
            {
                case "Warrior":
                    modifier = gen.Next(1, 13);
                    break;
                case "Rogue":
                    modifier = gen.Next(1, 9);
                    break;
                case "Mage":
                    modifier = gen.Next(1, 6);
                    break;
            }
            _defense = playerDefenseDef + modifier;
            return _defense;
        }

    }
}

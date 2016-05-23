using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Samohra
{
    class Enemy
    {
        public string race { get; set; }
        public string prof { get; set; }
        public string name { get; set; }

        public int _attack;
        public int _defense;
        public int hp;
        public int enemyHpFull;
        public int enemyAttackDef;
        public int enemyDefenseDef;
        Random rnd = new Random();
        
        public void genEnemyStats()
        {
            
            _attack = rnd.Next(17, 22);
            _defense = rnd.Next(13, 18);
            hp = rnd.Next(20, 27);
            enemyHpFull = hp;
            enemyAttackDef = _attack;
            enemyDefenseDef = _defense;
        }
        public void genEnemyName()
        {
            string[] types = { "Weak", "Normal", "Strong", "Elite", "Boss", "Champion" };
            string[] states = { "Freaked", "Sleepy", "Weird", "Miniature","Mysterious", "Flat", "Calm", "Wild",
            "Curious", "Lackadaisical","Smooth-looking", "Little", "Elderly","Hypnotic","Tall","Smiling","Disagreeable"};
            string[] mobs = { "Squirrel", "Deer", "Hippopotamus", "Snowy Owl", "Mandrill","Ibex", "Seal",
                "Gila Monster", "Impala", "Gopher", "Gnu", "Rabbit", "Lamb", "Guanaco", "Otter","Crocodile"};

            name = states[rnd.Next(0, states.Length - 1)] + " " + mobs[rnd.Next(0, mobs.Length - 1)];


        }
        
        public int enemyAttackNumber()
        {
            int modifier = rnd.Next(1, 7);
            _attack = enemyAttackDef + modifier;
            return _attack;
        }
        public int enemyDefenseNumber()
        {
            int modifier = rnd.Next(1, 7);
            _defense = enemyDefenseDef + modifier;
            return _defense;
        }

    }
}

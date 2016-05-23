using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Samohra
{
    class Play
    {
        private Random rng;
        Character player = new Character();
        Enemy mob = new Enemy();
        bool _keepPlaying = true;
        string _keepChar;
        bool _keepCharacter = false;
        int killStreak = 0;
        

        public void Game() {
            while (_keepPlaying)
            {
                if (_keepCharacter == false)
                {
                    CreateChar();
                }                     
            CreateEnemy();
            showEnemy();
            Round();
            againPrompt();
            }
            
        }

        private void DetermineWinner(int round)
        {
            if (player.hp > 0)
            {
                killStreak++;
                Console.WriteLine("Congratulations, you managed to kill {0} in round {1}", mob.name, round);
                killStreakReveal();                
                Console.WriteLine("*****=====*****=====*****=====*****====*****=====*****=====*****=====*****====*****=====*****\n");
                
            }
            else {
                Console.WriteLine("You lost and your epic journey ends here..");
                killStreakReveal();
                Console.WriteLine("*****=====*****=====*****=====*****====*****=====*****=====*****=====*****====*****=====*****\n");
            }
                       
        }

        private void killStreakReveal()
        {
            if (killStreak > 1)
            {
                Console.WriteLine("You killed {0} monsters, good job!\n", killStreak);
            }
            else if (killStreak == 0)
            {
                Console.WriteLine("You didn't kill a single monster! No songs will tell about your heroism!");
            }
            else
            {
                Console.WriteLine("You killed {0} monster in your lifetime!\n", killStreak);
            }
        }

        private void againPrompt()
        {
            string choice;
            
            if (player.hp == 0)
            {
                Console.Write("If you want to play again, you have to create another character. Enter or N...  ");
                choice = Console.ReadLine().ToLower();
                if (choice != "n")
                {
                    _keepPlaying = true;
                    _keepCharacter = false;
                }
                else { _keepPlaying = false; }
            }
            else
            {
                Console.Write("Do you want to continue on your epic journey? Enter or N...  ");
                choice = Console.ReadLine().ToLower();
                if (choice != "n")
                {
                    _keepPlaying = true;
                    Console.Write("\nExcellent! Now do you want to keep your character? Enter or N  ");
                    _keepChar = Console.ReadLine().ToLower();
                    if (_keepChar != "n")
                    {
                        _keepCharacter = true;
                        player.statsToDefault();
                        killStreak = 0;
                    }
                }
                else
                {
                    _keepPlaying = false;
                    Console.WriteLine("OK, See you next time!");
                    Console.ReadLine();
                }
            }
        }                

        private void Round()
        {
            int round = 1;
            while (_keepPlaying)
            {
                AttackMob();
                    if (_keepPlaying)
                    {
                        AttackPlayer();
                        roundOverview(round);
                        Console.WriteLine("Press enter to continue!");
                        Console.ReadLine();
                        round++;
                    }
                    else
                    { roundOverview(round);
                    break; }
                      
            }
            DetermineWinner(round);
        }
        private void roundOverview(int round)
        {
            Console.Clear();
            Console.WriteLine("*****=====*****=====*****=====*****====*****=====*****=====*****=====*****====*****=====*****\n");
            Console.WriteLine("S.P.G ~~ Self-Playing Game");
            Console.WriteLine("--------------------------\n");
            Console.WriteLine(">>ROUND {0}<<\n", round);
            showOverview();
            if (mob._defense >= player._attack)
            {
                Console.WriteLine("Your attack didn't deal a single damage to {0}!", mob.name);
                Console.WriteLine("---------------");
            }
            else
            {
                Console.WriteLine("You surprised the {0} and dealt {1} damage! {0}'s health is now {2}", mob.name, System.Math.Abs(mob._defense - player._attack), mob.hp);
                Console.WriteLine("---------------");
            }
            if (player._defense >= mob._attack)
            {
                if (mob.hp == 0 || player.hp == 0) { _keepPlaying = false; }
                else { 
                Console.WriteLine("The {0} is no match for such a hero as yourself, you've received 0 damage!\n", mob.name); }
            }
            else {
                if (mob.hp == 0 || player.hp == 0) { _keepPlaying = false; }
                else
                {
                    Console.WriteLine("The {0} took that really personally and dealt {1} damage to you,\nwhich left you with {2} health\n", mob.name, System.Math.Abs(player._defense - mob._attack), player.hp);
                }
            }            
        }
        private void isAlive(int a)
        {
            if (a == 0)
            {
                _keepPlaying = false;
            }

        }
        private void showOverview()
        {
            Console.WriteLine(">> YOU <<\t\t >> ENEMY <<\n");
            Console.WriteLine("Name:    {0}\t\tName:    {1}", player.name, mob.name);
            Console.WriteLine("Health:  {0}\t\tHealth:  {1}\n", player.hp, mob.hp);
            //Console.WriteLine("Attack:  {0}\t\tAttack:  {1}", player._attack, mob._attack);
            //Console.WriteLine("Defense: {0}\t\tDefense: {1}\n", player._attack, mob._defense);
        }

        public int AttackMob()
        {                      
            player.playerAttackNumber();
            mob.enemyDefenseNumber();
            if (mob._defense < player._attack)
            {
                mob.hp -= System.Math.Abs(mob._defense - player._attack);
                if (mob.hp <= 0)
                { 
                mob.hp = 0;
                _keepPlaying = false;
                return mob.hp;
                }

            else
                return mob.hp;
            }

            else
                return mob.hp;

        }
        public int AttackPlayer()
        {
            player.playerDefenseNumber();
            mob.enemyAttackNumber();            
            if (player._defense < mob._attack)
            { 
                player.hp -= System.Math.Abs(player._defense - mob._attack);
                if (player.hp <= 0)
                {
                    player.hp = 0;
                    _keepPlaying = false;
                    return player.hp;
                }
                else return player.hp;
            }
            else 
                return player.hp;
        }

        public void CreateChar()
        {                                  
            rng = new Random();
            Console.Clear();     
            Console.WriteLine("*****=====*****=====*****=====*****====*****=====*****=====*****=====*****====*****=====*****\n");
            Console.WriteLine("Welcome to S.P.G. or Self-Playing Game!");
            Console.WriteLine("---------------------------------------\n");
            Console.WriteLine("In this game you'll create your own character you'll be playing with. You can choose a race,\n"+
                "profession and a name and change it as much as you like. Then you'll embark on an epic journey\n"+
                "with hundreds of deadly monsters standing in your way trying to ... well ... KILL you. Figures.\n"+
                "Your job is to slice through each and every one of them.\n\n"+
                "Good luck traveler, we may see each other again...\n");

            Console.WriteLine("*****=====*****=====*****=====*****====*****=====*****=====*****=====*****====*****=====*****");

            Console.ReadLine();
            Console.Clear();
            changeStats(player.name, player.race, player.prof);                                  
        }
        public void CreateEnemy()
        {
            mob.genEnemyName();
            mob.genEnemyStats();
        }

        private void changeStats(string a, string b, string c)
        {
                a = Prompt(0);
                Console.Clear();
                Console.WriteLine("*****=====*****=====*****=====*****====*****=====*****=====*****=====*****====*****=====*****\n");
                Console.WriteLine("S.P.G ~~ Self-Playing Game");
                Console.WriteLine("--------------------------\n");
                Console.WriteLine(" >> You sit beside the other Adventurer <<\n");
                Console.WriteLine("ADVENTURER: \"So you're {0} I see. I thought so, just wanted to be sure. Cheers...\n\t     And how exactly do you keep yourself alive my friend?? \"\n", raceConvert(a));
                Console.WriteLine("*****=====*****=====*****=====*****====*****=====*****=====*****=====*****====*****=====*****");                              
                b = Prompt(1);
                Console.Clear();
                Console.WriteLine("*****=====*****=====*****=====*****====*****=====*****=====*****=====*****====*****=====*****\n");
                Console.WriteLine("S.P.G ~~ Self-Playing Game");
                Console.WriteLine("--------------------------\n");
                Console.WriteLine(" >> You took a mighty sip from your goblet ..  <<\n");
                Console.WriteLine("ADVENTURER: \"Okay, so you're {0} and a {1} ? Interesting... Well I think I've kept you\n\t     long enough. I can feel that you're eager to display your skills in battle.\n\t     All you need to do is just walk through that door...\n\t     Oh and how do they call you, traveler?\"\n", raceConvert(a), roleConvert(b));
                Console.WriteLine("*****=====*****=====*****=====*****====*****=====*****=====*****=====*****====*****=====*****");
                c = Prompt(2);
                setStats(a, b, c);
                player.showDetails();                
                wantToChange(a,b,c);               
                            
        }
        private void wantToChange(string a, string b, string c)
        {
            bool want = true;
            while (want)
            {                
                Console.Write("Now, do you want to change anything before we proceed? Y or N...\nThis will overwrite the current data!\n");
                string choice = Console.ReadLine().ToLower();                
                switch (choice)
                    {
                    case "y":
                        changeStats(a, b, c);
                        break;
                    case "n":
                        want = false;
                        break;
                    default:
                        Console.WriteLine("Please type Y or N only..");
                        break;                            
                    }
                }
            
        }
        private void setStats(string a, string b, string c)
        {
            player.name = c;
            player.race = raceConvert(a);
            player.prof = roleConvert(b);
            player.genStats();
            player.hp = rng.Next(20, 27);
            player.playerHpFull = player.hp;
        }
        
        private string Prompt(int type)
        {
            
            
            while (true)
            {
                if (type == 0) //racePrompt
                {
                    Console.Clear();
                    Console.WriteLine("*****=====*****=====*****=====*****====*****=====*****=====*****=====*****====*****=====*****\n");
                    Console.WriteLine("S.P.G ~~ Self-Playing Game");
                    Console.WriteLine("--------------------------\n");
                    Console.WriteLine(" >> You enter a tavern <<\n");
                    Console.WriteLine("INNKEEPER: \"Greetings traveler! How can I help you? Drink? Food? Here at the Tiny Dragon's\n\t    we have all that your heart could ever desire. Unless you want to kill some\n\t    monsters of course, there's plenty of them outside.\"\n");
                    Console.WriteLine("MAN:\t   \"Here, sit beside me! So I take it you want to be an adventurer, huh? Excelent!\n\t    Tell me something about yourself and take that cape away, I can't see your face.\"\n");
                    Console.WriteLine("*****=====*****=====*****=====*****====*****=====*****=====*****=====*****====*****=====*****");
                    Console.Write("\nDo you want to be a (H)uman, (E)lf or a (D)warf?  ");
                    string value = Console.ReadLine().ToLower();
                    if (value == "h" || value == "e" || value == "d")
                    { return value; }
                    else Console.WriteLine("That was not a correct choice!");
                }
                else if (type == 1) //rolePrompt
                {
                    Console.Write("\nNow let's chose whether you'll be (W)arrior, (R)ogue or (M)age  ");
                    string value = Console.ReadLine().ToLower();
                    if (value == "w" || value == "r" || value == "m")
                        return value;
                    else Console.WriteLine("That was not a correct choice!");
                }
                else //namePrompt
                {
                    Console.Write("\nNow please enter your name as you want to display it. ");
                    string nameValue = Console.ReadLine();
                    if (nameValue != null)
                        return nameValue;
                    else Console.WriteLine("Type something as a name!");
                }
            }                
            }        
        public string raceConvert(string a)
        {
            if (a == "h")
                return "Human";
            else if (a == "e")
                return "Elf";
            else
                return "Dwarf";
         
        }
        private string roleConvert(string a)
        {
            if (a == "w")
                return "Warrior";
            else if (a == "r")
                return "Rogue";
            else
                return "Mage";

        }

        private void showEnemy()
        {
            Console.Clear();
            Console.WriteLine("*****=====*****=====*****=====*****====*****=====*****=====*****=====*****====*****=====*****\n");
            Console.WriteLine("S.P.G ~~ Self-Playing Game");
            Console.WriteLine("--------------------------\n");
            Console.WriteLine(">> You opened the door, fearlessly walking towards danger <<\n");
            showOverview();            
            Console.WriteLine("*****=====*****=====*****=====*****====*****=====*****=====*****=====*****====*****=====*****\n");
            Console.WriteLine("The {0} on the road looks like your enemy ... press ENTER to attack", mob.name);
            Console.ReadLine();
        }
    }
}

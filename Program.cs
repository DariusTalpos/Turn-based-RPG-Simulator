using System;
//using Character;

namespace gametest
{
    class Program
    {
        static List<Skill> createSkills()
        {
            List<Skill> skilllist = new List<Skill>();
            Skill DragonFang= new Skill("Dragon's Fang", "causes high physical damage to one enemy", SkillType.ATTACK, DamageType.PHYSICAL, StatusEffect.NONE, AmountChance.HIGH);
            Skill DaggerThrow = new Skill("Dagger Throw", "causes low physical damage to one enemy", SkillType.ATTACK, DamageType.PHYSICAL, StatusEffect.NONE, AmountChance.LOW);
            //Skill AngelicPraise = new Skill("Angelic Praise", "low HP healing to self", SkillType.HEAL, DamageType.NONE, StatusEffect.NONE, AmountChance.LOW);
            Skill FlashStrike = new Skill("Flash Strike", "causes medium physical damage to one enemy", SkillType.ATTACK, DamageType.PHYSICAL, StatusEffect.NONE, AmountChance.MEDIUM);
            skilllist.Add(DragonFang);
            skilllist.Add(DaggerThrow);
            skilllist.Add(FlashStrike);
            //skilllist.Add(AngelicPraise);
            return skilllist;
        }
        static void Testing()
        {
            int nPlayable, nEnemies;
            List<Skill> skilllist= createSkills();
            List<Character> playable = new List<Character>();
            List<Character> enemies = new List<Character>();
            Console.WriteLine("\t\t\t\tWelcome to the TURN-BASED BATTLE SIMULATOR");
            Console.WriteLine("This simulator lets you create characters, choosing their stats and skills, and then battle against a chosen amount of enemies.");
            Console.WriteLine("Choose the number of characters you wish to control:");
            string numP = Console.ReadLine();
            nPlayable = Convert.ToInt32(numP);
            Console.WriteLine("You have chosen to create "+nPlayable+" characters");
            for(int i=1;i<=nPlayable;i++)
            {
                List<Skill> skills = new List<Skill>();
                Console.WriteLine("\nEnter the name of character number " +i+":");
                string chName = Console.ReadLine();
                Console.WriteLine("Enter " + chName + "'s HP stat:");
                int chHP = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter " + chName + "'s ATK stat:");
                int chATK = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter " + chName + "'s DEF stat:");
                int chDEF = Convert.ToInt32(Console.ReadLine());

                Character c1 = new Character(chName, chHP, chATK, chDEF,new List<Skill>());
                Console.WriteLine("Choose which 2 skills will " + chName + " inherit:");
                for (int j = 0; j < skilllist.Count; j++)
                    Console.WriteLine((j + 1) + "." + skilllist[j].getName() + " - " + skilllist[j].getDescriprion());
                Console.WriteLine("Choose the first skill that " + chName + " will inherit:");
                string code = Console.ReadLine();
                c1.addSkill(skilllist[Convert.ToInt32(code) - 1]);
                Console.WriteLine("Choose the second skill that " + chName + " will inherit:");
                code = Console.ReadLine();
                c1.addSkill(skilllist[Convert.ToInt32(code) - 1]);
                playable.Add(c1);
            }
            Console.WriteLine("Choose the number of characters you wish to fight:");
            numP = Console.ReadLine();
            nPlayable = Convert.ToInt32(numP);
            Console.WriteLine("You have chosen to fight " + nPlayable + " characters");
            for (int i = 1; i <= nPlayable; i++)
            {
                List<Skill> skills = new List<Skill>();
                Console.WriteLine("\nEnter the name of enemy number " + i + ":");
                string chName = Console.ReadLine();
                Console.WriteLine("Enter " + chName + "'s HP stat:");
                int chHP = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter " + chName + "'s ATK stat:");
                int chATK = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter " + chName + "'s DEF stat:");
                int chDEF = Convert.ToInt32(Console.ReadLine());

                Character c1 = new Character(chName, chHP, chATK, chDEF, new List<Skill>());
                Console.WriteLine("Choose which 2 skills will " + chName + " inherit:");
                for (int j = 0; j < skilllist.Count; j++)
                    Console.WriteLine((j + 1) + "." + skilllist[j].getName() + " - " + skilllist[j].getDescriprion());
                Console.WriteLine("Choose the first skill that " + chName + " will inherit:");
                string code = Console.ReadLine();
                c1.addSkill(skilllist[Convert.ToInt32(code) - 1]);
                Console.WriteLine("Choose the second skill that " + chName + " will inherit:");
                code = Console.ReadLine();
                c1.addSkill(skilllist[Convert.ToInt32(code) - 1]);
                enemies.Add(c1);
            }

            Battle b= new Battle();
            b.Fight(playable, enemies);
        }
        static void Main(string[] args)
        {
            Testing();
        }
    }
}
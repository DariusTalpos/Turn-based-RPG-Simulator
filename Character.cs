using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gametest
{
    public class Character
    {
        string Name;
        int HP;
        int currentHP;
        int ATK;
        int DEF;
        List<Skill> Skills;

        public Character(string name, int hp, int atk, int def, List<Skill> skills)
        {
            Name = name;
            HP = hp;
            currentHP = hp;
            ATK = atk;
            DEF = def;
            Skills = skills;
        }
        public string getName()
        {
            return Name;
        }
        public int getCurrentHP()
        { 
            return currentHP; 
        }
        public int getATK()
        {
            return ATK;
        }
        public int getDEF()
        {
            return DEF;
        }

        public List<Skill>getSkills()
        {
            return Skills;
        }
        public void addSkill(Skill s)
        {
            Skills.Add(s);
            Console.WriteLine(this.getName() + " learned " + s.getName());
        }
        public void displaySkills()
        {
            for(int i=0;i<Skills.Count;i++)
            {
                Console.WriteLine((i+1) + "." + Skills[i].getName() + " -" + Skills[i].getDescriprion());
            }
        }
           
        public void takeDamage(int damage)
        {
            currentHP-= damage;
            Console.WriteLine(this.getName() + " took " + damage + " damage!");
        }

        public int isAlive()
        {
            if (currentHP <= 0)
                return 0;
            else
                return 1;
        }
    }
}

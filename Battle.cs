using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gametest
{
    public class Battle
    {
        public enum BattleState { PlayerTurn, EnemyTurn, Won, Lost }

        public int isTeamAlive(List<Character> enemies)
        {
            for (int i = 0; i < enemies.Count; i++)
                if (enemies[i].isAlive() == 1)
                    return 1;
            return 0;
        }

        public void playerTargeting(Character attacker, List<Character> enemies)
        {
            attacker.displaySkills();
            Console.WriteLine("Choose which skill you want to use:");
            Skill s = attacker.getSkills()[Convert.ToInt32(Console.ReadLine())-1];
            Console.WriteLine("Choose a target:");
            for (int i = 0; i < enemies.Count; i++)
                if (enemies[i].isAlive() == 1)
                    Console.WriteLine((i+1) + ". " +enemies[i].getName() + "  HP Remaining:" + enemies[i].getCurrentHP());
            Character chosen = enemies[Convert.ToInt32(Console.ReadLine())-1];
            s.useSkill(attacker, chosen);
        }

        public void enemyTargeting(Character attacker, List<Character> enemies)
        {
            Random random = new Random();
            int skillCount = attacker.getSkills().Count;
            Skill s = attacker.getSkills()[random.Next(0,skillCount)];
            int chosen = random.Next(0,enemies.Count);
            while (enemies[chosen].isAlive()==0)
                chosen = random.Next(0, enemies.Count);
            Console.WriteLine(attacker.getName()+" uses "+s.getName()+" on "+ enemies[chosen].getName()+"!");
            s.useSkill(attacker, enemies[chosen]);
        }
        public void Fight(List<Character> team, List<Character> enemies)
        {
            Console.Clear();
            Console.WriteLine("THE BATTLE BEGINS\n");
            BattleState b = BattleState.PlayerTurn;
            while(b != BattleState.Won && b!= BattleState.Lost)
            {
                if(b == BattleState.PlayerTurn)
                {
                    for (int i = 0; i < team.Count; i++)
                        if (team[i].isAlive() == 1)
                        {
                            Console.WriteLine("\nIt is " + team[i].getName() + "'s turn");
                            playerTargeting(team[i], enemies);
                            if(isTeamAlive(enemies)==0)
                            {
                                b = BattleState.Won;
                                //Console.Clear();
                                Console.WriteLine("YOU WON!");
                                break;
                            }
                        }
                    if (b != BattleState.Won)
                        b = BattleState.EnemyTurn;
                }
                if (b == BattleState.EnemyTurn)
                {
                    for (int i = 0; i < enemies.Count; i++)
                        if (enemies[i].isAlive() == 1)
                        {
                            Console.WriteLine("\nIt is " + enemies[i].getName() + "'s turn");
                            enemyTargeting(enemies[i], team);
                            if (isTeamAlive(team) == 0)
                            {
                                b = BattleState.Lost;
                                //Console.Clear();
                                Console.WriteLine("You lost...");
                                break;
                            }
                        }
                    if (b != BattleState.Lost)
                        b = BattleState.PlayerTurn;
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gametest
{
    public enum DamageType { PHYSICAL, NONE }
    public enum StatusEffect { SHOCK, STUN, NONE }
    public enum AmountChance { LOW, MEDIUM, HIGH, NONE }
    public enum SkillType { ATTACK, STATUSEFFECT, BUFF, DEBUFF, HEAL }
    public enum Target {ALL, ONE, NONE};
    public class Skill
    {
        string name;
        string description;
        DamageType damageType;
        StatusEffect statusEffect;
        AmountChance amountChance;
        SkillType skillType;

        public Skill(string name, string description, SkillType skillType, DamageType damageType, StatusEffect statusEffect, AmountChance amountChance)
        {
            this.description = description;
            this.damageType = damageType;
            this.statusEffect = statusEffect;
            this.amountChance = amountChance;
            this.skillType = skillType;
            this.name = name;
        }

        public string getName()
        {
            return name;
        }
        public string getDescriprion()
        {
            return description;
        }
        public void useSkill(Character user,Character target)
        {
            if (this.skillType == SkillType.ATTACK)
            {
                int damage=0;
                if (this.amountChance == AmountChance.LOW)
                    damage = (int) Math.Round(1.5 * user.getATK());
                if (this.amountChance == AmountChance.MEDIUM)
                    damage = (int)Math.Round(1.8 * user.getATK());
                if (this.amountChance == AmountChance.HIGH)
                    damage = (int)Math.Round(2.1 * user.getATK());

                target.takeDamage(damage);
            }
        }
    }
}

using Assets.Scripts.ScriptableObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    public abstract class Entity : MonoBehaviour
    {
        public List<Bonus> Bonuses;
        public List<EntityStat> stats;

        public Equipment[] equipment;

        public int defaultHP = 100;
        public int defaultMP = 50;
        public int defaultAtkSp = 1;

        // Start is called before the first frame update
        void Awake()
        {
            stats = new List<EntityStat>();
            Bonuses = new List<Bonus>();
        }

        // Update is called once per frame
        void Update()
        {
            if (GetStat(Stat.HP).GetValue() <= 0)
            {
                Die();
            }
        }
        public void TakeDamage(int damage)
        {
            int currentHP = GetStat(Stat.HP).GetValue() - damage;
            GetStat(Stat.HP).SetValue(currentHP);
        }
        public void Kill()
        {
            GetStat(Stat.HP).SetValue(0);
        }
        public int getHP()
        {
            return GetStat(Stat.HP).GetValue();
        }
        public int getMHP()
        {
            return GetStat(Stat.maxHP).GetValue();
        }
        public int getMP()
        {
            return GetStat(Stat.MP).GetValue();
        }
        public int getMMP()
        {
            return GetStat(Stat.maxMP).GetValue();
        }

        public void SetHP(int value)
        {
            GetStat(Stat.HP).SetValue(value);
        }
        public void SetMP(int value)
        {
            GetStat(Stat.MP).SetValue(value);
        }
        public void LoseMP(int value)
        {
            GetStat(Stat.MP).SetValue(getMP() - value);
        }
        public abstract void Die();

        public int GetDamageBonus(DamageType type)
        {
            int i = 0;
            foreach (Bonus bonus in Bonuses)
            {
                if (bonus != null)
                {
                    if (bonus is DamageBonus)
                    {
                        DamageBonus db = bonus as DamageBonus;
                        if (db.damageType == type)
                        {
                            i += db.bonus;
                        }
                    }
                }
            }
            return i;
        }
        public int GetStatBonus(Stat type)
        {
            int i = 0;
            foreach (Bonus bonus in Bonuses)
            {
                if (bonus != null)
                {
                    if (bonus is StatBonus)
                    {
                        StatBonus db = bonus as StatBonus;
                        if (db.stat == type)
                        {
                            i += db.bonus;
                        }
                    }
                }
            }
            return i;
        }

        public Weapon GetWeapon()
        {
            return equipment[0] as Weapon;
        }

        public virtual void Equip(Equipment e)
        {
            int slot = (int)e.slot;
            equipment[slot] = e;
        }

        public EntityStat GetStat(Stat type)
        {
            foreach(EntityStat stat in stats)
            {
                if(stat.GetStat() == type)
                {
                    return stat;
                }
            }
            return null;
        }
        public virtual void InitializeStats()
        {
            foreach (EntityStat stat in stats)
            {
                if (stat.GetStat() == Stat.maxHP)
                {
                    stat.SetValue(defaultHP);
                }
                if (stat.GetStat() == Stat.maxMP)
                {
                    stat.SetValue(defaultMP);
                }
                if (stat.GetStat() == Stat.HP)
                {
                    stat.SetValue(getMHP());
                }
                if (stat.GetStat() == Stat.MP)
                {
                    stat.SetValue(getMMP());
                }
                if (stat.GetStat() == Stat.AtkSpeed)
                {
                    stat.SetValue(defaultAtkSp);
                }
                Debug.Log(stat.GetStat() + ": " + stat.GetValue());
            }
        }
    }
}

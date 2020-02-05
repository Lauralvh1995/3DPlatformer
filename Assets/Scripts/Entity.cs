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
        public int defaultHPRegen = 1;
        public int defaultMPRegen = 1;
        public int defaultRegenSpeed = 1;
        public int defaultPDef = 1;
        public int defaultMDef = 1;

        float regenTime;
        float regenTick;
        float regenCounter;
        // Start is called before the first frame update
        void Awake()
        {
            stats = new List<EntityStat>();
            Bonuses = new List<Bonus>();
        }

        private void Start()
        {
            regenTime = getRegenSpeed() * 50f;
            regenTick = getRegenSpeed() * 1f;
        }

        // Update is called once per frame
        void Update()
        {
            if (GetStat(Stat.HP).GetValue() <= 0)
            {
                Die();
            }
            RegenCheck();
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
        public int getHPRegen()
        {
            return GetStat(Stat.HPRegen).GetValue();
        }
        public int getMPRegen()
        {
            return GetStat(Stat.MPRegen).GetValue();
        }
        public int getRegenSpeed()
        {
            return GetStat(Stat.RegenSpeed).GetValue();
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
                if (stat.GetStat() == Stat.PDef)
                {
                    stat.SetValue(defaultPDef);
                }
                if (stat.GetStat() == Stat.MDef)
                {
                    stat.SetValue(defaultMDef);
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
                if (stat.GetStat() == Stat.HPRegen)
                {
                    stat.SetValue(defaultHPRegen);
                }
                if (stat.GetStat() == Stat.MPRegen)
                {
                    stat.SetValue(defaultMPRegen);
                }
                if(stat.GetStat() ==  Stat.RegenSpeed)
                {
                    stat.SetValue(defaultRegenSpeed);
                }
            }
        }
        public void RecalculateStats()
        {
            InitializeStats();
            foreach (Bonus b in Bonuses)
            {
                if(b is StatBonus)
                {
                    StatBonus sb = b as StatBonus;
                    foreach(EntityStat stat in stats)
                    {
                        if(stat.GetStat() == sb.stat)
                        {
                            stat.AddValue(sb.bonus);
                            Debug.Log("Added " + sb.bonus + " to " + stat.GetStat());
                        }
                    }
                }
            }
        }
        public void RegenCheck()
        {
            if (regenCounter <= 0)
            {
                if (getHP() < getMHP())
                {
                    GetStat(Stat.HP).AddValue(getHPRegen());
                    if(getHP() > getMHP())
                    {
                        GetStat(Stat.HP).SetValue(getMHP());
                    }
                }

                if (getMP() < getMMP())
                {
                    GetStat(Stat.MP).AddValue(getMPRegen());
                    if (getMP() > getMMP())
                    {
                        GetStat(Stat.MP).SetValue(getMMP());
                    }
                }
                regenCounter = regenTime;
            }
            regenCounter -= regenTick;
        }
    }
}

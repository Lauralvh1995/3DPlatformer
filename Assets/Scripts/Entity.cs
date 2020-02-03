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
        public List<DamageBonus> damageBonuses;
        public List<EntityStat> stats;

        public Equipment[] equipment;

        // Start is called before the first frame update
        void Awake()
        {
            damageBonuses = new List<DamageBonus>();
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
        public abstract void Die();

        public int GetBonus(DamageType type)
        {
            int i = 0;
            foreach (DamageBonus db in damageBonuses)
            {
                if (db != null)
                {
                    if (db.damageType == type)
                    {
                        i += db.bonus;
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
    }
}

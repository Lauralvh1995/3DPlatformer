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
        public int maxHP;
        public int HP;
        public int maxMP;
        public int MP;

        public List<DamageBonus> damageBonuses;

        public Equipment[] equipment;

        // Start is called before the first frame update
        void Awake()
        {
            damageBonuses = new List<DamageBonus>();
        }

        // Update is called once per frame
        void Update()
        {
            if (HP <= 0)
            {
                Die();
            }
        }
        public void TakeDamage(int damage)
        {
            HP -= damage;
        }
        public void Kill()
        {
            HP = 0;
        }
        public int getHP()
        {
            return HP;
        }
        public int getMHP()
        {
            return maxHP;
        }
        public int getMP()
        {
            return MP;
        }
        public int getMMP()
        {
            return maxMP;
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
    }
}

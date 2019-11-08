using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.ScriptableObjects
{
    public abstract class Equipment : Item
    {
        public SkinnedMeshRenderer mesh;

        public int strBonus;
        public int intBonus;
        public int dexBonus;
        public int conBonus;
        public int hpBonus;
        public int mpBonus;

        public int strReq;
        public int intReq;
        public int dexReq;
        public int conReq;
        public int lvlReq;

        public List<DamageBonus> bonuses;

        public EquipmentSlots slot;

        public void Equip(Entity e)
        {
            if (e is Player)
            {
                Player p = e as Player;
                if (p.getStr() >= strReq && p.getInt() >= intReq && p.getDex() >= dexReq && p.getCon() >= conReq && p.getLvl() > lvlReq)
                {
                    p.maxHP += hpBonus;
                    p.maxMP += mpBonus;
                    p.strength += strBonus;
                    p.intelligence += intBonus;
                    p.dexterity += dexBonus;
                    p.constitution += conBonus;

                    foreach (DamageBonus bonus in bonuses)
                    {
                        if (bonus != null)
                        {
                            p.damageBonuses.Add(bonus);
                        }
                    }
                }
                else
                {
                    Debug.Log("You do not have the required prerequisites");
                    return;
                }
            }
            else
            {
                e.maxHP += hpBonus;
                e.maxMP += mpBonus;
                foreach (DamageBonus bonus in bonuses)
                {
                    if (bonus != null)
                    {
                        e.damageBonuses.Add(bonus);
                    }
                }
            }
            
        }

        public void Unequip(Entity e)
        {
            e.maxHP -= hpBonus;
            e.maxMP -= mpBonus;
            if (e is Player)
            {
                Player p = e as Player;
                p.strength -= strBonus;
                p.intelligence -= intBonus;
                p.dexterity -= dexBonus;
                p.constitution -= conBonus;
            }
            foreach (DamageBonus bonus in bonuses)
            {
                e.damageBonuses.Remove(bonus);
            }
        }
    }
}

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

        public int strReq;
        public int intReq;
        public int dexReq;
        public int conReq;
        public int lvlReq;

        public List<Bonus> bonuses;

        public EquipmentSlots slot;

        public void Equip(Entity e)
        {
            if (e is Player)
            {
                Player p = e as Player;
                if (p.getStr() >= strReq && p.getInt() >= intReq && p.getDex() >= dexReq && p.getCon() >= conReq && p.getLvl() > lvlReq)
                {
                    foreach (Bonus bonus in bonuses)
                    {
                        if (bonus != null)
                        {
                            p.Bonuses.Add(bonus);
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
                foreach (Bonus bonus in bonuses)
                {
                    if (bonus != null)
                    {
                        e.Bonuses.Add(bonus);
                    }
                }
            }
            
        }

        public void Unequip(Entity e)
        {
            foreach (Bonus bonus in bonuses)
            {
                e.Bonuses.Remove(bonus);
            }
        }
    }
}

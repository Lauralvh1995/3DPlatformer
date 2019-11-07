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
        public Transform attachPoint;
        public Mesh mesh;

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

        public List<DamageBonus> bonuses;

        public void Equip(Player p)
        {
            if(p.getStr() >= strReq && p.getInt() >= intReq && p.getDex() >= dexReq && p.getCon() >= conReq)
            {
                p.maxHP += hpBonus;
                p.maxMP += mpBonus;
                p.strength += strBonus;
                p.intelligence += intBonus;
                p.dexterity += dexBonus;
                p.constitution += conBonus;
                //yet to be implemented
                //add bonuses
            }
            else
            {
                Debug.Log("You do not have the required prerequisites");
            }
        }

        public void Unequip(Player p)
        {
            p.maxHP -= hpBonus;
            p.maxMP -= mpBonus;
            p.strength -= strBonus;
            p.intelligence -= intBonus;
            p.dexterity -= dexBonus;
            p.constitution -= conBonus;
            //yet to be implemented
            //remove bonuses
        }
    }
}

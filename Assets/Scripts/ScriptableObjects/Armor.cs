using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.ScriptableObjects
{
    [CreateAssetMenu(fileName ="New Armor", menuName = "Items/Armor")]
    public class Armor : Equipment
    {
        public int PhysicalDefenseBonus;
        public int MagicalDefenseBonus;
    }
}

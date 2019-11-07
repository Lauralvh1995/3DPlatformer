using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
namespace Assets.Scripts.ScriptableObjects
{
    [CreateAssetMenu(fileName = "New DamageBonus", menuName = "Items/DamageBonus")]
    public class DamageBonus : ScriptableObject
    {
        public DamageType damageType;
        public int bonus;
    }
}

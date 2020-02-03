using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.ScriptableObjects
{
    [CreateAssetMenu(fileName = "New StatBonus", menuName = "Items/StatBonus")]
    public class StatBonus : Bonus
    {
        public Stat stat;
    }
}

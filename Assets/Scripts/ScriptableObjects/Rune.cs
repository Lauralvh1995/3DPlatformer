using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.ScriptableObjects
{
    [CreateAssetMenu(fileName = "New Rune", menuName = "Items/Rune")]
    public class Rune : Item
    {
        bool inUse;

        public bool IsInUse()
        {
            return inUse;
        }
        public void SetInUse(bool set)
        {
            inUse = set;
        }
    }
}

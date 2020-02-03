using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.ScriptableObjects
{
    [CreateAssetMenu(fileName = "New Entity Stat", menuName = "Entity Stat")]
    public class EntityStat : ScriptableObject
    {
        public Stat stat;
        public int value;

        public Stat GetStat()
        {
            return stat;
        }

        public int GetValue()
        {
            return value;
        }

        public void SetValue(int _value)
        {
            value = _value;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.ScriptableObjects
{
    public class EntityStat : ScriptableObject
    {
        Stat stat;
        int value;

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

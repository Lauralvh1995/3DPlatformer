using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.ScriptableObjects
{
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

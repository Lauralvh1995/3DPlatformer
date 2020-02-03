using Assets.Scripts.ScriptableObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts
{
    public class Enemy : Entity
    {
        public override void Die()
        {
            //Do Death animation
            GetStat(Stat.HP).SetValue(getMHP());
            GetStat(Stat.MP).SetValue(getMMP());
            //return to enemy pool
        }
    }
}

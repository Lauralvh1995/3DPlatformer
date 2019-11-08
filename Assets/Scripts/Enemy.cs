using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts
{
    public class Enemy : Entity
    {
        public void TakeDamage(int damage)
        {
            HP -= damage;
        }
        public override void Die()
        {
            //Do Death animation
            HP = maxHP;
            MP = maxMP;
            //return to enemy pool
        }
    }
}

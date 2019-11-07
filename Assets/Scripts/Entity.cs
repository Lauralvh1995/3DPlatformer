using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    public abstract class Entity : MonoBehaviour
    {
        public int maxHP;
        public int HP;
        public int maxMP;
        public int MP;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (HP <= 0)
            {
                Die();
            }
        }

        public void Kill()
        {
            HP = 0;
        }
        public int getHP()
        {
            return HP;
        }
        public int getMHP()
        {
            return maxHP;
        }
        public int getMP()
        {
            return MP;
        }
        public int getMMP()
        {
            return maxMP;
        }
        public abstract void Die();
    }
}

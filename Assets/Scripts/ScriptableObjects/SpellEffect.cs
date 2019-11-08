using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.ScriptableObjects
{
    [CreateAssetMenu(fileName = "New SpellEffect", menuName = "Spells/SpellEffect")]
    public class SpellEffect : ScriptableObject
    {
        public new string name;
        public List<Rune> requiredRunes;
        public string description;
        public int MPCost;
        public int damage;
        public SpellType type;

        public GameObject toBeSpawned;
        public void Execute(Vector3 origin, int damageBonus)
        {
            switch (type)
            {
                case SpellType.Projectile:
                    if (toBeSpawned != null)
                    {
                        if (toBeSpawned.GetComponent<Projectile>())
                        {
                            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                            RaycastHit hit;
                            if (Physics.Raycast(ray, out hit))
                            {
                                Vector3 target = hit.point;
                                target.y = origin.y;
                                toBeSpawned.GetComponent<Projectile>().Damage = damage + damageBonus;
                                toBeSpawned.GetComponent<Projectile>().target = target;
                            }

                        }

                        Instantiate(toBeSpawned, origin, Quaternion.LookRotation(origin));
                    }
                    break;
                case SpellType.Buff:
                    break;
                case SpellType.Debuff:
                    break;
                case SpellType.Summon:
                    break;
                case SpellType.Other:
                    break;

            }

        }
    }
}

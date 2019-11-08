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
        public int range;
        public int damage;

        public GameObject toBeSpawned;
        public void Execute(Player player, int damageBonus)
        {
            if(toBeSpawned != null)
            {
                if(toBeSpawned.GetComponent<Projectile>())
                {
                    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                    RaycastHit hit;
                    if (Physics.Raycast(ray, out hit))
                    {
                        Vector3 target = hit.point;
                        target.y = player.gameObject.transform.position.y;
                        toBeSpawned.GetComponent<Projectile>().Damage = damage + damageBonus;
                        toBeSpawned.GetComponent<Projectile>().target = target;
                    }

                }
                Instantiate(toBeSpawned, player.transform);
            }
        }
    }
}

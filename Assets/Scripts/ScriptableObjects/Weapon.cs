using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.ScriptableObjects
{
    [CreateAssetMenu(fileName = "New Weapon", menuName = "Items/Weapon")]
    public class Weapon : Equipment
    {
        public int damage;
        public bool oneHanded;
        public bool spellFocus;
        public QuickSpell quickSpell;
        // Start is called before the first frame update
        void Start()
        {
            if (!spellFocus)
            {
                quickSpell = null;
            }
        }

        // Update is called once per frame
        void Update()
        {

        }
        
        public void UseQuickSpell()
        {
            if(quickSpell != null)
            {
                quickSpell.Cast();
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.ScriptableObjects
{
    public abstract class Spell : ScriptableObject
    {
        public new string name;
        int size = 3;
        public List<Rune> runes;
        public SpellEffect effect;

        public Spell()
        {
            runes = new List<Rune>(size);
            
        }
        public void AddRune(Rune rune)
        {
            if (!rune.IsInUse() && runes.Count < 3)
            {
                runes.Add(rune);
                rune.SetInUse(true);
            }
            else
            {
                Debug.Log("Can't add rune to spell");
            }
        }
        public void RemoveRune(Rune rune)
        {
            if (runes.Contains(rune))
            {
                rune.SetInUse(false);
                runes.Remove(rune);
            }
        }

        public bool FinishSpell()
        {
            foreach(SpellEffect se in GameManager.instance.spellEffects)
            {
                if (runes.All(x => se.requiredRunes.Any(y => x.name == y.name)))
                {
                    effect = se;
                    return true;
                }
            }
            return false;
        }

        public abstract void Cast();
    }
}

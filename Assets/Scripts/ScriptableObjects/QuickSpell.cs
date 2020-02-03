using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.ScriptableObjects
{
    [CreateAssetMenu(fileName = "New QuickSpell", menuName = "Spells/QuickSpell")]
    public class QuickSpell : Spell
    {
        public override void Cast()
        {
            int damage = GameManager.instance.player.getInt() / 2  + GameManager.instance.player.GetDamageBonus(DamageType.Magical);
            effect.Execute(GameManager.instance.weaponAttachPoint.position, damage);
        }
    }
}

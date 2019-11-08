using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.ScriptableObjects
{
    [CreateAssetMenu(fileName = "New PreparedSpell", menuName = "Spells/PreparedSpell")]
    public class PreparedSpell : Spell
    {
        public override void Cast()
        {
            int damage = GameManager.instance.player.getInt() / 2 + GameManager.instance.player.GetBonus(DamageType.Magical);
            effect.Execute(GameManager.instance.weaponAttachPoint.position, damage);
            Destroy(this);
        }
    }
}

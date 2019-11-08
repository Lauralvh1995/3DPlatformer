using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.ScriptableObjects
{
    public class QuickSpell : Spell
    {
        public override void Cast()
        {
            int damage = GameManager.instance.player.getInt() / 2  + GameManager.instance.player.getBonus(DamageType.Magical);
            effect.Execute(GameManager.instance.player, damage);
        }
    }
}

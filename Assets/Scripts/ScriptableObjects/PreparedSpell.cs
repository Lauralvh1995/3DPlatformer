using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.ScriptableObjects
{
    public class PreparedSpell : Spell
    {
        public override void Cast()
        {
            //Do thing
            Destroy(this);
        }
    }
}

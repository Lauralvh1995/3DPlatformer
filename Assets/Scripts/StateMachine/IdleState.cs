using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.StateMachine
{
    public class IdleState : AbstractState
    {
        public override bool Enter()
        {
            return base.Enter();

        }
        public override void UpdateState()
        {
            throw new NotImplementedException();
        }
    }
}

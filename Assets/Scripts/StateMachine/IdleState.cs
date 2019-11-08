using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.StateMachine
{
    public class IdleState : AbstractState
    {
        public override bool Enter()
        {
            base.Enter();
            Debug.Log("EnteredIdleState");
            return true;

        }
        public override void UpdateState()
        {
            throw new NotImplementedException();
        }

        public override bool Exit()
        {
            base.Exit();
            Debug.Log("ExitedIdleState");
            return true;
        }
    }
}

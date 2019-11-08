using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractState : ScriptableObject
{
    ExecutionState _executionState;
    public ExecutionState ExecutionState
    {
        get
        {
            return _executionState;
        }
        protected set
        {
            _executionState = value;
        }
    }

    public virtual void OnEnable()
    {
        _executionState = ExecutionState.None;
    }
    public virtual bool Enter()
    {
        _executionState = ExecutionState.Active;
        return true;
    }
    public abstract void UpdateState();
    public virtual bool Exit()
    {
        _executionState = ExecutionState.Completed;
        return true;
    }
}

public enum ExecutionState
{
    None,
    Active,
    Completed,
    Terminated
};

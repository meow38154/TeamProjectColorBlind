using System.Collections.Generic;
using UnityEngine;

public class BossStateMachine
{
    private Dictionary<string, BossState> _stateDictionary = new Dictionary<string, BossState>
    {
        { "death", new BossDeathState() }
    };
    public BossState CurrentState { get; private set; }

    

    public void AddState(string stateName, BossState state)
    {
        _stateDictionary.Add(stateName, state);
    }

    public void Initialize(string startState)
    {
        if (_stateDictionary.TryGetValue(startState, out var state))
        {
            CurrentState = state;
            if (CurrentState._bossObject == null)
            {
                CurrentState.Initialize(CurrentState, InGameManager.Instance.Boss);
            }
            CurrentState.Enter();
        }
    }

    public void ChangeState(string newState)
    {
        if (!_stateDictionary.TryGetValue(newState, out var nextState))
        {
            return;
        }

        if (nextState._bossObject == null)
        {
            nextState.Initialize(nextState, InGameManager.Instance.Boss);
        }

        CurrentState?.Exit();
        CurrentState = nextState;
        CurrentState.Enter();
    }
}

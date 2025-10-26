using System.Collections.Generic;
using UnityEngine;

public class BossStateMachine
{
    private Dictionary<string, BossState> _stateDictionary = new();
    public BossState CurrentState { get; private set; }

    public void AddState(string stateName, BossState state)
    {
        Debug.Log($"{stateName} {state}");
        _stateDictionary.Add(stateName, state);
    }
    public void Initialize(string startState)
    {
        if (_stateDictionary.TryGetValue(startState, out var state))
        {
            CurrentState = state;
            CurrentState.Enter();
        }
    }

    public void ChangeState(string newState)
    {
        if (!_stateDictionary.TryGetValue(newState, out var nextState))
        {
            return;
        }

        CurrentState?.Exit();
        CurrentState = nextState;
        CurrentState.Enter();
    }
}

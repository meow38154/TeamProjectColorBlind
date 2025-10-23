using System.Collections.Generic;
using UnityEngine;

public class Boss1StateMachine
{
    private Dictionary<string, Boss1State> _stateDictionary = new();
    public Boss1State CurrentState { get; private set; }

    public void AddState(string stateName, Boss1State state)
    {
        if (!_stateDictionary.ContainsKey(stateName))
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

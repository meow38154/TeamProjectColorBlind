using System;
using System.Collections.Generic;
using _00.Work.Lusalord._02.Script.SO.Player.FSM;
using UnityEngine;

namespace _00.Work.Lusalord._02.Script.Player.FSMSystem
{
    public class PlayerStateMachine : MonoBehaviour
    {
          public PlayerState CurrentState { get; private set; }

          private Dictionary<string, PlayerState> _stateDictionary;

          public PlayerStateMachine(Player player, StateSO[] stateList)
          {
              _stateDictionary = new Dictionary<string, PlayerState>();

              foreach (StateSO stateSo in stateList)
              {
                  Type type = Type.GetType(stateSo.ClassName);
                  PlayerState playerState = Activator.CreateInstance(type, player, stateSo.ParameterSO) as PlayerState;
                  
                  _stateDictionary.Add(stateSo.StateName, playerState);
              }
          }
          public void ChangeState(string stateType)
          {
              CurrentState?.Exit();
              PlayerState newState = _stateDictionary[stateType];
              CurrentState = newState;
              CurrentState?.Enter();
          }

          public void UpdateMachine()
          {
              CurrentState?.Update();
          }
    }
}
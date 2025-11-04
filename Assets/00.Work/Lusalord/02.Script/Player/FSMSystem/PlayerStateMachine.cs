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
          }
    }
}
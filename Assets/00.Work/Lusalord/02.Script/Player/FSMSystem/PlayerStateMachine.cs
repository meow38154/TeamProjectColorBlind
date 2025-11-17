using System;
using System.Collections.Generic;
using _00.Work.Lusalord._02.Script.Player.FSMSystem.State;

namespace _00.Work.Lusalord._02.Script.Player.FSMSystem
{
    public class PlayerStateMachine
    {
          public PlayerState CurrentState { get; private set; }
          private Player _player;
          private Dictionary<PlayerStates, PlayerState> _stateDictionary;

          public PlayerStateMachine(Player player)
          {
              _player = player;
              _stateDictionary = new Dictionary<PlayerStates, PlayerState>
              {
                  { PlayerStates.Idle, new PlayerIdleState(player, this) },
                  { PlayerStates.Move, new PlayerMoveState(player, this) },
                  { PlayerStates.Attack, new PlayerAttackState(player, this) },
                  { PlayerStates.Dash, new PlayerDashState(player, this) },
                  { PlayerStates.Hit, new PlayerHitState(player, this) },
                  { PlayerStates.Death, new PlayerDeathState(player, this) },
                  { PlayerStates.Jump, new PlayerJumpState(player, this) },
                  { PlayerStates.DoubleJump, new PlayerDoubleJumpState(player, this) },
                  { PlayerStates.Fall, new PlayerFallState(player, this) }
              };
          }
          public void Initialize(PlayerStates startState)
          {
              CurrentState = _stateDictionary[startState];
              CurrentState?.Enter();
          }
          public void ChangeState(PlayerStates stateType)
          {
              if( CurrentState.States == stateType) 
                  return;
              CurrentState?.Exit();
              CurrentState = _stateDictionary[stateType];
              CurrentState?.Enter();
          }

          public void UpdateMachine()
          {
              CurrentState?.Update();
          }
          public PlayerStates GetState() => CurrentState.States;
    }
}
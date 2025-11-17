using _00.Work.Lusalord._02.Script.Agent;
using _00.Work.Lusalord._02.Script.Player;
using _00.Work.Lusalord._02.Script.Player.FSMSystem;
using _00.Work.Lusalord._02.Script.SO;
using UnityEngine;

public abstract class PlayerState
{
    protected Player Player;
    protected PlayerStateMachine StateMachine;
    public abstract PlayerStates States { get; }


    public PlayerState(Player player, PlayerStateMachine stateMachine)
    {
        Player = player;
        StateMachine = stateMachine;
    }

    public virtual void Enter()
    {
        
    }
    
    public virtual void Update()
    {
        
    }

    public virtual void Exit()
    {
        
    }
}

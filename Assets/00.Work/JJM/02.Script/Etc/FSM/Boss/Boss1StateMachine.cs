using UnityEngine;

public enum BossStateType
{
    Dash,
    TakeDown,
    TakeDown_Stabbing,
    Continuous_Stabbing,
    Throw
}

public class Boss1StateMachine : Boss1State
{
    public Boss1StateMachine(Boss1 boss1, Boss1StateMachine stateMachine, string animClipName) : base(boss1, stateMachine, animClipName)
    {
        
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void UpdateState()
    {
        base.UpdateState();
    }

    public override void Exit()
    {
        base.Exit();
    }
}

using UnityEngine;

public class BossDeathState : BossState
{
    public BossDeathState()
    {

    }

    public override void Enter()
    {
        Debug.Log("죽음 상태 진입");
        base.Enter();
    }

    public override void UpdateState()
    {
        base.UpdateState();
    }
    public override void Exit() { base.Exit();
}
}

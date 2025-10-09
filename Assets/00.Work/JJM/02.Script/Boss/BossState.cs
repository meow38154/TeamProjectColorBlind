using UnityEngine;


//성태의 틀
public abstract class BossState
{
    protected Boss _boss;
    protected BossStateMachine _stateMachine;
    protected int _animHash;

    public BossState(Boss boss, BossStateMachine stateMachine, string animClipName)
    {
        _boss = boss;
        _stateMachine = stateMachine;
        _animHash = Animator.StringToHash(animClipName);
    }

    public virtual void Enter()
    {
        _boss.AnimCompo.SetBool(_animHash, true);
    }

    public virtual void UpdateState()
    {

    }

    public virtual void Exit()
    {
        _boss.AnimCompo.SetBool(_animHash, false);
    }
}

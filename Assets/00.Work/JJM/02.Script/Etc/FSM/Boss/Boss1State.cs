using UnityEngine;


//성태의 틀
public abstract class Boss1State
{
    protected Boss1 _boss1;
    protected Boss1StateMachine _stateMachine;
    protected int _animHash;

    public Boss1State(Boss1 boss1, Boss1StateMachine stateMachine, string animClipName)
    {
        _boss1 = boss1;
        _stateMachine = stateMachine;
        _animHash = Animator.StringToHash(animClipName);
    }

    public virtual void Enter()
    {
        _boss1.AnimCompo.SetBool(_animHash, true);
    }

    public virtual void UpdateState()
    {

    }

    public virtual void Exit()
    {
        _boss1.AnimCompo.SetBool(_animHash, false);
    }
}

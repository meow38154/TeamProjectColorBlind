using UnityEngine;
using DG.Tweening;

public abstract class Boss1State
{
    protected Boss1State _boss1Stage;
    protected Boss _bossObject;

    // 생성자 대신 Initialize 사용
    public void Initialize(Boss1State boss1Stage, Boss boss)
    {
        _boss1Stage = boss1Stage;
        _bossObject = boss;
    }

    public virtual void Enter() { }
    public virtual void UpdateState() { }
    public virtual void Exit() { }

    public virtual void Test() { }
}

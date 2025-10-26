using UnityEngine;
using DG.Tweening;

public abstract class BossState
{
    protected BossState _boss1Stage;
    protected Boss _bossObject;

    public float PatternPlayTime { get; protected set; }

    public void Initialize(BossState boss1Stage, Boss boss)
    {
        _bossObject = boss;
    }

    public virtual void Enter() 
    {
        Debug.Log("µé¾î°¨");
    }
    public virtual void UpdateState() { }
    public virtual void Exit() { }

    public virtual void Test() { }
}

using UnityEngine;
using DG.Tweening;

public abstract class BossState
{
    public BossState _boss1Stage;
    public Boss _bossObject;
    public Rigidbody2D _rb;
    public Animator _anim;

    public float PatternPlayTime { get; protected set; }

    public void Initialize(BossState boss1Stage, Boss boss)
    {
        _bossObject = boss;
        _anim = boss.GetComponentInChildren<Animator>();
        if (_bossObject.TryGetComponent(out Rigidbody2D rb))
        {
            _rb = rb;
        }
    }

    public virtual void Enter()
    {
        Debug.Log("»óÅÂ ¹Ù²ñ");
    }
    public virtual void UpdateState() { }
    public virtual void Exit() { }
    public virtual void Test() { }
}

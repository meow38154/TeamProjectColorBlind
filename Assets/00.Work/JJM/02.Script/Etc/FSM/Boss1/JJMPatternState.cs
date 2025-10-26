using UnityEngine;
using DG.Tweening;
using System;

public class JJMPatternState : BossState
{
    public int a;

    public JJMPatternState() { }

    public override void Enter()
    {
        base.Enter();
        Debug.Log(a);
    }

    public override void UpdateState()
    {
        base.UpdateState();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Test()
    {
        Debug.Log("¼º°ø!");
    }
}

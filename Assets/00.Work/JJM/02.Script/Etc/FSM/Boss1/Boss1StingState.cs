using UnityEngine;
using DG.Tweening;
using System;

[Serializable]
public class Boss1StingState : Boss1State
{
    public float firstDelay;
    public float dashTime;
    public float dashDistance;

    public Boss1StingState() { }

    public override void Enter()
    {
        base.Enter();

        Sequence seq = DOTween.Sequence();
        seq.PrependInterval(firstDelay);

        int flipValue = GameManager.Instance.TargetAndPlayerDirectionValue(_bossObject.transform);
        seq.Append(_bossObject.transform.DOMoveX(dashDistance * flipValue, dashTime));
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

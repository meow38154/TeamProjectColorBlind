using UnityEngine;
using System;
using System.Reflection;

public class BossBrain : MonoBehaviour
{
    [SerializeField] private Boss _bossObject;
    [SerializeField] private BossState _boss1Stage;
    [field: SerializeField] public BossPattrenData BossPattenData { get; private set; }

    public BossStateMachine StateMachine { get; private set; }

    private void Awake()
    {
        StateMachine = new BossStateMachine();

        foreach (var pattern in BossPattenData.patternSO)
        {
            StateMachine.AddState(pattern.Name, pattern.BossStateData);
            pattern.BossStateData.Initialize(pattern.BossStateData, GetComponent<Boss>());
        }
    }

    public void PatternPlay(string patternName)
    {
        StateMachine.ChangeState(patternName);
    }
}

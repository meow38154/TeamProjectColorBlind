using UnityEngine;
using System;
using System.Reflection;

public class Boss1Brain : MonoBehaviour
{
    [SerializeField] private Boss _bossObject;
    [SerializeField] private Boss1State _boss1Stage;
    [SerializeField] private BossPattenData _bossPattenData;

    private Boss1StateMachine _stateMachine;

    private void Awake()
    {
        _stateMachine = new Boss1StateMachine();
        
        //foreach (var pattern in _bossPattenData.patternSO)
        //{
        //    _stateMachine.Initialize
        //}

        _stateMachine.CurrentState.Test();
    }
}

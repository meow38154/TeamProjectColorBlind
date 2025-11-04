using UnityEngine;
using System.Collections;
using System;

[Serializable]
public struct PhasePatternList
{
    public string[] skillList;
    public int startHealth;
}

[RequireComponent (typeof(Rigidbody2D))]
public class Boss : MonoBehaviour
{
    [SerializeField] protected PhasePatternList[] patterns;

    [SerializeField, ReadOnly] protected int _phase = 1;

    protected BossBrain _bossBrain;

    private HealthSystem _healthSystem;

    private void Awake()
    {
        _healthSystem = GetComponentInChildren<HealthSystem>();
    }

    protected void BossBrainUpdate()
    {
        _bossBrain = GetComponent<BossBrain>();
    }

    protected void PatternsPlay(string[] patterns, int phase)
    {
        StartCoroutine(PatternsPlayCoroutine(patterns, phase));
    }

    public IEnumerator PatternsPlayCoroutine(string[] patterns, int phase)
    {
        while (_phase == phase)
        {
            string stateName = _bossBrain.BossPattenData.patternSO[UnityEngine.Random.Range(0, patterns.Length)].Name;
            _bossBrain.StateMachine.ChangeState(stateName);

            yield return new WaitForSeconds(_bossBrain.StateMachine.CurrentState.PatternPlayTime);
        }
    }
}

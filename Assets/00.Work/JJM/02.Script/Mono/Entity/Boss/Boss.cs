using UnityEngine;
using System.Collections;

[RequireComponent (typeof(Rigidbody2D))]
public class Boss : MonoBehaviour
{
    [SerializeField, ReadOnly] protected int _phase = 1;
    protected BossBrain _bossBrain;

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
            string stateName = _bossBrain.BossPattenData.patternSO[Random.Range(0, patterns.Length)].Name;
            _bossBrain.StateMachine.ChangeState(stateName);

            yield return new WaitForSeconds(_bossBrain.StateMachine.CurrentState.PatternPlayTime);
        }
    }
}

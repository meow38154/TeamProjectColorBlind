using UnityEngine;
using System.Collections;
using System;
using UnityEngine.InputSystem;

[Serializable]
public struct PhasePatternList
{
    public string[] skillList;
    public int startHealth;
    public int untilHealth;
}

[RequireComponent (typeof(Rigidbody2D))]
public class Boss : MonoBehaviour
{
    [Header("PatternSetting")]
    [SerializeField] protected PhasePatternList[] patterns;

    [SerializeField, ReadOnly] protected int _phase = 1;

    [Header("VisualSetting")]
    [SerializeField] private bool _passaveFlipX = true;

    protected BossBrain _bossBrain;

    private HealthSystem _healthSystem;

    private Coroutine _coroutine;

    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _healthSystem = GetComponentInChildren<HealthSystem>();
        _bossBrain = GetComponent<BossBrain>();
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    private void Start()
    {
        PhaseChange(1, transform);
    }
    private void Update()
    {
        if (Keyboard.current.iKey.wasPressedThisFrame)
        {
            Debug.Log(patterns[0].skillList[0]);
            PatternsPlay(patterns[0].skillList, 1);
        }

        if (_passaveFlipX)
        {
            FlipXPlayer();
        }
    }

    public void FlipXPlayer()
    {
        int v = GameManager.Instance.TargetAndPlayerDirectionValue(transform);

        if (v == 1)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        if (v == -1)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }

    protected void BossBrainUpdate()
    {
        _bossBrain = GetComponent<BossBrain>();
    }

    protected void PatternsPlay(string[] patterns, int phase)
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
        }
        _coroutine = StartCoroutine(PatternsPlayCoroutine(patterns, phase));
    }

    public IEnumerator PatternsPlayCoroutine(string[] patterns, int phase)
    {
        while (_phase == phase)
        {
            string stateName = _bossBrain.PattrenData.patternSO[UnityEngine.Random.Range(0, patterns.Length)].Name;
            _bossBrain.StateMachine.ChangeState(stateName);

            yield return new WaitForSeconds(_bossBrain.StateMachine.CurrentState.PatternPlayTime);
        }
    }

    public void PhaseChange(int y, Transform tr)
    {
        for (int i = 0; i < patterns.Length; i++)
        {
            Debug.Log($"{_healthSystem.CurrentHealth} {patterns[i].startHealth} {patterns[i].untilHealth} {patterns[i].skillList[0]}");
            if (_healthSystem.CurrentHealth <= patterns[i].startHealth && _healthSystem.CurrentHealth >= patterns[i].untilHealth)
            {
                Debug.Log("조건 맞음");
                PatternsPlay(patterns[i].skillList, i);
                break;
            }
        }
    }

    private void OnEnable()
    {
        _healthSystem.OnGetDamge += PhaseChange;
    }

    private void OnDisable()
    {
        _healthSystem.OnGetDamge -= PhaseChange;
    }
}

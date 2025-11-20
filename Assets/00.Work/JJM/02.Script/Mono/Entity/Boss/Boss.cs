using UnityEngine;
using System.Collections;
using System;
using UnityEngine.InputSystem;
using System.Collections.Generic;

[Serializable]
public struct PhasePatternList
{
    [Header("Num")]
    public int phase;

    [Header("Phase")]
    [SerializeField, Range(0.0f, 100.0f)]
    public float _phaseStartHealth;     // 시작 체력 %
    [SerializeField, Range(0.0f, 100.0f)]
    public float _phaseUntilHealth;     // 끝 체력 %

    [Header("UseSkill")]
    public string[] skillList;          // 해당 페이즈 패턴 이름 목록
}

[RequireComponent(typeof(Rigidbody2D))]
public class Boss : MonoBehaviour
{
    [Header("PatternSetting")]
    [SerializeField] protected PhasePatternList[] patterns;

    protected int _phase = -1;

    [Header("VisualSetting")]
    [field: SerializeField] public bool PassaveFlipX { get; set; } = true;
    [field: SerializeField] public bool PassaveFlipXFlip { get; set; } = true;

    [ReadOnly] public BossBrain _bossBrain;

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
        PhaseChange(0, transform);
    }

    private void Update()
    {
        if (Keyboard.current.iKey.wasPressedThisFrame)
        {
            Debug.Log(patterns[0].skillList[0]);
        }

        if (PassaveFlipX)
        {
            FlipXPlayer();
        }
    }

    public void FlipXPlayer()
    {
        int v = InGameManager.Instance.TargetAndPlayerDirectionValue(transform);

        if (v == 1)
        {
            _spriteRenderer.transform.rotation = Quaternion.Euler(0, PassaveFlipXFlip ? 0 : 180, 0);
        }
        if (v == -1)
        {
            _spriteRenderer.transform.rotation = Quaternion.Euler(0, PassaveFlipXFlip ? 180 : 0, 0);
        }
    }

    protected void BossBrainUpdate()
    {
        _bossBrain = GetComponent<BossBrain>();
    }

    protected void PatternsPlay(string[] skillNames, int phase)
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
        }
        _coroutine = StartCoroutine(PatternsPlayCoroutine(skillNames, phase));
    }

    public IEnumerator PatternsPlayCoroutine(string[] skillNames, int phase)
    {
        while (_phase == phase)
        {
            string stateName = skillNames[UnityEngine.Random.Range(0, skillNames.Length)];
            _bossBrain.StateMachine.ChangeState(stateName);

            Debug.Log($"{stateName} 패턴 실행됨 {_phase}페이즈");

            yield return new WaitForSeconds(_bossBrain.StateMachine.CurrentState.PatternPlayTime);
        }
    }

    public void PhaseChange(int y, Transform tr)
    {
        float currentHealthPercent = ((float)_healthSystem.CurrentHealth / (float)_healthSystem.MaxHealth) * 100f;

        for (int i = 0; i < patterns.Length; i++)
        {
            if (currentHealthPercent <= patterns[i]._phaseStartHealth &&
                currentHealthPercent >= patterns[i]._phaseUntilHealth &&
                _phase != patterns[i].phase)
            {
                if (_coroutine != null)
                {
                    StopCoroutine(_coroutine);
                }

                _phase = patterns[i].phase;

                Debug.Log($"페이즈 변경! Phase: {_phase} (Health: {currentHealthPercent}%)");
                PatternsPlay(patterns[i].skillList, patterns[i].phase);

                break;
            }
        }
    }

    private void OnEnable()
    {
        _healthSystem.OnGetDamage += PhaseChange;
    }

    private void OnDisable()
    {
        _healthSystem.OnGetDamage -= PhaseChange;
    }
}

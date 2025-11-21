using DG.Tweening;
using UnityEngine;

public class DSDeathEvent : MonoBehaviour
{
    private TargetFollow _targetFollow;
    private GameObject _parents;
    private HealthSystem _healthSystem;
    private Animator _anim;

    private bool _pos;
    private Vector3 _savePos;

    private void Awake()
    {
        _healthSystem = GetComponentInParent<HealthSystem>();
        _parents = transform.root.gameObject;
        _targetFollow = _parents.GetComponentInChildren<TargetFollow>();
        _anim = _parents.GetComponentInChildren<Animator>();
    }

    private void OnEnable()
    {
        _healthSystem.OnDie += Play;
    }

    private void OnDisable()
    {
        _healthSystem.OnDie -= Play;
    }

    private void OnDestroy()
    {
        _healthSystem.OnDie -= Play;
    }

    private void Update()
    {
        if (_pos)
        {
            _parents.transform.position = _savePos;
            _parents.transform.position = new Vector3(_parents.transform.position.x, 5.7f, _parents.transform.position.z);
        }
    }

    private void Play()
    {
        _savePos = _parents.transform.position;
        _anim.SetBool("Death", true);
        _pos = true;
    }
}

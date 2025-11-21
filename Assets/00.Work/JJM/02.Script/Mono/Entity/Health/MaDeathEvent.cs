using DG.Tweening;
using UnityEngine;

public class MaDeathEvent : MonoBehaviour
{
    private GameObject _parents;
    private HealthSystem _healthSystem;
    private Animator _anim;

    private Rigidbody2D _rb;

    private bool _pos;
    private Vector3 _savePos;

    private void Awake()
    {
        _healthSystem = GetComponentInParent<HealthSystem>();
        _parents = transform.root.gameObject;
        _anim = _parents.GetComponentInChildren<Animator>();
        _rb = _parents.GetComponentInChildren<Rigidbody2D>();
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
            _rb.gravityScale = 3;
            _anim.SetBool("Death", true);
        }
    }

    private void Play()
    {
        _pos = true;
    }
}

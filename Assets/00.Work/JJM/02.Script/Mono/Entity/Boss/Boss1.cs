using UnityEngine;

public class Boss1 : MonoBehaviour
{
    private IHealth _health;

    [SerializeField] private BossPattenData _pattenData;
    public Animator AnimCompo { get; private set; }

    private void Awake()
    {
        Animator anim = GetComponentInChildren<Animator>();
        _health = GetComponentInChildren<IHealth>();
    }
}

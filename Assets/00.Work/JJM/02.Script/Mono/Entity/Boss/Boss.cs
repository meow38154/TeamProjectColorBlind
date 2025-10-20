using UnityEngine;

public class Boss : MonoBehaviour
{
    [SerializeField] protected BossPattenData _pattenData;
    protected IHealth _health;
    public Animator AnimCompo { get; private set; }

    protected void GetSetting()
    {
        Animator anim = GetComponentInChildren<Animator>();
        _health = GetComponentInChildren<IHealth>();
    }


}

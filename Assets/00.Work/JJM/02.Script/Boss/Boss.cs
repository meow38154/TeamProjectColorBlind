using UnityEngine;

public class Boss : MonoBehaviour
{
    [SerializeField] private BossPattenData _pattenData;
    public Animator AnimCompo { get; private set; }

    private void Awake()
    {
        Animator anim = GetComponentInChildren<Animator>();
    }
}

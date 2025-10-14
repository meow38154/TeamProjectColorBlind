using DG.Tweening;
using UnityEngine;

[CreateAssetMenu(fileName = "DashPattonSO", menuName = "SO/Patten/Dash")]
public class DashPattonSO : PattonSO
{
    [field: SerializeField] public float DashDistance { get; private set; } = 4;
    [field: SerializeField] public float MoveTime { get; private set; } = 0.5f;
    [field: SerializeField] public Ease MoveEase { get; private set; }

    public float Xvelocity { get; private set; }

    private int _x;

    public void PlayDash()
    {
        Sequence seq = DOTween.Sequence();

        seq.Append(DOTween.To(() => _x, x => _x = x, 0, FirstDeal));
        seq.Append(DOTween.To(() => Xvelocity, x => Xvelocity = x, DashDistance, MoveTime)
            .SetEase(MoveEase));
        seq.Append(DOTween.To(() => _x, x => _x = x, 0, EndDeal));
    }

}



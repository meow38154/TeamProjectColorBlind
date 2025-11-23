using DG.Tweening;
using UnityEngine;

public class UIMove : MonoBehaviour
{
    [SerializeField] private RectTransform _tran;

    private void Start()
    {
        _tran.DOMoveY(-1200, 0);
    }

    public void Up()
    {
        SoundManager.Instance.PlaySound(16, 0.8f);
        _tran.DOMoveY(540, 0.5f).SetEase(Ease.OutQuart);
    }
    public void Down()
    {
        _tran.DOMoveY(-1200, 0.5f).SetEase(Ease.OutQuart);
    }
}

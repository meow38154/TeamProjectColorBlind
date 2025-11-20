using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class HealthFade : MonoBehaviour
{
    [SerializeField] private Ease _ease;
    [SerializeField] private Image _image;

    public void DPlay()
    {
        Sequence seq = DOTween.Sequence();

        seq.Append(transform.DOScaleX(transform.root.localScale.x + 0.5f, 0.1f).SetEase(_ease));
        seq.AppendCallback(() => {
            _image.gameObject.SetActive(false);
        });
        seq.Append(transform.DOScaleX(transform.root.localScale.x - 0.5f, 0.1f).SetEase(_ease));
    }



    public void HPlay()
    {
        Sequence seq = DOTween.Sequence();

        seq.Append(transform.DOScaleX(transform.root.localScale.x + 0.5f, 0.1f).SetEase(_ease));
        seq.AppendCallback(() => {
            _image.gameObject.SetActive(true);
        });
        seq.Append(transform.DOScaleX(transform.root.localScale.x - 0.5f, 0.1f).SetEase(_ease));
    }
}

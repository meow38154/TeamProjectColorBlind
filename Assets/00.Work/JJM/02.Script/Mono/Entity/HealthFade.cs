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

        _image.gameObject.SetActive(false);
        seq.Append(transform.parent.DOScaleX(1.3f, 0.1f).SetEase(_ease));
        seq.Append(transform.parent.DOScaleX(1f, 0.1f).SetEase(_ease));
    }



    public void HPlay()
    {
        Debug.Log("Èú");
        Sequence seq = DOTween.Sequence();
        _image.gameObject.SetActive(true);
        seq.Append(transform.parent.DOScaleX(1.3f, 0.1f).SetEase(_ease));
        seq.Append(transform.parent.DOScaleX(1f, 0.1f).SetEase(_ease));
    }
}

using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class Warning : MonoBehaviour
{
    [SerializeField] private Image _image;

    public void Fade()
    {
        Sequence seq = DOTween.Sequence();
        seq.Append(_image.DOFade(_image.color.a + 0.4f, 0.02f));
        seq.Append(_image.DOFade(0f, 0.3f));
    }
}

using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class SceneFade : MonoBehaviour
{
    [SerializeField] private float _time;
    [SerializeField] private float _bossTime;
    private Image _image;

    private void Awake()
    {
        _image = GetComponent<Image>();
        _image.DOFade(1, 0);
    }

    private void Start()
    {
        Sequence seq = DOTween.Sequence();
        seq.AppendInterval(_time);
        seq.Append(_image.DOFade(0, 1));
        seq.AppendInterval(_bossTime);
        seq.AppendCallback(() =>
        {
            InGameManager.Instance.Boss.BossStart();
            _image.gameObject.SetActive(false);
        });
    }
    public void Out()
    {
        _image.gameObject.SetActive(true);

        Sequence seq = DOTween.Sequence();
        seq.Append(_image.DOFade(1, 0.5f));
        seq.AppendInterval(_time);
        seq.AppendCallback(() =>
        {
            SoundManager.Instance.BgmSource.volume = 0;
        });
        seq.AppendInterval(_bossTime);
        seq.AppendCallback(() =>
        {
            
        });
    }
}

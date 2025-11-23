using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class PlayerDeathEvent : MonoBehaviour
{
    private GameObject _parents;
    private HealthSystem _healthSystem;
    [SerializeField] private CanvasGroup _can;

    private void Awake()
    {
        _healthSystem = GetComponentInParent<HealthSystem>();
        _parents = transform.root.gameObject;
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

    private void Play()
    {
        _can.gameObject.SetActive(true);
        _can.DOFade(1f, 1f);

        var bgm = SoundManager.Instance.BgmSource;
        var saveB = SoundManager.Instance.BgmSource.volume;
        var saveP = SoundManager.Instance.BgmSource.pitch;

        DOTween.To(() => bgm.volume, x => bgm.volume = x, saveB * 0.3f, 1f);
        DOTween.To(() => bgm.pitch, x => bgm.pitch = x, saveP * 0.5f, 1f);
    }

}

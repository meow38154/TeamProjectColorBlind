using DG.Tweening;
using System;
using UnityEngine;
using UnityEngine.UI;

public class ManaBar : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private float maxHealth = 100f;

    [SerializeField] private Image _fillImage;

    public float CurrentHealth { get; set; }

    private void Start()
    {
        CurrentHealth = 0f;
        slider.maxValue = maxHealth;
        slider.value = CurrentHealth;
    }

    public void AddHealth(float value)
    {
        Sequence seq = DOTween.Sequence();
        seq.Append(_fillImage.DOColor(Color.white, 0f));
        seq.Append(_fillImage.DOColor(Color.black, 0.2f));

        CurrentHealth += value;
        if(CurrentHealth > maxHealth)
            CurrentHealth = maxHealth;

        slider.value = CurrentHealth;
    }

    public void Somo()
    {
        Sequence seq = DOTween.Sequence();
        _fillImage.DOColor(Color.white, 0.1f);
        seq.Append(slider.DOValue(0f, 0.5f).SetEase(Ease.Linear));
        CurrentHealth = 0f;
        seq.Append(_fillImage.DOColor(Color.black, 0.2f));
    }
}

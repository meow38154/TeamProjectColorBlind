using System;
using UnityEngine;
using UnityEngine.UI;

public class ManaBar : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private float maxHealth = 100f;
    private float currentHealth;

    private void Start()
    {
        currentHealth = 0f;
        slider.maxValue = maxHealth;
        slider.value = currentHealth;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            AddHealth(10f); 
        }
    }

    private void AddHealth(float value)
    {
        currentHealth += value;
        if(currentHealth > maxHealth)
            currentHealth = maxHealth;

        slider.value = currentHealth;
    }
}

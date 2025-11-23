using System;
using JJM;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonEvent : MonoBehaviour
{
    [SerializeField] private string NextSceneName;
    [SerializeField] private GameObject OptionPanel;
    [SerializeField] private Slider slider;

    private void Awake()
    {
        slider.value = SaveManager.Instance.Data.soundSetting;
    }

    private void Update()
    {
        SaveManager.Instance.Data.soundSetting = slider.value;
        
    }

    public void StartButton()
    {
        SceneManager.LoadScene(NextSceneName);
    }

    public void Slider()
    {
    }
    public void OptionButton()
    {
        OptionPanel.SetActive(true);
        Time.timeScale = 0;
    }

    public void QuitButton()
    {
        Application.Quit();
    }

    public void OptionQuitButton()
    {
        Time.timeScale = 1;
        OptionPanel.SetActive(false);
    }
}

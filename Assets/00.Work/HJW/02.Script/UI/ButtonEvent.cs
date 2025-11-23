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

    private void Start()
    {
        slider.value = SaveManager.Instance.Data.soundSetting;
    }

    private void Update()
    {

        SaveManager.Instance.Data.soundSetting = slider.value;
        SaveManager.Instance.Save();
    }

    public void StartButton()
    {
        Time.timeScale = 1;

        SceneManager.LoadScene(NextSceneName);
    }

    public void Slider()
    {
    }
    public void OptionButton()
    {
        SoundManager.Instance.PlaySound(16, 0.8f);
        OptionPanel.SetActive(true);
        Time.timeScale = 0;
    }

    public void QuitButton()
    {
        Application.Quit();
    }

    public void OptionQuitButton()
    {
        SoundManager.Instance.PlaySound(16, 0.8f);
        Time.timeScale = 1;
        OptionPanel.SetActive(false);
    }
}

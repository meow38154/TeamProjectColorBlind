using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonEvent : MonoBehaviour
{
    [SerializeField] private string NextSceneName;
    [SerializeField] private GameObject OptionPanel;
    public void StartButton()
    {
        SceneManager.LoadScene(NextSceneName);
    }

    public void OptionButton()
    {
        OptionPanel.SetActive(true);
    }

    public void QuitButton()
    {
        UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }

    public void OptionQuitButton()
    {
        OptionPanel.SetActive(false);
    }
}

using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public string sceneName;
    
    public void LoadScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}

using JJM;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    [SerializeField] private bool not;
    [SerializeField] private int num;
    public string sceneName;

    private Image _image;

    private void Awake()
    {
        _image = GetComponentInChildren<Image>();
    }

    private void Update()
    {
        if (SaveManager.Instance.Data.itemSetting[num] || not)
        {
            _image.color = Color.white;
        }

        else
        {
            _image.color = Color.black;
        }
    }

    public void LoadScene()
    {
        if (SaveManager.Instance.Data.itemSetting[num] || not)
        {
            SoundManager.Instance.PlaySound(16, 0.8f);
            SceneManager.LoadScene(sceneName);
        }
        else
        {
            SoundManager.Instance.PlaySound(16, 0.8f, 0.5f);
        }
    }
}

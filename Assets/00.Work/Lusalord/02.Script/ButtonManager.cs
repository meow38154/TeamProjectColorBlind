using System;
using JJM;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    [SerializeField] private bool not;
    [SerializeField] private int num;
    public string sceneName;

    private Image Image => GetComponentInChildren<Image>();

    private void Start()
    {
        try
        {
            if (Image == null)
            {
                throw new NullReferenceException("자식 객체에서 Image 컴포넌트를 찾을 수 없습니다.");
            }
            
            Image.enabled = true;
        }
        catch (Exception e)
        {
            Debug.LogError($"[Example] Image 참조 오류: {e.Message}\n{e.StackTrace}");
        }
    }

    private void Update()
    {
        if (SaveManager.Instance.Data.itemSetting[num] || not)
        {
            Image.color = Color.white;
        }

        else
        {
            Image.color = Color.black;
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

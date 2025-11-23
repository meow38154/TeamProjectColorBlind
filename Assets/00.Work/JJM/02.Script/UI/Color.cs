using DG.Tweening;
using JJM;
using UnityEngine;
using UnityEngine.UI;

public class UIColor : MonoBehaviour
{
    [SerializeField] private int num;
    [SerializeField] private Image _image;

    [SerializeField] private Color _color;

    private bool _use;

    public void Num(int n)
    {
        if (_use)
        {
            SoundManager.Instance.PlaySound(16, 0.8f);
            SaveManager.Instance.Data.useItem = n;
            SaveManager.Instance.Save();
        }
        else
        {
            SoundManager.Instance.PlaySound(16, 0.8f, 0.5f);
        }
    }

    private void Update()
    {
        if (num != 0)
        {
            if (!SaveManager.Instance.Data.itemSetting[num - 1])
            {
                transform.GetChild(0).GetComponentInChildren<Image>().color = Color.black;
                _use = false;
            }
            else
            {
                transform.GetChild(0).GetComponentInChildren<Image>().color = Color.white;
                _use = true;
            }
        }

        else
        {
            _use = true;
        }

        if (num == SaveManager.Instance.Data.useItem)
        {
            _image.DOColor(_color, 0.5f);
        }
        else
        {
            _image.DOColor(Color.white, 0.5f);

        }
    }
}

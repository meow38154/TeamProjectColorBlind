using DG.Tweening;
using JJM;
using UnityEngine;
using UnityEngine.UI;

public class UIColor : MonoBehaviour
{
    [SerializeField] private int num;
    [SerializeField] private Image _image;

    [SerializeField] private Color _color;

    public void Num(int n)
    {
        SaveManager.Instance.Data.useItem = n;
        SaveManager.Instance.Save();
    }

    private void Update()
    {
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

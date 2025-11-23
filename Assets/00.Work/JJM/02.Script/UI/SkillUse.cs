using JJM;
using UnityEngine;

public class SkillUse : MonoBehaviour
{
    [SerializeField] private int num;

    private void Start()
    {
        SaveManager.Instance.Data.itemSetting[num] = true;
        SaveManager.Instance.Save();
    }
}

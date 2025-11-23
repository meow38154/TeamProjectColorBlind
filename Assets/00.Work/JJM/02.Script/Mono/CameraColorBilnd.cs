using JJM;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class CameraColorBilnd : MonoBehaviour
{
    [SerializeField] private Volume volume;

    private void Update()
    {
        ColorAdjustments colorAdj;
        if (volume.profile.TryGet(out colorAdj))
        {
            colorAdj.saturation.value = SaveManager.Instance.Data.colorBlindness;
        }
    }
}

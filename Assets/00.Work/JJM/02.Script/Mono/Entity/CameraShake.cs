using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public void CameraShakePlay()
    {
        GameManager.Instance.CinemachineImpulseSource.GenerateImpulse();
    }
}

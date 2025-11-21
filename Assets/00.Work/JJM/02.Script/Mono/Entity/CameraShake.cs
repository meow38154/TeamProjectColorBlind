using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public void CameraShakePlay()
    {
        InGameManager.Instance.CinemachineImpulseSource.GenerateImpulse();
    }
}

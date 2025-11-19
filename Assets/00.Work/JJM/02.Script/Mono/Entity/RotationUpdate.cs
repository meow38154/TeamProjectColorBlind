using UnityEngine;

public class RotationUpdate : MonoBehaviour
{
    [SerializeField] private Quaternion _quaternion;
    void Update()
    {
        transform.rotation *= _quaternion;
    }
}

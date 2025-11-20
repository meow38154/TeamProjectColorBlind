using UnityEngine;

public class RotationClone : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private bool _notZ = false;

    private void Update()
    {
        if (_notZ)
        {
            transform.localRotation = Quaternion.Euler(0, _target.eulerAngles.y, 45f);
        }
        else
            transform.rotation = _target.rotation;
    }
}

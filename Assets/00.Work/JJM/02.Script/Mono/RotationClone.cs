using UnityEngine;

public class RotationClone : MonoBehaviour
{
    [SerializeField] private Transform _target;

    private void Update()
    {
        transform.rotation = _target.rotation;
    }
}

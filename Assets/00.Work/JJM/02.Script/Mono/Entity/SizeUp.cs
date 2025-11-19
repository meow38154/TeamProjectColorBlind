using UnityEngine;

public class SizeUp : MonoBehaviour
{
    [SerializeField] private bool _play;
    [SerializeField] private Vector3 _size;
    [SerializeField] private float _speed;

    private Vector3 _saveSize;

    private void Awake()
    {
        _saveSize = transform.localScale;
    }

    void Update()
    {
        if (_play)
        transform.localScale = Vector3.Lerp(transform.localScale, _size, Time.deltaTime * _speed);
    }
}

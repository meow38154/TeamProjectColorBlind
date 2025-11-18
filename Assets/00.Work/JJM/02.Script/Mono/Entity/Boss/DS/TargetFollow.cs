using UnityEngine;

public class TargetFollow : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _speed = 5;

    public bool Move { get; set; } = true;

    void Update()
    {
        if (Move)
        {
            transform.position = Vector3.Lerp(transform.position, _target.position, _speed * Time.deltaTime);
            transform.position = new Vector3(transform.position.x, 5.7f, transform.position.z);
        }
    }
}

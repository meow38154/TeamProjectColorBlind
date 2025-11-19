using UnityEngine;

public class TargetFollow : MonoBehaviour
{

    [SerializeField] private Transform _target;
    [SerializeField] private float _speed = 5;
    [SerializeField] private float _y = 5.7f;
    [SerializeField] private float _distance = 7f;
    public bool Move { get; set; } = true;

    private float distance;

    void Update()
    {
        distance = Vector2.Distance(transform.position, _target.position);

        if (Move)
        {
            if (distance > _distance)
            {
                transform.position = Vector3.Lerp(transform.position, _target.position, (_speed / 2.5f) * Time.deltaTime);
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, _target.position, _speed * Time.deltaTime);
            }
                transform.position = new Vector3(transform.position.x, _y, transform.position.z);
        }
    }
}

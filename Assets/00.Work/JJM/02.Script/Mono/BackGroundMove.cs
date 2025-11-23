using UnityEngine;

public class BackGroundMove : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;

    void Update()
    {
        transform.position += Time.deltaTime * Vector3.right * _speed;

        if (transform.localPosition.x > 3)
        {
            transform.localPosition = new Vector3(-3, transform.localPosition.y, transform.localPosition.z);
        }
    }
}

using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour
{
    public float Speed { get; set; }

    [SerializeField] private float DurationTime = 5f;

    private void OnEnable()
    {
        StartCoroutine(DieTime());
    }

    private void FixedUpdate()
    {
        transform.position += transform.right * Speed * Time.deltaTime;
    }

    private IEnumerator DieTime()
    {
        yield return new WaitForSeconds(DurationTime);
        Destroy(gameObject);
    }
}

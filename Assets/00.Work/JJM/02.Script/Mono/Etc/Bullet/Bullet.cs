using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour
{
    public float Speed { get; set; }
    public bool Move { get; set; } = true;

    [SerializeField] private int _sound;
    [SerializeField] private float _pitch;
    [SerializeField] private float _volnum;
    [SerializeField] private float DurationTime = 5f;

    private bool _isPlayed;

    private void OnEnable()
    {
        StartCoroutine(DieTime());
    }

    private void FixedUpdate()
    {
        if (Move)
        {
            transform.position += transform.right * Speed * Time.deltaTime;
        }

        if (!_isPlayed)
        {
            var cam = Camera.main;
            Vector3 view = cam.WorldToViewportPoint(transform.position);

            if (view.x > 0f && view.x < 1f &&
                view.y > 0f && view.y < 1f &&
                view.z > 0f)
            {
                SoundManager.Instance.PlaySound(_sound, _volnum, _pitch);
                _isPlayed = true;
            }
        }
    }

    private IEnumerator DieTime()
    {
        yield return new WaitForSeconds(DurationTime);
        Destroy(gameObject);
    }
}

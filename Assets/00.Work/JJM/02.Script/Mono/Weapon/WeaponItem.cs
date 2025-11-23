using UnityEngine;

public class WeaponItem : MonoBehaviour
{
    [SerializeField] private bool _rigid;
    [SerializeField] private float _speed = 10;

    private Rigidbody2D _rb;

    private void Awake()
    {
        try
        {
            _rb = GetComponent<Rigidbody2D>();
            if (_rigid && _rb == null)
                throw new System.Exception("Rigidbody2D ¾øÀ½");
        }
        catch (System.Exception e)
        {
            Debug.LogError($"[WeaponItem] {e.Message}", this);
        }
    }

    private void Start()
    {
        transform.rotation = Quaternion.Euler(
            0,
            0,
            InGameManager.Instance.TargetLook(
                transform.position,
                Camera.main.ScreenToWorldPoint(Input.mousePosition)
            )
        );

        if (_rigid && _rb != null)
        {
            _rb.AddForce(transform.right * _speed, ForceMode2D.Impulse);
        }
    }

    private void Update()
    {
        if (!_rigid)
        {
            transform.position += transform.right * Time.deltaTime * _speed;
        }
    }
}

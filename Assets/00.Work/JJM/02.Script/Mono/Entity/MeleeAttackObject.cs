using UnityEngine;

public class MeleeAttackObject : MonoBehaviour
{
    [SerializeField] private bool _collider = false;
    [Header("Vector")]
    [SerializeField] private int damage = 1;

    [Header("Vector")]
    [SerializeField] private Vector2 _pos;
    [SerializeField] private Vector2 _size;

    [Header("Etc")]
    [SerializeField] private LayerMask _layer;
    [SerializeField] private Color _color;

    private void Update()
    {
        if (!_collider)
        {
            Collider2D[] collider = Physics2D.OverlapBoxAll(transform.position + (Vector3)_pos, _size, transform.eulerAngles.z, _layer);

            foreach (var i in collider)
            {
                if (i.transform.Find("Health").TryGetComponent(out HealthSystem health))
                {
                    health.GetDamage(damage, transform);
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        int layer = collision.gameObject.layer;

        if (((1 << layer) & _layer.value) != 0)
        {
            if (collision.transform.Find("Health").TryGetComponent(out HealthSystem health))
            {
                health.GetDamage(damage, transform);
            }
        }

    }

    private void OnDrawGizmos()
    {
        if (!_collider)
        {
            Gizmos.color = _color;
            Matrix4x4 rot = Matrix4x4.TRS(transform.position + (Vector3)_pos, Quaternion.Euler(0, 0, transform.eulerAngles.z), Vector3.one);
            Gizmos.matrix = rot;
            Gizmos.DrawWireCube(Vector3.zero, _size);
            Gizmos.matrix = Matrix4x4.identity;
        }
    }

}

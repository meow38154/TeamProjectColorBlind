using UnityEngine;

public class MeleeAttackObject : MonoBehaviour
{
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
        Collider2D[] collider = Physics2D.OverlapBoxAll(transform.position + (Vector3)_pos, _size, 0, _layer);

        foreach (var i in collider)
        {
            if (i.transform.Find("Health").TryGetComponent(out HealthSystem health))
            {
                health.GetDamage(damage, transform);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = _color;
        Gizmos.DrawWireCube(transform.position + (Vector3)_pos, _size);
    }
}

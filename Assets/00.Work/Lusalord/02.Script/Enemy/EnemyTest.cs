using System;
using UnityEngine;

public class EnemyTest : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        HealthSystem health = other.collider.GetComponentInChildren<HealthSystem>();
        if (health != null)
        {
            health.GetDamage(1);
        }
    }
}

using System;
using UnityEngine;

public class EnemyTest : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        HealthSystem health = other.gameObject.GetComponentInChildren<HealthSystem>();

        health.GetDamage(1, other.transform);
    }
}

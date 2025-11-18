using System;
using _00.Work.Lusalord._02.Script.Player;
using UnityEngine;

public class DamageCaster : MonoBehaviour
{
    public Transform CurrentEnemy { get; private set; }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag($"Enemy"))
        {
            CurrentEnemy = other.transform;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag($"Enemy"))
        {
            if (CurrentEnemy == other.transform)
            {
                CurrentEnemy = null;
            }
        }
    }
}

using System;
using _00.Work.Lusalord._02.Script.Player;
using UnityEngine;

public class PlayerDamageCaster : MonoBehaviour
{
    public Player player;
    [SerializeField] private GameObject damageCaster;
    
    private void Awake()
    {
        
    }
    private void FixedUpdate()
    {
        Vector3 p = player.PlayerInput.MousePos;
        Vector2 dir = p - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        damageCaster.transform.rotation = Quaternion.Euler(0, 0, angle - 90);
    }
}

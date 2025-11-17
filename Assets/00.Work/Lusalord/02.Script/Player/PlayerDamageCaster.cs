using System;
using _00.Work.Lusalord._02.Script.Player;
using UnityEngine;

public class PlayerDamageCaster : MonoBehaviour
{
    private Player _player;
    [SerializeField] private GameObject damageCaster;
    
    
    private void Awake()
    {
        _player = GetComponent<Player>();
    }
    private void FixedUpdate()
    {
        Vector3 p = _player.PlayerInput.MousePos;
        Vector2 dir = p - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        damageCaster.transform.rotation = Quaternion.Euler(0, 0, angle - 90);
    }
}

using System;
using UnityEngine;

[Serializable]
public struct BulletSetting
{
    [Header("다음 꺼 발사 이후 몇 초 후에 나옴?")]
    public int _waitTime;

    [Header("속도 관련")]
    public float _speed;

    [Header("방향 관련")]
    public float _lookRotation;
    public bool _lookPlayer;

    [Header("기타")]
    public GameObject _bullet;
}

[CreateAssetMenu(fileName = "BulletFireSO", menuName = "Scriptable Objects/BulletFireSO")]
public class BulletFireSO : PatternSO
{
    [SerializeField] public BulletSetting _bulletSetting;

    private void OnEnable()
    {
        BossStateData = new BossBulletFireState();
    }
}

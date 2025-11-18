using System;
using UnityEngine;

[Serializable]
public struct BulletSetting
{
    [Header("다음 꺼 발사 이후 몇 초 후에 나옴?")]
    public float _waitTime;

    [Header("속도 관련")]
    public float _speed;

    [Header("방향 관련")]
    public float _lookRotation;
    public bool _lookPlayer;

    [Header("기타")]
    public Vector2 _pos;
    public GameObject _bullet;
}

[CreateAssetMenu(fileName = "BulletFireSO", menuName = "Scriptable Objects/BulletFireSO")]
public class BulletFireSO : PatternSO
{
    [SerializeField] public BulletSetting[] _bulletSetting;
    public float _endDelay;

    private void OnEnable()
    {
        SettingUpdate();
    }
    public override void SettingUpdate()
    {
        BossStateData = new BossBulletFireState(_bulletSetting, _endDelay);
    }
}
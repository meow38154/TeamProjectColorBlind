
using System.Collections;
using UnityEngine;

public class BossBulletFireState : BossState
{
    public BulletSetting _bulletSetting;

    public BossBulletFireState(BulletSetting bulletSetting)
    {
        _bulletSetting = bulletSetting;
    }

    public override void Enter()
    {
        
    }

    public IEnumerator BulletFire()
    {
        for (int i = 0; i < _count; i++)
        {
            GameObject bullet = Object.Instantiate(_bullet);
            bullet.transform.rotation = Q
            yield return new WaitForSeconds(_waitTime);
        }
    }

    public override void UpdateState() { }
    public override void Exit() { }

    public override void Test() { }
}

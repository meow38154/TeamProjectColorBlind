
using NUnit.Framework;
using System.Collections;
using UnityEngine;

public class BossBulletFireState : BossState
{
    public BulletSetting[] _bulletSetting;

    public BossBulletFireState(BulletSetting[] bulletSetting, float endDelay)
    {
        _bulletSetting = bulletSetting;

        foreach (var i in _bulletSetting)
        {
            PatternPlayTime += i._waitTime;
        }

        PatternPlayTime += endDelay;
    }

    public override void Enter()
    {
        _bossObject.StartCoroutine(BulletFire());
    }

    public IEnumerator BulletFire()
    {
        GameManager gameManager = GameManager.Instance;
        foreach (var i in _bulletSetting)
        {
            yield return new WaitForSeconds(i._waitTime);
            GameObject bullet = Object.Instantiate(i._bullet);
            Debug.Log("정상 작동");
            Bullet bulletCompo = bullet.GetComponent<Bullet>();

            bullet.transform.position = _bossObject.transform.position + (Vector3)i._pos;

            bulletCompo.Speed = i._speed;



            if (!i._lookPlayer)
            {
                bullet.transform.rotation = Quaternion.Euler(0, 0,
                    i._lookRotation);
            }
            else
            {
                bullet.transform.rotation = Quaternion.Euler(0, 0,
                    gameManager.TargetLook(bullet.transform, gameManager.Player.transform));
            }

        }
    }

    public override void UpdateState() { }
    public override void Exit() { }

    public override void Test() { }
}

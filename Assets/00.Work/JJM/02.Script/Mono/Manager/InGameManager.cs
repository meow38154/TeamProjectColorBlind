using System;
using Unity.Cinemachine;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;
using JJM;
using System.Collections;

public class InGameManager : Singleton<InGameManager>
{
    [field: SerializeField] public GameObject Player { get; private set; }
    [field: SerializeField] public Boss Boss { get; private set; }
    [field: SerializeField] public CinemachineImpulseSource CinemachineImpulseSource { get; private set; }
    [field: SerializeField] public ManaBar ManaBar { get; private set; }
    [field: SerializeField] public Warning Warning { get; private set; }

    [SerializeField] private Vector3 size;

    [SerializeField] private float _time = 7f;

    public Action OnHealthUpdate;


    public int TargetAndPlayerDirectionValue(Transform targetTransform) //타겟이 플레이어보다 왼쪽에 있는지 오른쪽에 있는 지 판별 후 값을 리턴하는 메서드 
    {
        Vector3 value = targetTransform.position - Player.transform.position; //타겟 위치 - 플레이어 위치 저장

        float valuePosX = value.x; //나온 값에 x만 분리
        float directionValue = value.x / Mathf.Abs(value.x); //(대충 -1이랑 1만 나오게 하는 개 쩌는 공식)

        return Mathf.Clamp(-(int)directionValue, -1, 1); //반환
    }

    public float TargetLook(Transform main, Transform target)
    {
        Vector2 mainPos = main.position;
        Vector2 targetPos = target.position;

        Vector2 dir = targetPos - mainPos;

        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

        return angle;
    }
    public float TargetLook(Vector2 main, Vector2 target)
    {
        Vector2 mainPos = main;
        Vector2 targetPos = target;

        Vector2 dir = targetPos - mainPos;

        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

        return angle;
    }

    private void Update()
    {
        //int c = 0;
        //foreach (var i in SaveManager.Instance.Data.itemSetting)
        //{
        //    if (i)
        //        c++;
        //}

        //switch (c)
        //{
        //    case 0:
        //        SaveManager.Instance.Data.colorBlindness = -100f;
        //        break;
        //    case 1:
        //        SaveManager.Instance.Data.colorBlindness = -75f;
        //        break;
        //    case 2:
        //        SaveManager.Instance.Data.colorBlindness = -50f;
        //        break;
        //    case 3:
        //        SaveManager.Instance.Data.colorBlindness = -25f;
        //        break;
        //    default:
        //        SaveManager.Instance.Data.colorBlindness = 0f;
        //        break;
        //}
        //SaveManager.Instance.Save();
    }

    public void Afterimage(SpriteRenderer spriteRenderer)
    {
        GameObject image = new GameObject();
        SpriteRenderer r = image.AddComponent<SpriteRenderer>();
        r.flipX = spriteRenderer.flipX;
        image.transform.position = spriteRenderer.transform.position;
        image.transform.rotation = spriteRenderer.transform.rotation;
        image.transform.localScale = size;
        r.sprite = spriteRenderer.sprite;
        Sequence seq = DOTween.Sequence();
        seq.Append(r.DOFade(0, 0.15f));
        seq.AppendCallback(() =>
        {
            Destroy(image);
        });

    }

    public void ScenePlay(int num)
    {
        SceneManager.LoadScene(num);
    }
    public void ScenePlay(string name)
    {
        SceneManager.LoadScene(name);
    }

    public void S(string name)
    {
        StartCoroutine(Scene(name));
    }

    private IEnumerator Scene(string name)
    {
        yield return new WaitForSeconds(_time);
        ScenePlay(name);
    }
}

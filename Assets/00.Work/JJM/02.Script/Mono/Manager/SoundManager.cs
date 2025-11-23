using DG.Tweening;
using JJM;
using System.Collections;
using UnityEditor;
using UnityEngine;

public enum SoundType
{
    BGM,
    Sound
}

public class SoundManager : Singleton<SoundManager>
{
    [SerializeField] private AudioClip[] _audioClip;
    [SerializeField] private AudioClip _sceneBGM;
    [SerializeField] private float _sceneBGMVolnum;
    public AudioSource BgmSource { get; set; }

    private bool _v;

    private void Start()
    {
        BgmSource = gameObject.AddComponent<AudioSource>();
        BgmSource.loop = true;
        BgmSource.clip = _sceneBGM;
        BgmSource.volume = 0;
        BgmSource.Play();
        Sequence seq = DOTween.Sequence();
        seq.Append(DOTween.To(() => BgmSource.volume, x => BgmSource.volume = x, _sceneBGMVolnum * SaveManager.Instance.Data.soundSetting, 1f));
        seq.AppendCallback(() => { _v = true; });
    }

    private void Update()
    {
        if (_v)
        {
            BgmSource.volume = _sceneBGMVolnum * SaveManager.Instance.Data.soundSetting;
        }
    }

    public void PlaySound(int soundNum, float volume, float pitch = 1f)
    {
        if (BgmSource.pitch > 0.9f)
        {
            AudioSource audioSource = gameObject.AddComponent<AudioSource>();
            audioSource.clip = _audioClip[soundNum];
            audioSource.volume = volume * SaveManager.Instance.Data.soundSetting;
            audioSource.pitch = pitch;
            audioSource.Play();
            StartCoroutine(Remove(audioSource.clip.length, audioSource));
        }
    }

    public IEnumerator Remove(float len, AudioSource a)
    {
        yield return new WaitForSeconds(len);
        Destroy(a);
    }
}

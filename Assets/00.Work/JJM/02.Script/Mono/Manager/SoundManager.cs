using System.Collections;
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
    AudioSource bgmSource;

    private void Start()
    {
        bgmSource = gameObject.AddComponent<AudioSource>();
        bgmSource.loop = true;
        bgmSource.clip = _sceneBGM;
        bgmSource.Play();
        bgmSource.volume = _sceneBGMVolnum;
    }

    public void PlaySound(int soundNum, float volume)
    {
        AudioSource audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = _audioClip[soundNum];
        audioSource.volume = volume * 1f;
        audioSource.Play();
        StartCoroutine(Remove(audioSource.clip.length, audioSource));
    }

    public IEnumerator Remove(float len, AudioSource a)
    {
        yield return new WaitForSeconds(len);
        Destroy(a);
    }
}

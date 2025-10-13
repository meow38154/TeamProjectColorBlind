using UnityEngine;

public enum SoundType
{
    BGM,
    Sound
}

public class SoundManager : Singleton<SoundManager>
{
    [SerializeField] private AudioClip[] _audioClip;


    public void PlaySound(int soundNum, float volume, Transform source, SoundType type)
    {
        AudioSource.PlayClipAtPoint(_audioClip[soundNum], source.position, volume);
    }
}

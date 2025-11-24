using UnityEngine;

namespace _00.Work.Lusalord._02.Script.Manager
{
    public class AudioManager : Singleton<AudioManager>
    {
        public AudioSource bgmSource;
        public AudioSource seSource;
        public AudioSource voiceSource;
    
        public void PlayBGM(AudioClip clip)
        {
            if (clip == null) return;
            if (bgmSource.clip == clip) return;

            bgmSource.clip = clip;
            bgmSource.loop = true;
            bgmSource.Play();
        }

        public void PlaySE(AudioClip clip)
        {
            if (clip == null) return;
            seSource.PlayOneShot(clip);
        }

        public void PlayVoice(AudioClip clip)
        {
            if (clip == null) return;
            voiceSource.Stop();
            voiceSource.clip = clip;
            voiceSource.Play();
        }
    }
}

using System.Collections.Generic;
using _00.Work.Lusalord._02.Script.Story.StoryData;
using UnityEngine;

[CreateAssetMenu(fileName = "AudioDataBaseSO", menuName = "SO/Story/AudioDataBaseSO")]
public class AudioDataBaseSO : ScriptableObject
{
    public List<AudioData> bgmList;
    public List<AudioData> seList;
    public List<AudioData> voiceList;

    public AudioClip GetBGM(string key)
    {
        foreach (var d in bgmList)
            if (d.key == key) return d.clip;
        return null;
    }

    public AudioClip GetSE(string key)
    {
        foreach (var d in seList)
            if (d.key == key) return d.clip;
        return null;
    }

    public AudioClip GetVoice(string key)
    {
        foreach (var d in voiceList)
            if (d.key == key) return d.clip;
        return null;
    }
}

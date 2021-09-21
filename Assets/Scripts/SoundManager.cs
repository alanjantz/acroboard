using System.Linq;
using UnityEngine;

public static class SoundManager
{
    public static void PlaySound(Sounds sound)
    {
        var gameObject = new GameObject("Sound", typeof(AudioSource));
        AudioSource audioSource = gameObject.GetComponent<AudioSource>();
        audioSource.PlayOneShot(GetAudioClip(sound));
    }

    private static AudioClip GetAudioClip(Sounds sound)
        => GameHandler.GetInstance().SoundAudioClips.FirstOrDefault(audio => audio.Sound == sound)?.AudioClip;
}

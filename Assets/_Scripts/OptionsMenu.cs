using UnityEngine;
using UnityEngine.Audio;

public class OptionsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    public AudioManager audioManager;

    public void SetVolume(float volume)
    {
        audioManager.sounds[0].volume = volume;
        Debug.Log(volume);
    }
}

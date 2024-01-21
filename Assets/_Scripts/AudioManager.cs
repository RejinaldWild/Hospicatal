using UnityEngine;
using System.Collections.Generic;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public List<Sound> sounds;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        foreach (var s in sounds)
        {
            s.sorce = gameObject.AddComponent<AudioSource>();
            s.sorce.clip = s.clip;
            s.sorce.volume = s.volume;
            s.sorce.pitch = s.pitch;
            s.sorce.loop = s.loop;
        }
    }

    private void Start()
    {
        Play("MainMenu");
    }

    public void Play(string name)
    {
        Sound sound = sounds.Find(s => s.name == name);
        if (sound == null)
        {
            Debug.Log("Sound " + sound.name + " doesn't exist");
            return;
        }
        sound.sorce.Play();
    }
}

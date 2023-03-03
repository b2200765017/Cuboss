using System;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    #region singleton
    public static SoundManager instance;
    private void Start()
    {
        if (instance == null) instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
        PlayMusic();
    }
    #endregion singleton

    public Sound[] _sounds;
    public Sound[] _xpCollection;
    public Sound[] _Slides;
    public float delay;
    float timer;

    private void Awake()
    {
        foreach (Sound s in _sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
            s.length = s.clip.length;
        }
        foreach (Sound s in _xpCollection)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
            s.length = s.clip.length;
        }
        foreach (Sound s in _Slides)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
            s.length = s.clip.length;
        }
    }
    private void PlayMusic()
    {
        Sound music = Array.Find(_sounds, sound => sound.name == "Music");
        music.source.Play();
    }
    public void Play(string name)
    {
        Sound music = Array.Find(_sounds, sound => sound.name == name);
        music.source.Play();
    }
    

    public void PlayWithPitch(string name, float pitchStart, float pitchEnd)
    {
        Sound music = Array.Find(_sounds, sound => sound.name == name);
        music.source.pitch = UnityEngine.Random.Range(pitchStart, pitchEnd);
        music.source.Play();
    }
    
    public void PlayXpCollection()
    {
        Sound music = _xpCollection[UnityEngine.Random.Range(0,_xpCollection.Length)];
        music.source.Play();
    }
    
    public void PlaySlide()
    {
        Sound music = _Slides[UnityEngine.Random.Range(0,_Slides.Length)];
        music.source.Play();
    }
    
}

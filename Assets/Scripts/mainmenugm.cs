using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class mainmenugm : MonoBehaviour
{
    private bool isHowToMenuOpened = false;
    public Animator HowToMenuAnimator;
    private AudioSource MenuMusicSource;
    public Image musicOff;
    public Image musicOn;
    private const string MenuMusicEnabled = "MenuMusic";

    public void OnPlayButtonDown()
    {
       Loader.Load(Loader.Scene.Game);
    }

    private void Start()
    {
        Application.targetFrameRate = 60;
        QualitySettings.vSyncCount = 1;
        MenuMusicSource = SoundManager.instance._sounds[0].source;
        if (PlayerPrefs.GetInt(MenuMusicEnabled, 1) == 0)
        {
            MusicButton();
        }
    }

    public void EnterExitHowToMenu()
    {

        if (!isHowToMenuOpened) HowToMenuAnimator.SetTrigger("open");
        else HowToMenuAnimator.SetTrigger("close");
        isHowToMenuOpened = !isHowToMenuOpened;
    }

    public void MusicButton()
    {
        if (musicOn.enabled)
        {
            musicOn.enabled = false;
            musicOff.enabled = true;
            MenuMusicSource.Pause();
            PlayerPrefs.SetInt(MenuMusicEnabled, 0);
        }
        else
        {
            musicOn.enabled = true;
            musicOff.enabled = false;
            MenuMusicSource.UnPause();
            PlayerPrefs.SetInt(MenuMusicEnabled, 1);
        }
        PlayerPrefs.Save();
    }


}

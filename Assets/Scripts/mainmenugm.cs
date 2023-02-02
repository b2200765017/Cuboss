using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class mainmenugm : MonoBehaviour
{
    private bool isHowToMenuOpened = false;
    public Animator HowToMenuAnimator;
    public AudioSource MenuMusicSource;
    public Image musicOff;
    public Image musicOn;
    

    public void OnPlayButtonDown()
    {
        SceneManager.LoadScene(1);
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
            MenuMusicSource.Stop();
        }
        else
        {
            musicOn.enabled = true;
            musicOff.enabled = false;
            MenuMusicSource.Play();
        }
    }


}

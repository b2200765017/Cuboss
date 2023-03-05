using UnityEngine;
using UnityEngine.UI;

public class mainmenugm : MonoBehaviour {
    
    private const string MenuMusicEnabled = "MenuMusic";
    
    private bool isHowToMenuOpened = false;
    public Animator HowToMenuAnimator;
    private AudioSource MenuMusicSource;
    public Image musicOff;
    public Image musicOn;

    public void OnPlayButtonDown() {
       Loader.Load(Loader.Scene.Game);
    }

    private void Start() {
        Application.targetFrameRate = 500;
        QualitySettings.vSyncCount = 0;
        MenuMusicSource = SoundManager.instance._sounds[0].source;
        if (PlayerPrefs.GetInt(MenuMusicEnabled, 1) == 0) {
            MusicButton();
        }
    }

    //TODO: Animasyon değiştirilip lean tween ile animasyon yapılsın
    public void EnterExitHowToMenu() {

        if (!isHowToMenuOpened) HowToMenuAnimator.SetTrigger("open");
        else HowToMenuAnimator.SetTrigger("close");
        isHowToMenuOpened = !isHowToMenuOpened;
    }

    public void MusicButton() {
        if (musicOn.enabled)
        {
            musicOn.enabled = false;
            musicOff.enabled = true;
            MenuMusicSource.Pause();
            SoundManager.instance.IsSoundOn = false;
            PlayerPrefs.SetInt(MenuMusicEnabled, 0);
        }
        else
        {
            musicOn.enabled = true;
            musicOff.enabled = false;
            MenuMusicSource.UnPause();
            SoundManager.instance.IsSoundOn = true;
            PlayerPrefs.SetInt(MenuMusicEnabled, 1);
        }
        PlayerPrefs.Save();
    }

    public void LanguageButtonClicked()
    {
        if (LanguageManager.Instance.CurrentLanguage == Language.Turkish)
        {
            LanguageManager.Instance.ConvertLanguage(Language.English);
        }
        else
        {
            LanguageManager.Instance.ConvertLanguage(Language.Turkish);
            
        }
    }


}

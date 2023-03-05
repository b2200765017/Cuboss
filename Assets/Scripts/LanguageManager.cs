using System;
using UnityEngine;

public enum  Language
{
    Turkish,
    English
}
public class LanguageManager : MonoBehaviour
{
    public const string LanguagePreference = "Language";
    public event EventHandler OnLanguageChange;  
    public Language CurrentLanguage;
    
    public static LanguageManager Instance { get; private set; }
    private void Awake() {
        if (Instance != null && Instance != this) 
        { 
            Destroy(this); 
        } 
        else 
        { 
            Instance = this; 
        }

        TakeSystemLanguage();
        DontDestroyOnLoad(this);
    }

    private void TakeSystemLanguage()
    {
        if (Application.systemLanguage == SystemLanguage.Turkish)
        {
            CurrentLanguage = Language.Turkish;
        }
        else
        {
            CurrentLanguage = Language.English;
        }

        GetPreferedLanguage();
        OnLanguageChange?.Invoke(this, EventArgs.Empty);
    }

    private void GetPreferedLanguage()
    {
        if (PlayerPrefs.HasKey(LanguagePreference))
        {
            int index = PlayerPrefs.GetInt(LanguagePreference);
            switch (index)
            {
                case 0:
                    CurrentLanguage = Language.Turkish;
                    break;
                case 1:
                    CurrentLanguage = Language.English;
                    break;
            }
        }
    }

    public void SetPreferedLanguage(Language language)
    {
        switch (language)
        {
            case Language.English:
                PlayerPrefs.SetInt(LanguagePreference, 1);
                break;
            case Language.Turkish:
                PlayerPrefs.SetInt(LanguagePreference, 0);
                break;
        }
    }

    public void ConvertLanguage(Language language)
    {
        CurrentLanguage = language;
        SetPreferedLanguage(language);
        OnLanguageChange?.Invoke(this, EventArgs.Empty);
    }
}

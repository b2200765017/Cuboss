using System;
using UnityEngine;

public class GemManager : MonoBehaviour {
    
    private const string GemString = "GemCount";
    public static GemManager Instance;
    public event EventHandler OnGemChanged;

    private int Gem;
    public int DefautGem = 3000;
    void Awake() {
        if (Instance != null) Debug.LogError("There should only be 1 instance of this!");
        Instance = this;
    }

    private void Start() {
        
        Gem = PlayerPrefs.GetInt(GemString, DefautGem);
        OnGemChanged?.Invoke(this, EventArgs.Empty);
    }

    public int GetGem() {
        return Gem;
    }

    public string GetGemString() {
        return GemString;
    }

    public void DecreaseGem(int amount) {
        Gem -= amount;
        PlayerPrefs.SetInt(GemString,Gem);
        PlayerPrefs.Save();
        OnGemChanged?.Invoke(this, EventArgs.Empty);
    }

    
    public void SetGem(int gemCount)
    {
        Gem = gemCount;
        PlayerPrefs.SetInt(GemString,Gem);
        PlayerPrefs.Save();
        OnGemChanged?.Invoke(this, EventArgs.Empty);
    }

    public void IncreaseGem(int amount)
    {
        Gem += amount;
        PlayerPrefs.SetInt(GemString,Gem);
        PlayerPrefs.Save();
        OnGemChanged?.Invoke(this, EventArgs.Empty);
    }
}

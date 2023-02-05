using System;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class SaveLoadObject : MonoBehaviour
{
    public static SaveLoadObject Instance;

    private void Awake()
    {
        Instance = this;
    }

    public void Save(string key, object obj)
    {
        string json = JsonUtility.ToJson(obj);
        PlayerPrefs.SetString(key, json);
        PlayerPrefs.Save();
    }

    public T Load<T>(string key)
    {
        if (PlayerPrefs.HasKey(key))
        {
            string json = PlayerPrefs.GetString(key);
            return JsonUtility.FromJson<T>(json);
        }
        return default(T);
    }
}
using System;
using UnityEngine;

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
        Debug.Log(json);
        PlayerPrefs.SetString(key, json);
        PlayerPrefs.Save();
    }

    public T Load<T>(string key)
    {
        if (PlayerPrefs.HasKey(key))
        {
            string json = PlayerPrefs.GetString(key);
            Debug.Log(json);
            return JsonUtility.FromJson<T>(json);
            
        }
        return default(T);
    }
}
using System;
using System.Transactions;
using UnityEngine;

[Serializable]
public class ItemList<T>
{

    [SerializeField] private T[] Items;
    private T CurrentItem;
    private GameObject CurrentPrefab;
    private Texture CurrentTexture;
    [SerializeField] private GameObject EquipedPrefab;
    [SerializeField] private Texture EquipedTexture;
    private int index = 0;
    
    
    public T GetCurrentItem()
    {
        if (CurrentItem != null)  return CurrentItem;
        return Items[0];
    }

    public void resetIndex()
    {
        index = 0;
    }
    public T GetNext()
    {
        index++;
        if (index >= Items.Length) index = 0;
        CurrentItem = Items[index];
        return CurrentItem;
    }
    public T GetBefore()
    {
        index--;
        if (index < 0) index = Items.Length-1;
        CurrentItem = Items[index];
        return CurrentItem;
    }

    public void SetCurrentPrefab(GameObject prefab)
    {
        CurrentPrefab = prefab;
    }    
    public void SetCurrentTexture(Texture texture)
    {
        CurrentTexture = texture;
    }
    public void SetCurrentItem(T item)
    {
        CurrentItem = item;
    }
    public GameObject GetCurrentPrefab()
    {
        return CurrentPrefab;
    }

    public GameObject GetEquipedPrefab()
    {
        return EquipedPrefab;
    }

    public Texture GetEquipedTexture()
    {
        return EquipedTexture;
    }    
    public void SetEquipedPrefab(GameObject prefab)
    {
       EquipedPrefab = prefab;
    }

    public void SetEquipedTexture(Texture texture)
    {
        EquipedTexture = texture;
    }

    public T GetDefault()
    {
        return Items[0];
    }
    
}


using System;
using System.Net.Mime;
using UnityEditor;
using UnityEngine;
using UnityEngine.SubsystemsImplementation;

public class MarketManagerLogic : MonoBehaviour
{
    private const string saveKey = "MarketSave";
    private const string saveKey2 = "MarketSave2";
    
    [Serializable]
    public class Head
    {
        public bool isBought = false;
        public GameObject item;
        public int itemPrice;
    }
    
    [Serializable]
    public class TextureItem
    {   
        public bool isBought = false;
        public Texture item;
        public int itemPrice; 
    }
    
    [SerializeField] public ItemList<Head> HeadList;
    [SerializeField] public ItemList<TextureItem> TextureList;
    public Transform HeadParent;
    public bool isMarketOn = false;
    public Renderer _Renderer;
    public static MarketManagerLogic Instance { get; private set;}
    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        if (PlayerPrefs.HasKey(saveKey))
        {
            HeadList = SaveLoadObject.Instance.Load<ItemList<Head>>(saveKey);
            TextureList = SaveLoadObject.Instance.Load<ItemList<TextureItem>>(saveKey2); 
            TakeOnEquipedClothes();
        }
    }

    public void NextHead()
    {
        DestroyItems();
        Head current = HeadList.GetNext();
        GameObject currentPrefab = Instantiate(current.item, HeadParent);
        HeadList.SetCurrentPrefab(currentPrefab);
    }
    public void BeforeHead()
    {
        DestroyItems();
        Head current = HeadList.GetBefore();
        GameObject currentPrefab = Instantiate(current.item, HeadParent);
        HeadList.SetCurrentPrefab(currentPrefab);
    }    
    public void NextTexture()
    {
        TextureItem current = TextureList.GetNext();
        _Renderer.materials[0].SetTexture("_MainTex", current.item);
        TextureList.SetCurrentTexture(current.item);
    }
    
    public void BeforeTexture()
    {
        TextureItem current = TextureList.GetBefore();
        _Renderer.materials[0].SetTexture("_MainTex", current.item);
        TextureList.SetCurrentTexture(current.item);
    }
    public int GetSumOfPrizes()
    {
        return TextureList.GetCurrentItem().itemPrice + HeadList.GetCurrentItem().itemPrice;
    }

    public void DestroyItems()
    {
        if (HeadList.GetCurrentItem() != null)
        {
            GameObject item = HeadList.GetCurrentPrefab();
            Destroy(item);
        }

    }

    public void ResetIndexes()
    {
        HeadList.resetIndex();
        TextureList.resetIndex();
    }
    public void TryBuyItems()
    {
        int prize = GetSumOfPrizes();
        if (GemManager.Instance.GetGem() >= prize)
        {
            GemManager.Instance.DecreaseGem(prize);
            HeadList.GetCurrentItem().isBought = true;
            TextureList.GetCurrentItem().isBought = true;
        }
    }
    public bool IsHeadEquipable()
    {
        //buraya diğer kozmetikler de gelecek
        if (HeadList.GetCurrentItem().isBought) return true;
        return false;
    } 
    public bool IsTextureEquipable()
    {
        //buraya diğer kozmetikler de gelecek
        if (TextureList.GetCurrentItem().isBought) return true;
        return false;
    }

    public void TakeOnEquipedClothes()
    {
        if (HeadList.GetCurrentPrefab() != null) Destroy(HeadList.GetCurrentPrefab());
        GameObject prefab = Instantiate(HeadList.GetEquipedPrefab(), HeadParent);
        HeadList.SetCurrentPrefab(prefab);
        _Renderer.materials[0].SetTexture("_MainTex", TextureList.GetEquipedTexture());
        TextureList.SetCurrentTexture(TextureList.GetEquipedTexture());
    }    

    public void SetEquipedClothes()
    {
        HeadList.SetEquipedPrefab(HeadList.GetCurrentItem().item);
        TextureList.SetEquipedTexture(TextureList.GetCurrentItem().item);
        SaveLoadObject.Instance.Save(saveKey, HeadList);
        SaveLoadObject.Instance.Save(saveKey2, TextureList);
    }

    public void DefaultMarket()
    {
        Head head = HeadList.GetDefault();
        TextureItem textureItem = TextureList.GetDefault();
        GameObject prefab = Instantiate(head.item, HeadParent);
        _Renderer.materials[0].SetTexture("_MainTex", textureItem.item);
        TextureList.SetCurrentTexture(textureItem.item);
        TextureList.SetCurrentItem(textureItem);
        HeadList.SetCurrentItem(head);
    }
}

    


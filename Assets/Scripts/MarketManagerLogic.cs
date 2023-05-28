using System;
using UnityEngine;

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
public class MarketManagerLogic : MonoBehaviour
{
    private const string HeadEquiped = "HeadEquiped";
    private const string TextureEquiped = "TextureEquiped";
    
    private const string HeadBought = "HeadBought";
    private const string TextureBought = "TextureBought";
    
    
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
        if (PlayerPrefs.HasKey(HeadEquiped) | PlayerPrefs.HasKey(TextureEquiped) | PlayerPrefs.HasKey(HeadBought) | PlayerPrefs.HasKey(TextureBought))
        {
            HeadList.SetEquipedPrefab(HeadList.GetIndex(PlayerPrefs.GetInt(HeadEquiped, 0)).item);
            TextureList.SetEquipedTexture(TextureList.GetIndex(PlayerPrefs.GetInt(TextureEquiped, 0)).item);
            LoadBoughtData();
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
        _Renderer.sharedMaterials[0].mainTexture = current.item;
        TextureList.SetCurrentTexture(current.item);
    }
    
    public void BeforeTexture()
    {
        TextureItem current = TextureList.GetBefore();
        _Renderer.sharedMaterials[0].mainTexture = current.item;
        TextureList.SetCurrentTexture(current.item);
    }
    public int GetSumOfPrizes()
    {
        int sum = 0;
        if (!IsHeadEquipable()) sum += HeadList.GetCurrentItem().itemPrice;
        if (!IsTextureEquipable()) sum += TextureList.GetCurrentItem().itemPrice;
        return sum;
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
            SaveBoughtData();
            SoundManager.instance.Play("BuySFX");
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
        _Renderer.sharedMaterials[0].mainTexture = TextureList.GetEquipedTexture();
        TextureList.SetCurrentTexture(TextureList.GetEquipedTexture());
    }    

    public void SetEquipedClothes()
    {
        HeadList.SetEquipedPrefab(HeadList.GetCurrentItem().item);
        TextureList.SetEquipedTexture(TextureList.GetCurrentItem().item);
        
        PlayerPrefs.SetInt(HeadEquiped, HeadList.GetCurrentItemIndex());
        PlayerPrefs.SetInt(TextureEquiped, TextureList.GetCurrentItemIndex());
        
        //SaveLoadObject.Instance.Save(saveKey, HeadList);
        //SaveLoadObject.Instance.Save(saveKey2, TextureList);
    }

    public void DefaultMarket()
    {
        Head head = HeadList.GetDefault();
        TextureItem textureItem = TextureList.GetDefault();
        GameObject prefab = Instantiate(head.item, HeadParent);
        _Renderer.sharedMaterials[0].mainTexture = textureItem.item;
        TextureList.SetCurrentTexture(textureItem.item);
        TextureList.SetCurrentItem(textureItem);
        HeadList.SetCurrentItem(head);
    }

    public bool EquipedCheck()
    {
        if (HeadList.GetEquipedPrefab() == HeadList.GetCurrentItem().item &&
            TextureList.GetEquipedTexture() == TextureList.GetCurrentItem().item) return true;
        return false;
    }

    public void SaveBoughtData()
    {
        Head[] heads = HeadList.GetItems();
        TextureItem[] textures = TextureList.GetItems();

        string headBoughtList = "";
        string TextureBoughtList = "";
        
        for (int i = 0; i < heads.Length; i++)
        {
            if (heads[i].isBought) headBoughtList += "Yes ";
            else headBoughtList += "No ";
        }       
        for (int i = 0; i < textures.Length; i++)
        {
            if (textures[i].isBought) TextureBoughtList += "Yes ";
            else TextureBoughtList += "No ";
        }
        
        PlayerPrefs.SetString(HeadBought, headBoughtList);
        PlayerPrefs.SetString(TextureBought, TextureBoughtList);
    }

    public void LoadBoughtData()
    {
        if (PlayerPrefs.HasKey(HeadBought))
        {
            var HeadString = PlayerPrefs.GetString(HeadBought);
            var TextureString = PlayerPrefs.GetString(TextureBought);
            
            string[] Headlist = HeadString.Trim().Split(" ");
            string[] Texturelist = TextureString.Trim().Split(" ");

            for (int i = 0; i < Headlist.Length; i++)
            {
                if (Headlist[i] == "Yes") HeadList.GetItems()[i].isBought = true;
                else HeadList.GetItems()[i].isBought = false;
            }      
            for (int i = 0; i < Texturelist.Length; i++)
            {
                if (Texturelist[i] == "Yes") TextureList.GetItems()[i].isBought = true;
                else TextureList.GetItems()[i].isBought = false;
            }  
        }
    }
}

    


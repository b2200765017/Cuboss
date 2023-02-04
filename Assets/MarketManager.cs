using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MarketManager : MonoBehaviour
{
    private const string GEM_COUNT = "GemCount";
    public Equip Equip;
    private bool isMarketOpened = false;
    private int gemCount;
    
    public Head[] HeadList;
    public Textures[] texturesList;
    private Textures currentTexture;
    public Transform HeadArmature;
    private int HeadIndex = 0;
    private int TextureIndex = 0;
    private int prizeSum = 0;
    private GameObject head;
    private Head headItem;
    [SerializeField] private Renderer _renderer;

    public TextMeshProUGUI prizeTextUI;
    public TextMeshProUGUI GemUI;
    public Image HeadLock;
    public Image TextureLock;
    
    public Image marketImage;
    public Image BackToPlayImage;

    public GameObject PlayButton;
    public GameObject EquipButton;
    public GameObject BuyButton;
    public GameObject MarketCanvas;

    private void Start()
    {
        TakeClothes();
        gemCount = PlayerPrefs.GetInt(GEM_COUNT, 350);
        GemUI.text = gemCount.ToString();
        currentTexture = texturesList[0];
    }

    public void HeadRightFunction()
    {
        Destroy(head);
        HeadIndex++;
        if (HeadIndex >= HeadList.Length)HeadIndex = 0;
        var Item = HeadList[HeadIndex];
        head = Instantiate(Item.item, HeadArmature, false);
        headItem = Item;
        GetTotalPrize();
        prizeTextUI.SetText(prizeSum.ToString());
        if (!headItem.isBought) HeadLock.enabled = true;
        else HeadLock.enabled = false;
        EquipCheck();
    }
    public void HeadLeftFunction()
    {
        Destroy(head);
        HeadIndex--;
        if (HeadIndex < 0) HeadIndex = HeadList.Length - 1;
        var Item = HeadList[HeadIndex];
        head = Instantiate(Item.item, HeadArmature, false);
        headItem = Item;
        GetTotalPrize();
        prizeTextUI.SetText(prizeSum.ToString());
        if (!headItem.isBought) HeadLock.enabled = true;
        else HeadLock.enabled = false;
        EquipCheck();
    }
    public void textureRightFunction()
    {
        TextureIndex++;
        if (TextureIndex >= texturesList.Length)TextureIndex = 0;
        var Item = texturesList[TextureIndex];
        _renderer.materials[0].SetTexture("_MainTex", Item.item);
        currentTexture = Item;
        GetTotalPrize();
        prizeTextUI.SetText(prizeSum.ToString());
        if (!currentTexture.isBought) TextureLock.enabled = true;
        else TextureLock.enabled = false;
        EquipCheck();
    }
    public void textureLeftFunction()
    {
        TextureIndex--;
        if (TextureIndex < 0) HeadIndex = TextureIndex = 0;;
        var Item = texturesList[TextureIndex];
        _renderer.materials[0].SetTexture("_MainTex", Item.item);
        currentTexture = Item;
        GetTotalPrize();
        prizeTextUI.SetText(prizeSum.ToString());
        if (!currentTexture.isBought) TextureLock.enabled = true;
        else TextureLock.enabled = false;
        EquipCheck();
    }

    public void BuyItems()
    {
        Debug.Log(gemCount + " " + prizeSum);
        if (gemCount >= prizeSum)
        {
            gemCount -= prizeSum;
            headItem.isBought = true;
            HeadLock.enabled = false;
            TextureLock.enabled = false;
            currentTexture.isBought = true;
            prizeSum = 0;
            prizeTextUI.SetText(prizeSum.ToString());
            EquipCheck();
            PlayerPrefs.SetInt(GEM_COUNT, gemCount);
            PlayerPrefs.Save();
            GemUI.text = gemCount.ToString();
        }
        else
        {
            Debug.Log("you cant buy this item");
        }

    }
    
    public void MarketEnterExit()
    {
        if (!isMarketOpened)
        {
            MarketCanvas.SetActive(true);
            BackToPlayImage.enabled = true;
            PlayButton.SetActive(false);
            marketImage.enabled = false;
            TakeOffClothes();
            headItem = HeadList[0];
        }
        else
        {
            marketImage.enabled = true;
            PlayButton.SetActive(true);

            MarketCanvas.SetActive(false);
            BackToPlayImage.enabled = false;
            HeadLock.enabled = false;
            //if (headItem != null)  
            TakeClothes();
        }

        isMarketOpened = !isMarketOpened;

    }

    public void EquipButtonPressed()
    {
        Equip.head = headItem;
        Equip.Texture = currentTexture.item;
    }
    public void EquipCheck()
    {
        if (headItem.isBought && currentTexture.isBought)
        {
            BuyButton.SetActive(false);
            EquipButton.SetActive(true);
        }
        else
        {
            BuyButton.SetActive(true);
            EquipButton.SetActive(false);
        }
        // diğer konseptlerin de satın alınmış olması lazım
        
    }

    private void TakeClothes()
    {
        if(head != null )Destroy(head);
        if(Equip.head != null)
        {
            var heads = Equip.head;
            head = Instantiate(heads.item, HeadArmature, false);
        }

        if (Equip.Texture != null)
        {
            var texture = Equip.Texture;
            _renderer.materials[0].SetTexture("_MainTex", texture);
        }
    }
    private void TakeOffClothes()
    {
        if(head != null )Destroy(head);
    }

    private void GetTotalPrize()
    {
        prizeSum = 0;
        if (!currentTexture.isBought) prizeSum += currentTexture.itemPrice;
        if (!headItem.isBought) prizeSum += headItem.itemPrice;
    }

}


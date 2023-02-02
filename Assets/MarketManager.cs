using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MarketManager : MonoBehaviour
{
    public Equip Equip;
    private bool isMarketOpened = false;
    
    public Head[] HeadList;
    public Transform HeadArmature;
    private int HeadIndex = 0;
    private int prizeSum = 0;
    private GameObject head;
    private Head headItem;

    public TextMeshProUGUI prizeTextUI;
    public Image HeadLock;
    
    public Image marketImage;
    public Image BackToPlayImage;

    public GameObject PlayButton;
    public GameObject EquipButton;
    public GameObject BuyButton;
    public GameObject MarketCanvas;

    private void Start()
    {
        TakeClothes();
    }

    public void HeadRightFunction()
    {
        Destroy(head);
        prizeSum = 0;
        HeadIndex++;
        if (HeadIndex >= HeadList.Length)HeadIndex = 0;
        var Item = HeadList[HeadIndex];
        head = Instantiate(Item.item, HeadArmature, false);
        if (!Item.isBought) prizeSum += Item.itemPrice;
        prizeTextUI.SetText(prizeSum.ToString());
        headItem = Item;
        if (!headItem.isBought) HeadLock.enabled = true;
        else HeadLock.enabled = false;
        EquipCheck();
    }
    public void HeadLeftFunction()
    {
        Destroy(head);
        prizeSum = 0;
        HeadIndex--;
        if (HeadIndex < 0) HeadIndex = HeadList.Length - 1;
        var Item = HeadList[HeadIndex];
        head = Instantiate(Item.item, HeadArmature, false);
        if (!Item.isBought) prizeSum += Item.itemPrice;
        prizeTextUI.SetText(prizeSum.ToString());
        headItem = Item;
        if (!headItem.isBought) HeadLock.enabled = true;
        else HeadLock.enabled = false;
        EquipCheck();
    }

    public void BuyItems()
    {
        headItem.isBought = true;
        HeadLock.enabled = false;
        prizeSum = 0;
        prizeTextUI.SetText(prizeSum.ToString());
        EquipCheck();
    }
    
    public void MarketEnterExit()
    {
        if (!isMarketOpened)
        {
            MarketCanvas.SetActive(true);
            BackToPlayImage.enabled = true;
            PlayButton.SetActive(false);
            marketImage.enabled = false;
        }
        else
        {
            marketImage.enabled = true;
            PlayButton.SetActive(true);

            MarketCanvas.SetActive(false);
            BackToPlayImage.enabled = false;
            
            //if (headItem != null)  
            TakeClothes();
        }

        isMarketOpened = !isMarketOpened;

    }

    public void EquipButtonPressed()
    {
        Equip.head = headItem;
    }
    public void EquipCheck()
    {
        if (headItem.isBought)
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
    }

}

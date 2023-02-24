using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class MarketManagerUI : MonoBehaviour
{

    [SerializeField] private Button headRightButton;
    [SerializeField] private Button headLeftButton;
    [SerializeField] private Button textureRightButton;
    [SerializeField] private Button textureLeftButton;
    [SerializeField] private GameObject marketButtonGO;
    [SerializeField] private GameObject marketBackButtonGO;
    [SerializeField] private GameObject PlayButton;
    [SerializeField] private GameObject MarketPanel;
    [SerializeField] private GameObject BuyButtonGO;
    [SerializeField] private GameObject EquipButtonGO;
    [SerializeField] private TextMeshProUGUI GemText;
    [SerializeField] private TextMeshProUGUI PrizeText;
    [SerializeField] private Image headLock;
    [SerializeField] private Image textureLock;


    private Button marketButton;
    private Button marketBackButton;
    private Button buyButton;
    private Button equipButton;
    private void Awake()
    {
        marketButton = marketButtonGO.GetComponent<Button>();
        marketBackButton = marketBackButtonGO.GetComponent<Button>();
        buyButton = BuyButtonGO.GetComponent<Button>();
        equipButton = EquipButtonGO.GetComponent<Button>();
        
        headRightButton.onClick.AddListener(() =>
        {
            // Right button clicked
            MarketManagerLogic.Instance.NextHead();
            int sumOfPrizes = MarketManagerLogic.Instance.GetSumOfPrizes();
            SetPrize(sumOfPrizes);
            ChangeBuyEquipButton();
            SoundManager.instance.Play("Click");
        });
        headLeftButton.onClick.AddListener(() =>
        {
            // Left button clicked
            MarketManagerLogic.Instance.BeforeHead();
            int sumOfPrizes = MarketManagerLogic.Instance.GetSumOfPrizes();
            SetPrize(sumOfPrizes);
            ChangeBuyEquipButton();
            SoundManager.instance.Play("Click");
        });        
        textureRightButton.onClick.AddListener(() =>
        {
            // Right button clicked
            MarketManagerLogic.Instance.NextTexture();
            int sumOfPrizes = MarketManagerLogic.Instance.GetSumOfPrizes();
            SetPrize(sumOfPrizes);
            ChangeBuyEquipButton();
            SoundManager.instance.Play("Click");
        });
        textureLeftButton.onClick.AddListener(() =>
        {
            // Left button clicked
            MarketManagerLogic.Instance.BeforeTexture();
            int sumOfPrizes = MarketManagerLogic.Instance.GetSumOfPrizes();
            SetPrize(sumOfPrizes);
            ChangeBuyEquipButton();
            SoundManager.instance.Play("Click");
        });
        marketButton.onClick.AddListener(() =>
        {
            MarketManagerLogic.Instance.DestroyItems();
            ShowPanel();
            PlayButton.SetActive(false);
            ChangeMarketButton();
            MarketManagerLogic.Instance.ResetIndexes();
            int sumOfPrizes = MarketManagerLogic.Instance.GetSumOfPrizes();
            MarketManagerLogic.Instance.DefaultMarket();
            SetPrize(sumOfPrizes);
            SoundManager.instance.Play("Click");
            ChangeBuyEquipButton();
        });
        marketBackButton.onClick.AddListener(() =>
        {
            HidePanel();
            PlayButton.SetActive(true);
            MarketManagerLogic.Instance.TakeOnEquipedClothes();
            SoundManager.instance.Play("Click");
            ChangeMarketButton();
        });
        buyButton.onClick.AddListener(() =>
        {
            // When it clicks to buy
            MarketManagerLogic.Instance.TryBuyItems();
            ChangeBuyEquipButton();
        });
        equipButton.onClick.AddListener(() =>
        {
            // When it clicks to equip the items
            MarketManagerLogic.Instance.SetEquipedClothes();
            // Disable the equip button
            SoundManager.instance.Play("Click");
            equipButton.gameObject.SetActive(false);
        });
        
        GemManager.Instance.OnGemChanged += GemManager_OnGemChanged;
    }

    private void GemManager_OnGemChanged(object sender, EventArgs e)
    {
        int gemAmount = GemManager.Instance.GetGem();
        GemText.text = gemAmount.ToString();
    }


    private void ShowPanel()
    {
        MarketPanel.SetActive(true);
    }

    private void HidePanel()
    {
        MarketPanel.SetActive(false);
    }

    private void ChangeMarketButton()
    {
        marketButtonGO.SetActive(!marketButtonGO.activeSelf);
        marketBackButtonGO.SetActive(!marketBackButtonGO.activeSelf);
    }

    private void ChangeBuyEquipButton()
    {
        if (MarketManagerLogic.Instance.IsHeadEquipable() && MarketManagerLogic.Instance.IsTextureEquipable())
        {
            PrizeText.enabled = false;
            BuyButtonGO.SetActive(false);
            if (!MarketManagerLogic.Instance.EquipedCheck()) EquipButtonGO.SetActive(true);
            else  EquipButtonGO.SetActive(false);
            headLock.enabled = false;
            textureLock.enabled = false;
            return;
        }
        headLock.enabled = true;
        textureLock.enabled = true;
        if (MarketManagerLogic.Instance.IsHeadEquipable()) headLock.enabled = false;
        if (MarketManagerLogic.Instance.IsTextureEquipable()) textureLock.enabled = false;
        PrizeText.enabled = true;
        BuyButtonGO.SetActive(true);
        EquipButtonGO.SetActive(false);
    }

    private void SetPrize(int prize)
    {
        PrizeText.text = prize + " Gem";
    }
}

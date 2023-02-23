using UnityEngine;

public class CosmeticEquipper : MonoBehaviour
{
    private const string SAVEKEY = "MarketSave";
    private const string SAVEKEY2 = "MarketSave2";
    
    [SerializeField] public ItemList<Head> HeadList;
    [SerializeField] public ItemList<TextureItem> TextureList;
    [SerializeField] public Renderer _Renderer;
    [SerializeField] public Transform HeadParent;

    void Start()
    {
        
        if (PlayerPrefs.HasKey(SAVEKEY))
        {
            HeadList = SaveLoadObject.Instance.Load<ItemList<Head>>(SAVEKEY);
            TextureList = SaveLoadObject.Instance.Load<ItemList<TextureItem>>(SAVEKEY2); 
            TakeOnEquipedClothes();
        }            
    }
    public void TakeOnEquipedClothes()
    {
        if (HeadList.GetCurrentPrefab() != null) Destroy(HeadList.GetCurrentPrefab());
        GameObject prefab = Instantiate(HeadList.GetEquipedPrefab(), HeadParent);
        HeadList.SetCurrentPrefab(prefab);
        _Renderer.materials[0].SetTexture("_MainTex", TextureList.GetEquipedTexture());
        TextureList.SetCurrentTexture(TextureList.GetEquipedTexture());
    }    
    
}

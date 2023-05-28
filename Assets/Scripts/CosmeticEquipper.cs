using UnityEngine;

public class CosmeticEquipper : MonoBehaviour
{
    private const string HeadEquiped = "HeadEquiped";
    private const string TextureEquiped = "TextureEquiped";

    [SerializeField] public ItemList<Head> HeadList;
    [SerializeField] public ItemList<TextureItem> TextureList;
    [SerializeField] public Renderer _Renderer;
    [SerializeField] public Transform HeadParent;

    void Start()
    {
        
        if (PlayerPrefs.HasKey(HeadEquiped) | PlayerPrefs.HasKey(TextureEquiped))
        {
            HeadList.SetEquipedPrefab(HeadList.GetIndex(PlayerPrefs.GetInt(HeadEquiped, 0)).item);
            TextureList.SetEquipedTexture(TextureList.GetIndex(PlayerPrefs.GetInt(TextureEquiped, 0)).item);
            TakeOnEquipedClothes();
        }            
    }
    public void TakeOnEquipedClothes()
    {
        if (HeadList.GetCurrentPrefab() != null) Destroy(HeadList.GetCurrentPrefab());
        GameObject prefab = Instantiate(HeadList.GetEquipedPrefab(), HeadParent);
        HeadList.SetCurrentPrefab(prefab);
        _Renderer.sharedMaterials[0].mainTexture = TextureList.GetEquipedTexture();
        TextureList.SetCurrentTexture(TextureList.GetEquipedTexture());
    }    
    
}

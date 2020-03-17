using UnityEngine;
public class ShopLogic : MonoBehaviour
{
    private DoTweenAnimations tweenAnimation;
    private SaveSystem saveSystem;
    public GameObject mainCam, shopButton, holdToFlyPanel, gameNameIcon, shopBackPackShower,PlayerBackPack,buttonAdBuy,buttonCoinBuy;
    public Sprite shopSprite,backSprite;
    [SerializeField] private bool isShopOpenedClosed;
    [SerializeField] private int rotationSpeed;
    [SerializeField] private float angle;
    public AudioSource buyAudioSource;
    public Mesh[] backPacks;

    private void Awake()
    {
        tweenAnimation = GetComponent<DoTweenAnimations>();
        saveSystem = GetComponent<SaveSystem>();
    }
    private void Start()
    {
        isShopOpenedClosed = true;
        PlayerBackPack.GetComponent<SkinnedMeshRenderer>().sharedMesh = backPacks[saveSystem.localButtonCounter];
        shopBackPackShower.GetComponent<MeshFilter>().mesh = backPacks[saveSystem.localButtonCounter];
    }
    public void ShopOpener()
    {
        isShopOpenedClosed = !isShopOpenedClosed;
        if (saveSystem.localIsBackPackBuyed[0] == true)
            buttonAdBuy.SetActive(false);

        if (isShopOpenedClosed == false)
        {
            holdToFlyPanel.SetActive(false);
            gameNameIcon.SetActive(false);
        }
        else
        {
            holdToFlyPanel.SetActive(true);
            gameNameIcon.SetActive(true);
        }
        tweenAnimation.OpenCloseShop(mainCam, isShopOpenedClosed, rotationSpeed, shopButton, shopSprite, backSprite, angle);
    } 
    public void NextBackPack() 
    {
        saveSystem.localButtonCounter++;
        if (saveSystem.localButtonCounter >= backPacks.Length)
            saveSystem.localButtonCounter = backPacks.Length - 1;

        if (saveSystem.localButtonCounter >= 4)
        {
            buttonAdBuy.SetActive(false);
            buttonCoinBuy.SetActive(true);
        }

        if (saveSystem.localIsBackPackBuyed[saveSystem.localButtonCounter] == true)
        {
            buttonAdBuy.SetActive(false);
            buttonCoinBuy.SetActive(false);
        }
        else
            buttonAdBuy.SetActive(true);

        WearShopBackPack(saveSystem.localButtonCounter);
    }

    public void PreviousBackPack() 
    {
        saveSystem.localButtonCounter--;
        if (saveSystem.localButtonCounter < 0)
            saveSystem.localButtonCounter = 0;

        if (saveSystem.localButtonCounter <= 4)
        {
            buttonAdBuy.SetActive(true);
            buttonCoinBuy.SetActive(false);
        }
        if (saveSystem.localIsBackPackBuyed[saveSystem.localButtonCounter] == true)
            buttonAdBuy.SetActive(false);
        else
            buttonAdBuy.SetActive(true);

        WearShopBackPack(saveSystem.localButtonCounter);
    }
    public void WearShopBackPack(int counter)
    {
        shopBackPackShower.GetComponent<MeshFilter>().mesh = backPacks[counter];
    }
    public void EquipBackPack()
    {
        PlayerBackPack.GetComponent<SkinnedMeshRenderer>().sharedMesh = backPacks[saveSystem.localButtonCounter];
        saveSystem.SaveShopData();
    }
    public void BuyBackPack()
    {
        saveSystem.localIsBackPackBuyed[saveSystem.localButtonCounter] = true;
        buttonAdBuy.SetActive(false);
        buyAudioSource.Play();
        saveSystem.SaveShopData();
    }
    public void BuyBackPackWithCoin(int amount)
    {
        if (saveSystem.localCoin >= amount)
        {
            saveSystem.localCoin -= amount;
            saveSystem.localIsBackPackBuyed[saveSystem.localButtonCounter] = true;
            buttonCoinBuy.SetActive(false);
            buyAudioSource.Play();
            saveSystem.SaveShopData();
            saveSystem.SaveCoinData();
        }
        else
            return;
    }
}

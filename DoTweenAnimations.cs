using UnityEngine;
using DG.Tweening;

public class DoTweenAnimations : MonoBehaviour
{
    public GameObject panelHoldToFly;
    private void Start()
    {
        HoldToFlyPanelLoop();
    }
    public void OpenCloseShop(GameObject camera,bool switched, int speed,GameObject shopButton, Sprite shopSprite, Sprite backSprite, float angle)
    {
        if (switched == false)
        {
            shopButton.GetComponent<SVGImage>().sprite = backSprite;
            camera.transform.DORotate(new Vector3(35, angle, 0), speed);
        }
        if (switched == true)
        {
            shopButton.GetComponent<SVGImage>().sprite = shopSprite;
            camera.transform.DORotate(new Vector3(35, -40, 0), speed);
        }
    }
    public void HoldToFlyPanelLoop()
    {
        panelHoldToFly.transform.DOScale(new Vector2(1.1f, 1.1f), .8f).SetLoops(-1, LoopType.Yoyo);
    }
    public void ShardCatched(GameObject shardIcon)
    {
        shardIcon.transform.DOScale(new Vector2(1.1f, 1.1f), .3f).SetLoops(2, LoopType.Yoyo);
    }
}

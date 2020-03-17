using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
public class PlayerColliderLogic : MonoBehaviour
{
    private MovementLogic movementLogic;
    public SoundManager soundManager;
    public MusicManager musicManager;
    public DoTweenAnimations doTweenAnimations;
    private Animator movementAnimator;
    public UnityEvent loseEvent, winEvent;
    public SaveSystem saveSystem;
    public GameObject shardIcon;
    public Text coinText;
    private void Awake()
    {
        movementLogic = GetComponent<MovementLogic>();
        movementAnimator = GetComponent<Animator>();
    }
    private void Start()
    {
        coinText.text = "" + saveSystem.localCoin;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            movementLogic.movementSpeed = 0;
            loseEvent.Invoke();
        }
        if (collision.gameObject.CompareTag("Finish"))
        {
            winEvent.Invoke();
            saveSystem.SaveLvlData();
            saveSystem.SaveCoinData();
        }
        if (collision.gameObject.CompareTag("Ground"))
        {
            movementAnimator.SetBool("isLanded", true);
            if (movementLogic.movementSpeed > 0)
                soundManager.PlayWalkSound();

        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            movementAnimator.SetBool("isLanded", false);
            soundManager.StopWalkSound();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Shard"))
        {
            Destroy(other.gameObject);
            doTweenAnimations.ShardCatched(shardIcon);
            saveSystem.localCoin += 5;
            soundManager.PlayCollectedCoin();
            coinText.text = "" + saveSystem.localCoin;
        }
        if (other.gameObject.CompareTag("DeathZone"))
        {
            gameObject.SetActive(false);
            loseEvent.Invoke();
        }
    }

}

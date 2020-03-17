using UnityEngine;
using UnityEngine.UI;
public class MovementLogic : MonoBehaviour
{
    private Rigidbody rb;
    private Animator movementAnimator;
    public float movementSpeed, flyingSpeed;
    [SerializeField] private float fuelDeCrement;
    [SerializeField] private bool isFlying;
    public Slider fuelSlider;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        movementAnimator = GetComponent<Animator>();
    }
    private void Update()
    {
        transform.Translate(Vector3.forward * movementSpeed * Time.deltaTime);
        if (isFlying == true && fuelSlider.value != 1)
        {
            rb.velocity = Vector3.up * flyingSpeed;
            fuelSlider.value += fuelDeCrement * Time.deltaTime;
        }

    }
    public void ChangeSpeed(int amount)
    {
        movementSpeed = amount;
        movementAnimator.SetBool("isGameStarted", true);
    }
    public void Fly()
    {
        isFlying = !isFlying;
        if (isFlying == true)
            movementAnimator.SetBool("isFlying", true);
        else
            movementAnimator.SetBool("isFlying", false);
    }
}

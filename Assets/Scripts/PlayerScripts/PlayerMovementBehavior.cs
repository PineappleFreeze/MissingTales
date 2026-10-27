using UnityEngine;

public class PlayerMovementBehavior : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] private float currentSpeed;
    [SerializeField] private float walkSpeed = 5f;
    [SerializeField] private float runSpeed = 8f;
    [SerializeField] private bool isPressed;
    private float moveHorizontal;
    private float moveVertical;
    private Vector3 moveDirection;

    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip walkSound;
    [SerializeField] private AudioClip runSound;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
        isPressed = false;
    }
    void Update()
    {
        moveHorizontal = Input.GetAxis("Horizontal");
        moveVertical = Input.GetAxis("Vertical");

        moveDirection = new Vector3(moveHorizontal, 0f, moveVertical).normalized;

        if(Input.GetKey(KeyCode.LeftShift))
        {
            isPressed = true;
        }
        else
        {
            isPressed = false;
        }

        if(isPressed)
        {
            currentSpeed = runSpeed;
            audioSource.Play();
        }
        else
        {
            currentSpeed = walkSpeed;
        }
    }
    void FixedUpdate()
    {
        Vector3 targetVelocity = moveDirection * currentSpeed;
        targetVelocity.y = rb.linearVelocity.y;
        rb.linearVelocity = targetVelocity;
    }
}

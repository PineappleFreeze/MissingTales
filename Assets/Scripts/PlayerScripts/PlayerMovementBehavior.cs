using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovementBehavior : MonoBehaviour
{
    [SerializeField] private float currentSpeed;
    [SerializeField] private float walkSpeed = 5f;
    [SerializeField] private float runSpeed = 8f;
    [SerializeField] private float rotationSpeed = 10f;
    [SerializeField] private InputActionReference moveAction;

    private Rigidbody rb;
    private Vector3 moveDirection;
    private Vector2 moveInput;
    private bool isMove;

    [SerializeField] private Animator playerAnimator;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        playerAnimator = GetComponent<Animator>();
    }
    void OnEnable()
    {
        moveAction.action.Enable();
    }
    
    void OnDisable()
    {
        moveAction.action.Disable();
    }

    private Quaternion smoothRotation;
    void Update()
    {
        moveInput = moveAction.action.ReadValue<Vector2>();
        moveDirection = new Vector3(moveInput.x, 0f, moveInput.y).normalized;
        if (moveDirection.sqrMagnitude > 0.01f)
        {
            Quaternion targetRotation = Quaternion.LookRotation(moveDirection, Vector3.up);
            smoothRotation = Quaternion.Lerp(rb.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
        else
        {
            rb.MoveRotation(smoothRotation);
        }

        if(Input.GetKey(KeyCode.LeftShift))
        {
            Run();
        }
        else
        {
            Walk();
        }
        MoveAnimacion();
        
        
    }
    private void MoveAnimacion()
    {
        if(moveInput.sqrMagnitude > 0.01f)
        {
            playerAnimator.SetBool("IsWalking",true);
        }
        else
        {
            playerAnimator.SetBool("IsWalking",false);
        }

    }

    void FixedUpdate()
    {
        
        if(moveDirection.sqrMagnitude > 0.01f)
        {
            rb.MoveRotation(smoothRotation);
        }
        Vector3 relativeMovement = moveDirection * currentSpeed;
        rb.MovePosition(rb.position + relativeMovement * Time.fixedDeltaTime);
    }

    void Walk()
    {
        currentSpeed = walkSpeed;
    }
    void Run()
    {
        currentSpeed = runSpeed;
    }
}

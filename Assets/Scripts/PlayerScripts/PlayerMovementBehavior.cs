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

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
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
        if(Input.GetKey(KeyCode.LeftShift))
        {
            Run();
        }
        else
        {
            Walk();
        }
        if (moveDirection.sqrMagnitude > 0.01f)
        {
            Quaternion targetRotation = Quaternion.LookRotation(moveDirection, Vector3.up);
            Quaternion smoothRotation = Quaternion.Lerp(rb.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
        rb.MoveRotation(smoothRotation);
    }
    void FixedUpdate()
    {
        
        Vector3 relativeMovement = transform.rotation * moveDirection;
        rb.MovePosition(transform.position + relativeMovement * currentSpeed * Time.fixedDeltaTime);
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

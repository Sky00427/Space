using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    public float speed = 5;

    [SerializeField] private InputActionReference moveAction;

    private Rigidbody2D playerRigidbody;
    private Vector2 moveInput;

    void Awake()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
    }

    void OnEnable()
    {
        moveAction.action.Enable();
    }

    void OnDisable()
    {
        moveAction.action.Disable();

        if (playerRigidbody != null)
        {
            playerRigidbody.linearVelocity = Vector2.zero;
        }
    }

    void Update()
    {
        moveInput = moveAction.action.ReadValue<Vector2>();
    }

    void FixedUpdate()
    {
        playerRigidbody.linearVelocity = moveInput.normalized * speed;
    }
}
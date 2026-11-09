using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerFire : MonoBehaviour
{
    public Transform firePos;
    public GameObject bullet;
    public AudioSource audioSource;

    [SerializeField] private InputActionReference fireAction;

    void OnEnable()
    {
        fireAction.action.performed += OnFirePerformed;

        fireAction.action.Enable();
    }

    void OnDisable()
    {
        fireAction.action.performed -=
            OnFirePerformed;

        fireAction.action.Disable();
    }

    void OnFirePerformed(
        InputAction.CallbackContext context
    )
    {
        Fire();
    }

    public void Fire()
    {
        audioSource.Play();

        Instantiate(
            bullet,
            firePos.position,
            Quaternion.identity
        );
    }
}
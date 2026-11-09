using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class RockMovement : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField, Min(0.1f)]
    private float moveSpeed = 4f;

    private Rigidbody2D rockRigidbody;
    private Vector2 moveDirection;

    void Awake()
    {
        rockRigidbody =
            GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        GameObject playerObject =
            GameObject.FindGameObjectWithTag(
                "Player"
            );

        if (playerObject == null)
        {
            Debug.LogWarning(
                "RockMovement 找不到 Player Tag 物件，改為向下移動。"
            );

            moveDirection = Vector2.down;
            return;
        }

        moveDirection =
            (
                playerObject.transform.position -
                transform.position
            ).normalized;
    }

    void FixedUpdate()
    {
        rockRigidbody.linearVelocity =
            moveDirection * moveSpeed;
    }
}
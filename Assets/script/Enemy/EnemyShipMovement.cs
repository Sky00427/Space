using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyShipMovement : MonoBehaviour
{
    [Header("Entry Movement")]
    [SerializeField, Min(0.1f)]
    private float moveSpeed = 2f;

    [SerializeField]
    private float stopY = 5.5f;

    private Rigidbody2D enemyRigidbody;

    public bool HasReachedStopPosition
    {
        get;
        private set;
    }

    void Awake()
    {
        enemyRigidbody =
            GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (HasReachedStopPosition)
        {
            enemyRigidbody.linearVelocity =
                Vector2.zero;

            return;
        }

        Vector2 targetPosition = new Vector2(
            enemyRigidbody.position.x,
            stopY
        );

        Vector2 nextPosition =
            Vector2.MoveTowards(
                enemyRigidbody.position,
                targetPosition,
                moveSpeed * Time.fixedDeltaTime
            );

        enemyRigidbody.MovePosition(nextPosition);

        if (
            Vector2.Distance(
                nextPosition,
                targetPosition
            ) <= 0.01f
        )
        {
            HasReachedStopPosition = true;

            enemyRigidbody.linearVelocity =
                Vector2.zero;
        }
    }
}
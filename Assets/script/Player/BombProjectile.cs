using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class BombProjectile : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField, Min(0.1f)]
    private float moveSpeed = 22f;

    [SerializeField, Min(0.1f)]
    private float lifetime = 5f;

    [Header("Explosion")]
    [SerializeField]
    private GameObject explosionPrefab;

    private Rigidbody2D bombRigidbody;
    private bool hasExploded;

    void Awake()
    {
        bombRigidbody = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        bombRigidbody.linearVelocity =
            (Vector2)transform.up * moveSpeed;

        Destroy(gameObject, lifetime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (hasExploded)
        {
            return;
        }

        EnemyHealth enemyHealth =
            other.GetComponentInParent<EnemyHealth>();

        if (enemyHealth == null)
        {
            return;
        }

        Explode();
    }

    void Explode()
    {
        hasExploded = true;

        Instantiate(
            explosionPrefab,
            transform.position,
            Quaternion.identity
        );

        Destroy(gameObject);
    }
}
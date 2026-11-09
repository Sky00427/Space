using UnityEngine;

public class EnemyFire : MonoBehaviour
{
    public GameObject bullet;

    public float interval = 2f;

    [SerializeField, Min(0.1f)]
    private float projectileSpeed = 8f;

    private Transform playerTarget;
    private EnemyShipMovement enemyMovement;

    void Start()
    {
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");

        if (playerObject != null)
        {
            playerTarget = playerObject.transform;
        }
        else
        {
            Debug.LogWarning("EnemyFire 找不到 Player Tag 物件。");
        }

        enemyMovement = GetComponentInParent<EnemyShipMovement>();

        InvokeRepeating(nameof(Fire), interval, interval);
    }

    void OnDisable()
    {
        CancelInvoke();
    }

    void Fire()
    {
        if (playerTarget == null) return;

        if (enemyMovement != null && !enemyMovement.HasReachedStopPosition)
        {
            return;
        }

        Vector2 direction = (playerTarget.position - transform.position).normalized;

        GameObject projectile = Instantiate(
            bullet,
            transform.position,
            Quaternion.identity
        );
        projectile.transform.up = direction;

        Rigidbody2D projectileRigidbody = projectile.GetComponent<Rigidbody2D>();

        if (projectileRigidbody == null)
        {
            Debug.LogError("Enemy Projectile 沒有 Rigidbody2D。");

            Destroy(projectile);
            return;
        }

        projectileRigidbody.linearVelocity = direction * projectileSpeed;
    }
}
using UnityEngine;

public class BulletDamage : MonoBehaviour
{
    [Header("Damage")]
    public int damage = 1;
    [Header("Effect")]
    [SerializeField]
    private GameObject hitEffectPrefab;

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.TryGetComponent(out EnemyHealth enemyHealth))
        {
            Vector2 hitPosition =
                coll.contactCount > 0
                    ? coll.GetContact(0).point
                    : transform.position;

            Instantiate(
                hitEffectPrefab,
                hitPosition,
                Quaternion.identity
            );

            enemyHealth.TakeDamage(damage);
            Destroy(gameObject);
        }
        else
        {
            if (coll.gameObject.CompareTag("wall"))
            {
                Destroy(gameObject);
            }
        }
    }
}
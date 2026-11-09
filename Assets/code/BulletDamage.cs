using UnityEngine;

public class BulletDamage : MonoBehaviour
{
    [Header("Damage")]
    public int damage = 1;

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag("Enemy"))
        {
            EnemyHealth enemyHealth =
                coll.gameObject.GetComponent<EnemyHealth>();

            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(damage);
            }

            Destroy(gameObject);
        }

        if (coll.gameObject.CompareTag("wall"))
        {
            Destroy(gameObject);
        }
    }
}
using UnityEngine;

public class BulletDamage : MonoBehaviour
{
    [Header("Damage")]
    public int damage = 1;

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.TryGetComponent(out EnemyHealth enemyHealth))
        {
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
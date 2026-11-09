using UnityEngine;

public class EnemyProjectileDamage : MonoBehaviour
{
    [Header("Damage")]
    public int damage = 1;

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.TryGetComponent(out PlayerHealth playerHealth))
        {
            playerHealth.TakeDamage(damage);
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
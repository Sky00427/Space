using UnityEngine;

public class EnemyProjectileDamage : MonoBehaviour
{
    [Header("Damage")]
    public int damage = 1;

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag("Player"))
        {
            PlayerHealth playerHealth =
                coll.gameObject.GetComponent<PlayerHealth>();

            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damage);
            }

            Destroy(gameObject);
        }
    }
}
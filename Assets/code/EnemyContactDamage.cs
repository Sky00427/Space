using UnityEngine;

public class EnemyContactDamage : MonoBehaviour
{
    [Header("Damage")]
    public int damage = 1;

    [Header("After Hit")]
    public bool destroySelfOnHit = true;

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (!coll.gameObject.CompareTag("Player"))
            return;

        PlayerHealth playerHealth =
            coll.gameObject.GetComponent<PlayerHealth>();

        if (playerHealth != null)
        {
            playerHealth.TakeDamage(damage);
        }

        if (destroySelfOnHit)
        {
            Destroy(gameObject);
        }
    }
}
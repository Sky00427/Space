using UnityEngine;

public class EnemyContactDamage : MonoBehaviour
{
    [Header("Damage")]
    public int damage = 1;

    [Header("After Hit")]
    public bool destroySelfOnHit = true;

    void OnCollisionEnter2D(Collision2D coll)
    {
        if(coll.gameObject.TryGetComponent(out PlayerHealth playerHealth))
        {
            playerHealth.TakeDamage(damage);
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
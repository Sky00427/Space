using UnityEngine;

public class EnemyBulletDamage : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.name == "PlayerShip")
        {
            GameManager.instance.LoseLife();

            Destroy(gameObject);
        }
    }
}


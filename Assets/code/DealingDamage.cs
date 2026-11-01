using UnityEngine;

public class BulletDamage : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Ship")
        {
            GameManager.instance.AddScore(100);

            Destroy(coll.gameObject);
            Destroy(gameObject);
        }
        if (coll.gameObject.tag == "wall")
        {
            Destroy(gameObject);
        }
    }
}


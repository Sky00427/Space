using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Ship")
        {
            GameManager.instance.LoseLife();

            Destroy(coll.gameObject);
        }
    }
}

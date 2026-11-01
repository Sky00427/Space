using UnityEngine;
using System.Collections;

public class FireEnemy : MonoBehaviour
{
    // The Bullet Prefab
    public GameObject bullet;

    // The firing Interval
    public float interval = 2;

    // Use this for initialization
    void Start()
    {
        // Call Fire every few seconds
        InvokeRepeating("Fire", interval, interval);
    }

    void Fire()
    {
        // Spawn the Bullet
        GameObject g = (GameObject)Instantiate(bullet,
                                               transform.position,
                                               Quaternion.identity);

        // Ignore Bullet<->Enemy Ship collisions
        Physics2D.IgnoreCollision(g.GetComponent<Collider2D>(),
                                  transform.parent.GetComponent<Collider2D>());
    }
}

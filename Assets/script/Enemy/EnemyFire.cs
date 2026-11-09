using UnityEngine;
using System.Collections;

public class EnemyFire : MonoBehaviour
{
    public GameObject bullet;

    public float interval = 2;

    void Start()
    {
        InvokeRepeating("Fire", interval, interval);
    }

    void Fire()
    {
        GameObject g = Instantiate(bullet, transform.position, Quaternion.identity);

        Physics2D.IgnoreCollision(g.GetComponent<Collider2D>(), transform.parent.GetComponent<Collider2D>());
    }
}

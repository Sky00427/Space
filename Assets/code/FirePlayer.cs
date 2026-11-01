using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePlayer : MonoBehaviour
{
    public Transform left;
    public Transform right;
    // Bullet Prefab
    public GameObject bullet;
    public AudioSource audioSource;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {

            Fire();

            // // Ignore Bullet<->Player collisions
            // Physics2D.IgnoreCollision(g.GetComponent<Collider2D>(),
            //                           transform.parent.GetComponent<Collider2D>());
        }
    }
    public void Fire()
    {
        audioSource.Play();
        Instantiate(bullet, left.position, Quaternion.identity);
        Instantiate(bullet, right.position, Quaternion.identity);
    }
}

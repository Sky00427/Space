using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    public Transform firePos;
    // Bullet Prefab
    public GameObject bullet;
    public AudioSource audioSource;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {

            Fire();

        }
    }
    public void Fire()
    {
        audioSource.Play();
        Instantiate(bullet, firePos.position, Quaternion.identity);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    // Ship Speed
    public float speed = 5;

    void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");


        Vector2 dir = new Vector2(h, v);
        GetComponent<Rigidbody2D>().linearVelocity = dir.normalized * speed;
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    // Ship Speed
    public float speed = 5;

    void FixedUpdate()
    {
        // Get Input from Arrow Keys, WSAD, Gamepads, ...
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        // Set the Rigidbody's Velocity
        Vector2 dir = new Vector2(h, v);
        GetComponent<Rigidbody2D>().linearVelocity = dir.normalized * speed;

        // Set Animation Parameter
        GetComponent<Animator>().SetBool("Flying", (v > 0));
    }

}

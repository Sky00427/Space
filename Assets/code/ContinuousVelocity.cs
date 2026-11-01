using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContinuousVelocity : MonoBehaviour
{
    // The Velocity
    public Vector2 velocity;

    void FixedUpdate()
    {
        GetComponent<Rigidbody2D>().linearVelocity = velocity;
    }
}

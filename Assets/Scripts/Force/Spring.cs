using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spring : MonoBehaviour
{
    public Body bodyA { get; set; } = null;
    public Body bodyB { get; set; } = null;

    public float restLength { get; set; } = 0.5f;
    public float k { get; set; } = 20.0f;

    public void ApplyForce()
    {
        Vector2 force = Utilities.SpringForce(bodyA.position, bodyB.position, restLength, k);
        float modifier = (bodyA.type == Body.eType.Static || bodyB.type == Body.eType.Static) ? 1.0f : 0.5f;

        bodyA.AddForce(-force * modifier, Body.eForceMode.Force);
        bodyB.AddForce( force * modifier, Body.eForceMode.Force);
    }
}

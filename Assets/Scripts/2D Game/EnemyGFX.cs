using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyGFX : MonoBehaviour
{
    public AIPath AIPath;
            
    void Update()
    {
        if(AIPath.desiredVelocity.x >= 0.01f)
        {
            transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
        }
        else if(AIPath.desiredVelocity.x <= -0.01f)
        {
            transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        }
    }
}

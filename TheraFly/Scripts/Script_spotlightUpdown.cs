//Ka Man CHOI 50000567 - TheraFly
//control the up and down (y axis) of spotlight of handler on rooftop

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_spotlightUpdown : MonoBehaviour
{
    public float moveSpeed = 2.0f;        
    public float moveDistance = 3.0f;     
    public float moveDelay = 0.5f;        

    private float startingY;            
    private float finalY;              
    private bool movingUp = true;
    private float moveTimer;   

    void Start()
    {
        // Store the starting Y position of the spotlight
        startingY = transform.position.y;
    }

    void Update()
    {
        //apply and check delay
        if (moveTimer < moveDelay)
        {
            moveTimer += Time.deltaTime;
            return;
        }

        // move spotlight up and down - y axis
        if (movingUp)
        {
            finalY = startingY + moveDistance;
        }
        else
        {
            finalY = startingY - moveDistance;
        }
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, finalY, transform.position.z), moveSpeed * Time.deltaTime);

        // go reverse when reach destination of Y
        if (transform.position.y == finalY)
        {
            movingUp = !movingUp;
            moveTimer = 0f;
        }
    }
}

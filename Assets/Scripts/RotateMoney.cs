using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateMoney : MonoBehaviour
{
    public float speed = 2f;

    void FixedUpdate()
    {
        if (transform.position.y <= 0.5)
        {
            speed = -speed;
        }
        else if (transform.position.y >= 2)
        {
            speed = -speed;
        }
        Vector3 input = new Vector3(0, 1, 0);
        transform.position += input * Time.deltaTime * speed;

        transform.Rotate(0, 60 * Time.deltaTime, 0);
    }
}

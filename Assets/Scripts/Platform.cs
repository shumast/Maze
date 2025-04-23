using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Timeline.TimelinePlaybackControls;

public class Platform : MonoBehaviour
{
    public float speed = 3f;

    void FixedUpdate()
    {
        if (transform.position.x >= 4)
        {
            speed = -speed;
        }
        else if (transform.position.x <= -4)
        {
            speed = -speed;
        }
        Vector3 input = new Vector3(1, 0, 0);
        transform.position += input * Time.deltaTime * speed;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            other.transform.parent = this.transform;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            other.transform.parent = null;
        }
    }
}

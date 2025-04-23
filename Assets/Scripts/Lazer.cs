using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Lazer : MonoBehaviour
{
    private LineRenderer lr;

    void Start()
    {
        Time.timeScale = 1.0f;
        lr = GetComponent<LineRenderer>();
    }

    void FixedUpdate()
    {
        lr.SetPosition(0, transform.position);
        var ray = new Ray(this.transform.position, transform.forward);
        RaycastHit hit;
        if (Physics.Raycast(this.transform.position, transform.forward, out hit))
        {
            if (hit.collider)
            {
                lr.SetPosition(1, hit.point);
            }
            if (hit.transform.tag == "Player")
            {
                SceneManager.LoadScene(0);
            }
        }
        else
        {
            lr.SetPosition(1, transform.forward * 600);
        }
    }
}

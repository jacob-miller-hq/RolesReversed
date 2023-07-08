using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class FollowPath : MonoBehaviour
{
    public GameObject path;
    public bool reverse = false;
    public float speed = 0.01f;
    public bool done = false;

    public Transform[] pathPoints;
    int nextPoint = 0;

    // Start is called before the first frame update
    void Start()
    {
        pathPoints = path.GetComponentsInChildren<Transform>();
        if (reverse)
        {
            pathPoints = pathPoints.Reverse().ToArray();
        }
    }

    void FixedUpdate()
    {
        if (done || nextPoint >= pathPoints.Length)
        {
            done = true;
            return;
        }
        if (Vector2.Distance(pathPoints[nextPoint].position, transform.position) < speed)
        {
            nextPoint = nextPoint + 1;
        }
        transform.position = Vector2.MoveTowards(transform.position, pathPoints[nextPoint].position, speed);
    }
}

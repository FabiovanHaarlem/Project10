using UnityEngine;
using System.Collections;

public class PivotRotate : MonoBehaviour
{
    public Transform target;
    public float speed = 10;

    void Update()
    {
        transform.RotateAround(target.position, target.up, speed * Time.deltaTime);
    }
}
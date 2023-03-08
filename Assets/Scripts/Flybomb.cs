using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flybomb : MonoBehaviour
{
    public Transform point1;
    public Transform point2;
    public float speed = 60f;
    public float rotateSpeed = 40f;

    void Start()
    {
        transform.position = new Vector2(transform.position.x, transform.position.y);
    }

    void Update()
    {
        transform.localEulerAngles = new Vector3(0, 0, Mathf.PingPong(Time.time * rotateSpeed, 90) - 45);

        transform.position = Vector2.MoveTowards(transform.position, point1.position, speed * Time.deltaTime);

        if (transform.position == point1.position)
        {
            Transform t = point1;
            point1 = point2;
            point2 = t;
            transform.Rotate(new Vector3(0, 0, 0) * speed * Time.deltaTime);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollBackground : MonoBehaviour
{
    private float scrollSpeed = 0.5f;
    public Transform cameraTransform;
    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        float offset = cameraTransform.position.y * scrollSpeed;
        Vector3 currentPosition = startPosition + new Vector3(0, offset, 0);
        transform.position = Vector3.Lerp(transform.position, currentPosition, scrollSpeed * Time.deltaTime);
    }
}


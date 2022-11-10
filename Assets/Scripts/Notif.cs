using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Notif : MonoBehaviour
{
    private void Start()
    {
        float waittime = 15f;
        Destroy(gameObject, waittime);
    }
}

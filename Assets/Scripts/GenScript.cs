using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenScript : MonoBehaviour

{
    public GameObject Bomb1;
    public GameObject Bomb2;
    public GameObject Bomb3;

    public Transform shoot;
    float timeShooting;
    float timeShooting1;
    float timeShooting2;

    private void Start()
    {
        StartCoroutine(Shooting());
        StartCoroutine(Shooting1());
        StartCoroutine(Shooting2());
    }

    private void Update()
    {
        timeShooting = Random.Range(1f, 4f);
        timeShooting1 = Random.Range(1.5f, 4.5f);
        timeShooting2 = Random.Range(2f, 5f);
    }
    IEnumerator Shooting()
    {
        yield return new WaitForSeconds(timeShooting);
        Instantiate(Bomb1, shoot.transform.position, transform.rotation);
        StartCoroutine(Shooting());
    }
    IEnumerator Shooting1()
    {
        yield return new WaitForSeconds(timeShooting1);
        Instantiate(Bomb2, shoot.transform.position, transform.rotation);
        StartCoroutine(Shooting1());
    }
    IEnumerator Shooting2()
    {
        yield return new WaitForSeconds(timeShooting2);
        Instantiate(Bomb3, shoot.transform.position, transform.rotation);
        StartCoroutine(Shooting2());
    }
}
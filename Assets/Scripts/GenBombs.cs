using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenBombs : MonoBehaviour

{
    public GameObject[] bombs;
    public Transform shoot;

    private void Start()
    {
        StartCoroutine(Shooting(bombs[0], Random.Range(1f, 4f)));
        StartCoroutine(Shooting(bombs[1], Random.Range(1.5f, 4.5f)));
        StartCoroutine(Shooting(bombs[2], Random.Range(2f, 5f)));
    }

    IEnumerator Shooting(GameObject bomb, float timeShooting)
    {
        while (true)
        {
            yield return new WaitForSeconds(timeShooting);
            Instantiate(bomb, shoot.transform.position, transform.rotation);
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Space : MonoBehaviour
{
    public RubyController player;
    public AudioSource audio;
    public AudioClip cosmo1, cosmo2;
    public GameObject WinScreen;
    bool check = false;
    private void Start()
    {
        player = GameObject.Find("Player").GetComponent<RubyController>();
        WinScreen.SetActive(false);
    }
    void Update()
    {
        if (check)
        {
            StartCoroutine(GeneratingColor());
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && player.GetEnergyBlocks()==10)
        {
            check = true;
            if (player.GetStones() == 0)
            {
                audio.PlayOneShot(cosmo2);
            }
            if (player.GetStones() > 0)
            {
                WinScreen.SetActive(true);
            }
        }
        else if(collision.gameObject.tag == "Player" && player.GetEnergyBlocks() < 10)
        {
            audio.PlayOneShot(cosmo1);
        }
    }
    IEnumerator GeneratingColor()
    {
        GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, GetComponent<SpriteRenderer>().color.a + 0.005f);
        yield return new WaitForSeconds(0.005f);
    }
}

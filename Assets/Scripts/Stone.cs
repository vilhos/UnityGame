using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Stone : MonoBehaviour
{
    public PlayerController player;
    public Image[] stones;
    public Sprite active, nonactive;

    void Update()
    {
        for (int i = 0; i < stones.Length; i++)
        {
            if (player.GetStones() > i)
                stones[i].sprite = active;

            else
                stones[i].sprite = nonactive;
        }
    }
}

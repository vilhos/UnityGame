using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Energy : MonoBehaviour
{
    public PlayerController player;
    public Image[] energyBlocks;
    public Sprite active, nonactive;

    void Update()
    {
        for (int i = 0; i < energyBlocks.Length; i++)
        {
            if (player.GetEnergyBlocks() > i)
                energyBlocks[i].sprite = active;

            else
                energyBlocks[i].sprite = nonactive;
        }
    }
}
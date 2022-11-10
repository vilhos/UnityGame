using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fuel : MonoBehaviour
{
    private RubyController player;
    public Image fuelBar;
    float maxBar = 100;
    public float bar;



    void Start()
    {
        bar = maxBar;
        player = GameObject.Find("Player").GetComponent<RubyController>();
    }
    void Update()
    {
        bar -= 0.5f * Time.deltaTime;
        fuelBar.fillAmount = bar / maxBar;

        if (player.isFuel)
            bar = 100;
    }
}

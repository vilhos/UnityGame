using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Life : MonoBehaviour
{
    private RubyController player;
    public Text lifeText;

    private void Start()
    {
        player = GameObject.Find("Player").GetComponent<RubyController>();
    }
    void Update()
    {
        lifeText.text = player.GetLife().ToString();
    }
}

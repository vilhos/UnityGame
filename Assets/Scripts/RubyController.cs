using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RubyController : MonoBehaviour
{
    public RubyAnimation animation_Controller;
    private AudioSource Rubyaudio;
    public Fuel fuel;
    int life = 5;
    int energyBlock = 0;
    int stone = 0;
    public bool isFuel = false;
    public bool temp;
    float Horizontal;
    float Vertical;

    void Start()
    {
        Rubyaudio = GetComponent<AudioSource>();
    }
    void Update()
    {
        Horizontal = Input.GetAxis("Horizontal");
        Vertical = Input.GetAxis("Vertical");
        if (Horizontal != 0 | Vertical != 0)
        {
            Vector2 position = transform.position;
            position.x = position.x + 3f * Horizontal * Time.deltaTime;
            position.y = position.y + 3f * Vertical * Time.deltaTime;
            animation_Controller.Start_Walk();
            transform.position = position;

            if (Input.GetKey(KeyCode.Space))

                transform.Rotate(0, 0, - 6 * Time.deltaTime);
            else
                transform.Rotate(0, 0, 1 * Time.deltaTime);
        }
        else
        {
            animation_Controller.Stop_Walk();
        }

        LifeControl();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "EnergyBlock")
        {
            Destroy(collision.gameObject);
            energyBlock++;
        }

        if (collision.gameObject.tag == "Stone")
        {
            Destroy(collision.gameObject);
            stone++;
        }

        if (collision.gameObject.tag == "Fuel")
        {
            isFuel = true;
            Destroy(collision.gameObject);
        }
        else
            isFuel = false;

        if (collision.gameObject.tag == "Comet")
        {
            life--;
        }
    }

    void LifeControl()
    {
        if (fuel.bar <= 0)
        {
            life--;
            fuel.bar = 100;
        }

        if (life == 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    public int GetEnergyBlocks()
    {
        return energyBlock;
    }
    public int GetStones()
    {
        return stone;
    }

    public int GetLife()
    {
        return life;
    }
}
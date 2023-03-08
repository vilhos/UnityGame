using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public RubyAnimation animation_Controller;
    private AudioSource Rubyaudio;
    private Vector2 direction;
    public Fuel fuel;
    private int life = 3;
    public float speed = 3;
    private int energyBlock = 0;
    private int stone = 0;
    public bool isFuel = false;
    private float horizontal;
    private float vertical;
    private bool checkCollision;

    private void Start()
    {
        Rubyaudio = GetComponent<AudioSource>();
    }

    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        direction = new Vector2(horizontal, vertical);

        if (horizontal != 0 || vertical != 0)
        {
            transform.Translate(direction * speed * Time.deltaTime);

            animation_Controller.Start_Walk();
        }
        if (horizontal != 0)
        {
            transform.Rotate(0, 0, -horizontal * speed * Time.deltaTime);
        }
        else
        {
            Quaternion newRotation = Quaternion.AngleAxis(0, Vector3.zero);
            transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, Time.deltaTime);
        }
        if (checkCollision)
        {
            speed = Mathf.MoveTowards(speed, 3, 10 * Time.deltaTime);
        }

        GravityScaler();
        LifeControl();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "EnergyBlock")
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
            Destroy(collision.gameObject);
            life--;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        speed = 0.2f; 
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        checkCollision = true;
    }

    private void LifeControl()
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

    public void GravityScaler()
    {
        if (transform.position.y > 40 && vertical > 0)
        {
            speed = Mathf.MoveTowards(speed, 0.2f, 0.5f * Time.deltaTime);
        }
        if (transform.position.y > 40 && vertical < 0)
        {
            speed = Mathf.MoveTowards(speed, 3f, 0.5f * Time.deltaTime);
        }
    }
}

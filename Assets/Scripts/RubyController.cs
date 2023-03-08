using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RubyController : MonoBehaviour
{
    public RubyAnimation animation_Controller;
    private AudioSource Rubyaudio;
    private Rigidbody2D player;
    public Vector2 moveInput;
    public Fuel fuel;
    private int life = 3;
    private float speed = 100f;
    private int energyBlock = 0;
    private int stone = 0;
    public bool isFuel = false;
    float Horizontal;
    float Vertical;

    void Start()
    {
        Rubyaudio = GetComponent<AudioSource>();
        player = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        Horizontal = Input.GetAxis("Horizontal");
        Vertical = Input.GetAxis("Vertical");

        if (Horizontal != 0 || Vertical != 0)
        {
            Vector2 position = transform.position;
            //position.x = position.x + speed * Horizontal * Time.deltaTime;
            //position.y = position.y + speed * Vertical * Time.deltaTime;
            transform.position = position;

            animation_Controller.Start_Walk();

            if (Input.GetKey(KeyCode.Space))

                transform.Rotate(0, 0, -6 * Time.deltaTime);
            else
                transform.Rotate(0, 0, 1 * Time.deltaTime);
        }
        else
        {
            animation_Controller.Stop_Walk();
        }
        GravityScaler();
        LifeControl();
    }
    private void FixedUpdate()
    {
        moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        player.velocity = moveInput.normalized * speed * Time.fixedDeltaTime;
    }
    private void OnCollisionEnter2D(Collision2D collision)
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
            life--;
        }
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
        if (transform.position.y > 20)
        {
            player.gravityScale = 0.1f;
        }
        if (transform.position.y < 20)
        {
            player.gravityScale = 0.02f;
        }
    }
}
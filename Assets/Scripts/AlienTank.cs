using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class AlienTank : MonoBehaviour
{
    public float wspeed = 2;
    private Rigidbody2D rigidBody;
    public GameObject alienBullet;
    public float minFireRateTime = 1.0f;
    public float maxFireRateTime = 3.0f;
    public float baseFireRateTime = 3.0f;
    public Sprite explodedShipImage;
    private SpriteRenderer spriteRenderer;
    static int vidaInimigo = 3;
    public int passar = 0;
    //public int inimigos = 20;
    //public bool N_inimigos;
    // Start is called before the first frame update
    void Start()
    {
        //N_inimigos = false;
        rigidBody = GetComponent<Rigidbody2D>();
        rigidBody.velocity = new Vector2(1, 0) * wspeed;
        spriteRenderer = GetComponent<SpriteRenderer>();
        baseFireRateTime = Time.time+baseFireRateTime + Random.Range
            (minFireRateTime, maxFireRateTime);
    }

    // Turn na outra posicao qdo bate na parede
    void Turn(int direction)
    {
        Vector2 newVelocity = rigidBody.velocity;
        newVelocity.x = wspeed * direction;
        rigidBody.velocity = newVelocity;
    }
    // move pra baixo qdo bate na parede
    void MoveDown()
    {
        Vector2 position = transform.position;
        position.y -= 0.5f;
        transform.position = position;

    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "paredeE")
        {
            Turn(1);
            MoveDown();
        }
        if (col.gameObject.name == "paredeD")
        {
            Turn(-1);
            MoveDown();
        }

    }

    // Update is called once per frame
    void Update()
    {
       
    }

    void FixedUpdate()
    {
        if (Time.time > baseFireRateTime)
        {
            baseFireRateTime = baseFireRateTime + Random.Range
           (minFireRateTime, maxFireRateTime);

            Instantiate(alienBullet, transform.position, Quaternion.identity);
        }
    }

    [System.Obsolete]
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            col.GetComponent<SpriteRenderer>().sprite =
                explodedShipImage;
            Destroy(gameObject);
            DestroyObject(col.gameObject, 0.5f);
        }
        if (col.gameObject.tag == "Bullet")
        {
            vidaInimigo -= 1;
        }
        if (vidaInimigo == passar)
        {
            //inimigos -= 1;
            Destroy(gameObject);
        }
    }

}

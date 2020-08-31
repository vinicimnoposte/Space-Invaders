using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpaceShip : MonoBehaviour
{
    Animator anim;
    public float speed = 2;
    public GameObject theBullet;
    public bool morrer;
    //private bool direita;
    



    void FixedUpdate()
    {
        float horzMove = Input.GetAxisRaw("Horizontal");

        GetComponent<Rigidbody2D>().velocity = new Vector2(horzMove, 0) * speed;
    }
    // Start is called before the first frame update
    void Start()
    {
 
        morrer = false;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    [System.Obsolete]
    void Update()
    {
     

        if (Input.GetButtonDown("Jump"))
        {
            Instantiate(theBullet, transform.position, Quaternion.identity);
        }
         
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            //direita = true;
            //if (direita == false)
            {
                anim.SetBool("Correr", true);
               // Vector3 theScale = transform.localScale;
               // theScale.x *= -1;
               // transform.localScale = theScale;
            }
            //anim.SetBool("Correr", true);
            //direita = true;
        }
        else
        {
            anim.SetBool("Correr", false);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetBool("Fire", true);
        }
        else
        {
            anim.SetBool("Fire", false);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            //direita = false;
            //if (direita == true)
            { 
                anim.SetBool("Correr", true);
            //Vector3 theScale = transform.localScale;
            //theScale.x *= -1;
            //transform.localScale = theScale;
            }
           
        }
        else
        {
            anim.SetBool("Correr", false);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "AlienBullet")
        {
            Destroy(gameObject);
            morrer = true;
        }
        if (morrer == true)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }
    }
    
}

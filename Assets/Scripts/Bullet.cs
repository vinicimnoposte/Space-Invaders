using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Bullet : MonoBehaviour { 

    public float bspeed = 30;
    private Rigidbody2D rigidBody;
    public Sprite explodedAlienImage;
    //static int vida = 3;
    //public int inimigos = 0;
    //public bool N_inimigos;


    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        rigidBody.velocity = Vector2.up * bspeed;

    }

    [System.Obsolete]
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Wall")
        {
            Destroy(gameObject);
        }

        if(col.tag == "Alien")
        {
            //inimigos += 1;
            increaseTextUiScore();
            Destroy(gameObject);
            DestroyObject(col.gameObject);
        }
        if (col.tag == "Shield")
        {
            Destroy(gameObject);
            DestroyObject(col.gameObject);
        }
       /* if (col.tag == "AlienTank")
        {
            //inimigos += 1;
            vida -= 1;
            Destroy(gameObject);
       // }
        //if (vida == 0)
        //{
            increaseTextUiScore();
            DestroyObject(col.gameObject);
       }*/ 


    }

        
        


    void OnBecomeInvisible()
    {
        Destroy(gameObject);
    }


    void increaseTextUiScore()
    {
        var textUIComp = GameObject.Find("Score").GetComponent<Text>();

        int score = int.Parse(textUIComp.text);

        score += 10;

        textUIComp.text = score.ToString();
    }
    // Update is called once per frame
    //void Update()
    //{
      //  OnTriggerEnter2D(Collider2D col)
    //}
     
}

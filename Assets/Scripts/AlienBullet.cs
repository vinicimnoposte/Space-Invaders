using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienBullet : MonoBehaviour
{ 
    private Rigidbody2D rigidBody;
    public float aspeed = 2;
    //public int morrido;
    public int WaitASecondsAndQuit = 3;
    //public bool isGameOver = false; //<-- this is set are game over?
    //public bool isYouWin = false; //<-- this is set are the player win?

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        rigidBody.velocity = Vector2.down * aspeed;
        //morrido = 0;

    }

    [System.Obsolete]
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Wall")
        {
            Destroy(gameObject);
        }
        if(col.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            DestroyObject(col.gameObject, 0.5f);
            //morrido += 1;
        }
        if (col.tag == "Shield")
        {
            Destroy(gameObject);
            DestroyObject(col.gameObject);
        }
    }
    void OnBecomeInvisible()
    {
        Destroy(gameObject);
    }


    // Update is called once per frame
    void Update()
    {
        
    }

   /* void OnGUI()
    {
        if (morrido >= 1)
        {
            Application.Quit();
        }
    }*/
}
   


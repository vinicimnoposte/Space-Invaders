using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;

public class fimdejogo : MonoBehaviour
{
    //static public int inimigos = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter2D(Collider2D col)
    {
      //  if (col.tag == "Alien")
      //  {
           // inimigos += 1;
           // Debug.Log(inimigos);
      //  }
       // if (inimigos == 28)
        //{
        //    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        //}
    }
}

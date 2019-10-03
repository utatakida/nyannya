using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nekoCon : MonoBehaviour
{
    public bool atari;
   
    // Start is called before the first frame update
    void Start()
    {
        atari = false;
    }

    // Update is called once per frame
    void Update()
    {
         if (atari == true)
             GetComponent<Rigidbody2D>().velocity = new Vector2(0,0);
         if(atari==false)
             GetComponent<Rigidbody2D>().velocity = new Vector2(-0.45f, 0);

    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "WaniAtarihantei")
        {
            atari = true;
        }
    }
    
        
    
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "WaniAtarihantei")
        {
            atari = false;
        }
    }
}

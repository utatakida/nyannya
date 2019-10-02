using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tankunekoCon : MonoBehaviour
{
    public bool atari;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(atari==true)
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        else
            GetComponent<Rigidbody2D>().velocity = new Vector2(-1, 0);
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "waniPre")
            atari = true;
    }
    public void OnTriggerExit2D(Collider2D collision)
    { 
        if (collision.gameObject.name == "waniPre")
            atari = false;
    }
}

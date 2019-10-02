using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waniCon : MonoBehaviour
{
    public bool atari=false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(atari=false)
        GetComponent<Rigidbody2D>().velocity = new Vector2(1, 0);
        
    //    GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);

    }
    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.name == "tankunekoPre")
            atari = true;
        Debug.Log("atari");
    }
}

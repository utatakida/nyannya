using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waniCon : MonoBehaviour
{
    public bool atari=false;
    //ワニの位置を共有するためpreivateにする
   
    // Start is called before the first frame update
    void Start()
    {
      
       // GetComponent<SpriteRenderer>().sortingOrder = randamu;
    }

    // Update is called once per frame
    void Update()
    {
      


        if (atari == true)
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        if(atari==false)
            GetComponent<Rigidbody2D>().velocity = new Vector2(1, 0);
            
        
      

    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
       
        if (collision.gameObject.name == "TankunekoAtarihantei")
            atari = true;
        if (collision.gameObject.name == "NekoAtarihantei")
            atari = true;
        if (collision.gameObject.name == "KimonekoAtarihantei")
            atari = true;
        
    }
    public void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.gameObject.name == "TankunekoAtarihantei")
            atari = false;
        if (collision.gameObject.name == "NekoAtarihantei")
            atari = false;
        if (collision.gameObject.name == "KimonekoAtarihantei")
            atari = false;
    }
  
}

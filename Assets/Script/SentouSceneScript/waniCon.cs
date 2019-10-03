using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waniCon : MonoBehaviour
{
    public bool atari=false;
<<<<<<< HEAD
    //ワニの位置を共有するためpreivateにする
   
=======
>>>>>>> 27d29f9e273db7aec29eddb9be69b6350fe0d430
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
       
            if (collision.gameObject.name == "TankunekoPre")
                atari = true;
        
    }
    public void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.gameObject.name == "TankunekoPre")
            atari = false;
    }
}

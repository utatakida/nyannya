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
<<<<<<< HEAD
        if (collision.gameObject.name == "WaniAtarihantei")
        {
=======
        if (collision.gameObject.name == "waniPre")
>>>>>>> じぶんよう
            atari = true;
            Debug.Log("ワニ当たり判定");
        }

        if (collision.gameObject.name == "WaniKougekihantei")
        {
            Debug.Log("ワニ攻撃判定");
        }
    }
    public void OnTriggerExit2D(Collider2D collision)
    { 
<<<<<<< HEAD
        if (collision.gameObject.name == "WaniAtarihantei")
=======
        if (collision.gameObject.name == "waniPre")
>>>>>>> じぶんよう
            atari = false;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waniCon : MonoBehaviour
{
    

    public int wani=700;


    //  ワニの攻撃時間を設定
    public bool wanijikan;
    
    float jikan;
    float kougekijikan;

    public bool atari=false;
    
   
    // Start is called before the first frame update
    void Start()
    {

        jikan = 0;
        kougekijikan = 2;
    }

    // Update is called once per frame
    void Update()
    {
        if (wani < 0)
        {
            Destroy(gameObject);
        }
       jikan += Time.deltaTime;
        if (jikan > kougekijikan)
        {
            wanijikan = true;
            jikan = 0;
        }
        else
            wanijikan = false;


        if (atari == true)
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        if(atari==false)
            GetComponent<Rigidbody2D>().velocity = new Vector2(0.6f, 0);
          
            
        
        

    }
    public void OnTriggerStay2D(Collider2D collision)
    {
       
        if (collision.gameObject.name == "TankunekoAtarihantei")
            atari = true;
        if (collision.gameObject.name == "NekoAtarihantei")
        {
            atari = true;
            collision.transform.root.gameObject.GetComponent<nekoCon>().neko -= 700;
        }
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

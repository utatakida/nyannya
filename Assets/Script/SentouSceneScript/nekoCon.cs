using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nekoCon : MonoBehaviour
{
    //猫のコライダーが他のコライダーに接触したかのbool
    public bool atari;

 
    public int neko = 4200;

    //ねこの攻撃時間を設定
    public bool nekojikan;
    
    float jikan;
    float kougekijikan;

    //ワニのスクリプトを設定
    waniCon wani = new waniCon();



    

    // Start is called before the first frame update
    void Start()
    {
        atari = false;
        jikan = 0;
        kougekijikan = 2;
    }

    // Update is called once per frame
    void Update()
    {
        jikan += Time.deltaTime;
        if (jikan > kougekijikan)
        {
            nekojikan = true;
            jikan = 0;
        }
        else
            nekojikan = false;
      /*  jikan += Time.deltaTime;
        if (jikan > kougekijikan)
        {
            nekojikan = true;
            jikan = 0;
        }
        else
            nekojikan = false;*/

        

         if (atari == true)
             GetComponent<Rigidbody2D>().velocity = new Vector2(0,0);
         if(atari==false)
             GetComponent<Rigidbody2D>().velocity = new Vector2(-0.45f, 0);

        /*if (waniCon.wanijikan == true&&atari==true)
        {
            nekohp -= wani.waniPower;
        }

        if (nekohp < 0)
        {
            Destroy(gameObject);
        }
        Debug.Log(nekohp);*/

        if (neko < 0)
            Destroy(gameObject);
    }

    public void OnTriggerStay2D(Collider2D collision)
    {
       
        if (collision.gameObject.name == "WaniAtarihantei")
        {
            atari = true;
           
            collision.transform.root.gameObject.GetComponent<waniCon>().wani -=500;
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

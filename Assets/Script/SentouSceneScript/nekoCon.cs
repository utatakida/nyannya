using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nekoCon : MonoBehaviour
{
    //猫のコライダーが他のコライダーに接触したかのbool
    public bool atari;

    //猫の体力
    public int neko = 1000;

    //猫の攻撃力
    int kougekiryoku = 100;

    //猫の移動速度
    float sokudo = 0.45f;
    //猫の攻撃時間を設定
    float kougekijikan=1;
    float jikan;
    bool kougeki;

    //ワニのスクリプトを設定
    waniCon wani = new waniCon();



    

    // Start is called before the first frame update
    void Start()
    {
        atari = false;

       
        jikan = 0;
        kougeki = false;
    }

    // Update is called once per frame
    void Update()
    {
        //猫の攻撃時間を設定
        jikan += Time.deltaTime;
        if (jikan > kougekijikan)
        {
            kougeki = true;
            jikan =0;
        }
        
        

        if (atari == true)
            GetComponent<Rigidbody2D>().velocity = new Vector2(0,0);
        if(atari==false)
            GetComponent<Rigidbody2D>().velocity = new Vector2(-sokudo, 0);

       

       if (neko < 0)
            Destroy(gameObject);
    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.name == "syatihoko")
        {
            atari = true;
            if (kougeki == true)
            {
                collision.transform.root.gameObject.GetComponent<syatihokoCon>().syatihoko -= kougekiryoku;
                kougeki = false;
            }
        }
        //ワニの当たり判定に入るとワニのHPを減らす
        if (collision.gameObject.name == "WaniAtarihantei")
        {
            atari = true;
            if (kougeki == true)
            {
                collision.transform.root.gameObject.GetComponent<waniCon>().wani -= kougekiryoku;
                kougeki = false;
            }
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tankunekoCon : MonoBehaviour
{
    //タンク猫の攻撃範囲     
    public bool atari;

    //タンク猫の攻撃力
    int kougekiryoku = 100;

    //タンク猫の体力
    public int tankuneko = 1000;

    //タンク猫の速度
    float sokudo = 1;

    //タンク猫の攻撃時間
    float kougekijikan = 1;
    float jikan = 0;
    bool kougeki=false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //タンク猫の攻撃時間設定
        jikan += Time.deltaTime;
        if (jikan > kougekijikan)
        {
            kougeki = true;
            jikan =0;
        }
        //タンク猫の消去
        if (tankuneko < 0)
        {
            Destroy(gameObject);
        }

        if(atari==true)
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        else
            GetComponent<Rigidbody2D>().velocity = new Vector2(-sokudo, 0);
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
        if (collision.gameObject.name == "WaniKougekihantei")
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
            atari = false;
        if (collision.gameObject.name == "WaniKougekihantei")
            atari = false;
    }
}

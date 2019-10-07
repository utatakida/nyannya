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

    //猫のノックバック
    bool nockback = false;
    int kaisuu=2;
    float nockbackjikan = 0.75f;
    int nockbacktairyoku = 500;

    //猫の消去
    bool nekosyoukyo = false;

    

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
        
        //ノックバックを設定
        if (neko < nockbacktairyoku&&kaisuu%2==0)
        {
            nockback = true;
            kaisuu += 1;
        }
        if (nockback == true)
        {
            if (nockbackjikan > 0)
            {
                GetComponent<Rigidbody2D>().AddForce(transform.right * 80);
            }
            nockbackjikan -= Time.deltaTime;
            if (nockbackjikan < 0)
            {
                nockbackjikan = 0.75f;
                nockback = false;
                if (nekosyoukyo == true)
                    Destroy(gameObject);
            }
        }
        //猫の攻撃時間を設定
        jikan += Time.deltaTime;
        if (jikan > kougekijikan)
        {
            kougeki = true;
            jikan =0;
        }
        
        
        //猫の移動速度
        if (atari == true)
            GetComponent<Rigidbody2D>().velocity = new Vector2(0,0);
        if(atari==false)
            GetComponent<Rigidbody2D>().velocity = new Vector2(-sokudo, 0);
       
        //猫の体力がなくなったら消去
        if (neko < 0)
        {
            nockback = true;
            nekosyoukyo = true;

        }
            
    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        //敵城当たり判定
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
        //アザラシ当たり判定
        if (collision.gameObject.name == "AzarasiAtarihantei")
        {
            atari = true;
            if (kougeki == true)
            {
                collision.transform.root.gameObject.GetComponent<azarasiCon>().azarasi -= kougekiryoku;
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

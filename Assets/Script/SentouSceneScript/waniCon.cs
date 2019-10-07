using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waniCon : MonoBehaviour
{
    //ワニのHP
    public int wani=1000;

    //ワニの攻撃力
    int kougekiryoku=100;
    
    //ワニの攻撃範囲
    public bool atari=false;

    //ワニの移動速度
    float sokudo = 0.6f;

    //ワニの攻撃時間
    float kougekijikan=1;
    float jikan;
    bool kougeki;

    //ワニのノックバック
    bool nockback = false;
    int kaisuu = 2;
    float nockbackjikan = 0.75f;
    int nockbacktairyoku = 500;

    //ワニの消去
    bool wanisyoukyo = false;

    // Start is called before the first frame update
    void Start()
    {
      
        jikan =0;        //現在の時間
        kougeki=false;//ワニが攻撃可能になるとtrue
    }

    // Update is called once per frame
    void Update()
    {
        //ノックバックを設定
        if (wani < nockbacktairyoku && kaisuu % 2 == 0)
        {
            nockback = true;
            kaisuu += 1;
        }
        if (nockback == true)
        {
            if (nockbackjikan > 0)
            {
                GetComponent<Rigidbody2D>().AddForce(transform.right *- 80);
            }
            nockbackjikan -= Time.deltaTime;
            if (nockbackjikan < 0)
            {
                nockbackjikan = 0.75f;
                nockback = false;
                if (wanisyoukyo == true)
                    Destroy(gameObject);
            }
        }
        //ワニのHPがなくなると消去
        if (wani < 0)
        {
            nockback = true;
            wanisyoukyo = true;
        }

        //ワニの攻撃時間を設定
        jikan += Time.deltaTime;
        if (jikan > kougekijikan)
        {
            kougeki = true;
            jikan = 0;
        }
      


        if (atari == true)
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        if(atari==false)
            GetComponent<Rigidbody2D>().velocity = new Vector2(sokudo, 0);
          
            
        
        

    }
    public void OnTriggerStay2D(Collider2D collision)
    {
        //にゃんこ城当たり判定
        if (collision.gameObject.name == "nyankojyou")
        {
            atari = true;

            if (kougeki == true)
            {
                collision.transform.root.gameObject.GetComponent<nyankojyouCon>().nyankojyou -= kougekiryoku;
                kougeki = false;
            }
        }
        //タンク猫の当たり判定
        if (collision.gameObject.name == "TankunekoAtarihantei")
        {

            atari = true;
            if (kougeki == true)
            {
                collision.transform.root.gameObject.GetComponent<tankunekoCon>().tankuneko -= kougekiryoku;
                kougeki = false;
            }

        }
        //猫の当たり判定
        if (collision.gameObject.name == "NekoAtarihantei")
        {

            atari = true;
            if (kougeki == true)
            {
                collision.transform.root.gameObject.GetComponent<nekoCon>().neko -= kougekiryoku;
                kougeki = false;
            }
        }
        //きもねこの当たり判定
        if (collision.gameObject.name == "KimonekoAtarihantei")
        {
            atari = true;
            if (kougeki == true)
            {
                collision.transform.root.gameObject.GetComponent<kimonekoCon>().kimoneko -= kougekiryoku;
                kougeki = false;
            }
        }
        
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

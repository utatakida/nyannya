using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waniCon : MonoBehaviour
{
    Animator tengoku;

    //ワニが倒されたときに増える金額
    float wanikin = 50;

    //ワニのHP
    public int wani=1000;

    //ワニの攻撃力
    int kougekiryoku=100;
    
    //ワニの攻撃範囲
    public bool atari=false;

    //ワニの移動速度
    float sokudo = 0.6f;

    //ワニの攻撃時間
    float kougekijikan=0.7f;
    float jikan;
    bool kougeki;

    //ワニのノックバック
    bool nockback = false;
    int kaisuu = 2;
    float nockbackjikan = 0.75f;
    int nockbacktairyoku = 500;

    //ワニの消去
    bool wanisyoukyo = false;

    //ワニの攻撃アニメの設定
    float wanianimejikan = 0.27f;
    bool wanianimekaisi=false;
    bool kougekianime = false;
    float kaisijikan = 0;

    // Start is called before the first frame update
    void Start()
    {

        tengoku = GetComponent<Animator>();

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
                jikan -= Time.deltaTime;
            }
            nockbackjikan -= Time.deltaTime;
            if (nockbackjikan < 0)
            {
                nockbackjikan = 0.75f;
                nockback = false;
                if (jikan > kougekijikan)
                {
                    jikan = kougekijikan;
                }
                else if (jikan < kougekijikan)
                    jikan -= 0.3f;
                if (wanisyoukyo == true)
                {
                    if(kingakuCon.kingaku +wanikin <= kingakuCon.saidai)
                    {
                        kingakuCon.kingaku += wanikin;
                    }
                    if (kingakuCon.kingaku + wanikin > kingakuCon.saidai)
                    {
                        kingakuCon.kingaku = kingakuCon.saidai;
                    }

                    Destroy(gameObject);
                }
            }
        }
       
        //ワニのHPがなくなると消去
        if (wani < 0)
        {
            nockback = true;
            wanisyoukyo = true;
        }

        //ワニの攻撃時間とアニメ時間を設定
        jikan += Time.deltaTime;
        if (jikan > kougekijikan)
        {
            kougeki = true;
            jikan = 0;
        }
        if (jikan > wanianimejikan)
        {
            wanianimekaisi = true;
        }
      /*  if (kougekianime == true)
        {
            kaisijikan += Time.deltaTime;
            if (kaisijikan > kougekijikan - wanianimejikan)
            {
                kougekianime = false;
                kaisijikan = 0;
            }
            GetComponent<Animator>().SetInteger("wanianime", 2);
            wanianimekaisi = false;
        }
        else
        {
            //ワニのアニメーションを設定
            if (atari == true)
                GetComponent<Animator>().SetInteger("wanianime", 1);
            if (atari == false)
                GetComponent<Animator>().SetInteger("wanianime", 0);
        }*/
            //ワニの移動速度と待機はここで設定
            if (atari == true)
                GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            if (atari == false)
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
            if (wanianimekaisi == true)
            {
                kougekianime = true;
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
            if (wanianimekaisi == true)
            {
                kougekianime = true;
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
            if (wanianimekaisi == true)
            {
                kougekianime = true;
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
            if (wanianimekaisi == true)
            {
                kougekianime = true;
            }
        }
        
    }
    //ワニが攻撃をしないときは前進
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "nyankojyou")
            atari = false;
        if (collision.gameObject.name == "TankunekoAtarihantei")
            atari = false;
        if (collision.gameObject.name == "NekoAtarihantei")
            atari = false;
        if (collision.gameObject.name == "KimonekoAtarihantei")
            atari = false;
    }

}

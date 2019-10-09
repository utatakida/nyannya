using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waniCon : MonoBehaviour
{
    Animator tengoku;

    //ワニが倒されたときに増える金額
    float wanikin = 50;

    //ワニのHP
    public int wani=500;

    //ワニの攻撃力
    int kougekiryoku=200;
    
    //ワニの攻撃範囲
    public bool atari=false;

    //ワニの移動速度
    float sokudo = 0.6f;

    //ワニの攻撃時間を設定
    float jikan = 0;
    bool kougeki = false;

    //ワニのアニメータを設定
    bool kougekianime;
    float animekaisijikan = 0.6f;  //アニメ開始時間
    bool animekaisi = false;
    float aidanojikan = 0.25f;         //アニメ開始から攻撃までの時間
    float kougekijikan = 0;

    //ワニのノックバック
    bool nockback = false;
    int kaisuu = 2;
    float nockbackjikan = 0.75f;
    int nockbacktairyoku = 500;

    //ワニの消去
    bool wanisyoukyo = false;

    //攻撃時の煙の微調整
    float tate = 0f;
    float yoko = 1.0f;

    //ワニの現在の位置を取得
    Vector2 waniiti;

    //天使と煙のプレハブを取得
    public GameObject tensiPre;
    public GameObject kemuri;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //ワニの現在の位置を取得
        waniiti = GameObject.Find("waniPre").transform.position;
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
                    GameObject go = Instantiate(tensiPre) as GameObject;
                    go.transform.position = waniiti;
                }
            }
        }
       
        //ワニのHPがなくなると消去
        if (wani < 0)
        {
            nockback = true;
            wanisyoukyo = true;
        }

        //ワニの動きと攻撃の時間を合わせる
        jikan += Time.deltaTime;
        if (jikan > animekaisijikan)
        {
            animekaisi = true;
        }

        if (kougekianime == true)
        {
            kougekijikan += Time.deltaTime;
            if (kougekijikan > aidanojikan)
            {
                kougeki = true;
                jikan = 0;
                kougekijikan = 0;
                kougekianime = false;
                animekaisi = false;
            }
        }

        //アニメの設定

        if (kougekianime == true)
        {
            GetComponent<Animator>().SetInteger("state", 2);
        }
        else
        {
            //ワニの待機と歩きアニメーション
            if (atari == true)
            {
                GetComponent<Animator>().SetInteger("state", 1);
            }
            else
            {
                GetComponent<Animator>().SetInteger("state", 0);
            }

        }
        if (nockback == true)
            GetComponent<Animator>().SetInteger("state", 3);
        //ワニの移動速度と待機はここで設定
        if (atari == true)
                GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        else
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
                //攻撃時の煙演出を設定
                GameObject go = Instantiate(kemuri) as GameObject;
                go.transform.position = new Vector2(yoko + waniiti.x, tate + waniiti.y);
            }
            if (animekaisi == true)
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
                //攻撃時の煙演出を設定
                GameObject go = Instantiate(kemuri) as GameObject;
                go.transform.position = new Vector2(yoko + waniiti.x, tate + waniiti.y);
            }
            if (animekaisi == true)
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
                //攻撃時の煙演出を設定
                GameObject go = Instantiate(kemuri) as GameObject;
                go.transform.position = new Vector2(yoko + waniiti.x, tate + waniiti.y);
            }
            if (animekaisi == true)
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
                //攻撃時の煙演出を設定
                GameObject go = Instantiate(kemuri) as GameObject;
                go.transform.position = new Vector2(yoko + waniiti.x, tate + waniiti.y);
            }
            if (animekaisi == true)
            {
                kougekianime = true;
            }
        }
        //巨神の当たり判定
        if (collision.gameObject.name == "KyosinAtarihantei")
        {

            atari = true;
            if (kougeki == true)
            {
                collision.transform.root.gameObject.GetComponent<kyojinnekoCon>().kyojinneko -= kougekiryoku;
                kougeki = false;
                //攻撃時の煙演出を設定
                GameObject go = Instantiate(kemuri) as GameObject;
                go.transform.position = new Vector2(yoko + waniiti.x, tate + waniiti.y);
            }
            if (animekaisi == true)
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
        if (collision.gameObject.name == "KyosinAtarihantei")
            atari = false;
    }

}

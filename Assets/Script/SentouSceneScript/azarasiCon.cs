using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class azarasiCon : MonoBehaviour
{
    //アザラシが倒されたときに増える金額
    float azarakin =650;
    //アザラシのHP
    public int azarasi = 1000;

    //アザラシの攻撃力
    int kougekiryoku = 500;

    //アザラシの攻撃範囲
    bool atari = false;

    //アザラシの移動速度
    float sokudo = 0.6f;

   
    //アザラシのノックバック
    bool nockback = false;
    int kaisuu = 2;
    float nockbackjikan = 0.75f;
    int nockbacktairyoku = 500;

    //アザラシの攻撃時間を設定
    float jikan = 0;
    bool kougeki = false;

    //アザラシのアニメータを設定
    bool kougekianime;
    float animekaisijikan = 0.7f;  //アニメ開始時間
    bool animekaisi = false;
    float aidanojikan = 0.25f;         //アニメ開始から攻撃までの時間
    float kougekijikan = 0;

    //アザラシの消去
    bool azarasisyoukyo = false;

    //天使と煙のプレハブを取得
    public GameObject tensiPre;
    public GameObject kemuri;

    //攻撃時の煙の微調整
    float tate = 0f;
    float yoko = 2.0f;

    //アザラシの現在の位置を取得
    Vector2 azarasiiti;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //ワニの現在の位置を取得
        azarasiiti = GameObject.Find("AzarasiPre").transform.position;

        //ノックバックを設定
        if (azarasi < nockbacktairyoku && kaisuu % 2 == 0)
        {
            nockback = true;
            kaisuu += 1;
        }
        if (nockback == true)
        {
            if (nockbackjikan > 0)
            {
                GetComponent<Rigidbody2D>().AddForce(transform.right * -80);
            }
            nockbackjikan -= Time.deltaTime;
            if (nockbackjikan < 0)
            {
                nockbackjikan = 0.75f;
                nockback = false;
                if (azarasisyoukyo == true)
                {
                    if (kingakuCon.kingaku + azarakin <= kingakuCon.saidai)
                    {
                        kingakuCon.kingaku += azarakin;
                    }
                    if (kingakuCon.kingaku + azarakin > kingakuCon.saidai)
                    {
                        kingakuCon.kingaku = kingakuCon.saidai;
                    }
                    Destroy(gameObject);
                    GameObject go = Instantiate(tensiPre) as GameObject;
                    go.transform.position = azarasiiti;
                }
            }
        }

        //アザラシのHPがなくなると消去
        if (azarasi< 0)
        {
            nockback = true;
            azarasisyoukyo = true;
        }

        //アザラシの動きと攻撃の時間を合わせる
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
            //アザラシの待機と歩きアニメーション
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
                //攻撃時の煙演出を設定
                GameObject go = Instantiate(kemuri) as GameObject;
                go.transform.position = new Vector2(yoko + azarasiiti.x, tate + azarasiiti.y);
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
                go.transform.position = new Vector2(yoko + azarasiiti.x, tate + azarasiiti.y);
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
                go.transform.position = new Vector2(yoko + azarasiiti.x, tate + azarasiiti.y);
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
                go.transform.position = new Vector2(yoko + azarasiiti.x, tate + azarasiiti.y);
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
                go.transform.position = new Vector2(yoko + azarasiiti.x, tate + azarasiiti.y);
            }
            if (animekaisi == true)
            {
                kougekianime = true;
            }
        }
    }
    //アザラシが攻撃をしないときは前進
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





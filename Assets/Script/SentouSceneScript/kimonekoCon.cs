using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kimonekoCon : MonoBehaviour
{
    //きもねこの攻撃範囲のbool
    bool atari;

    //きもねこの体力
    public int kimoneko = 1000;

    //きもねこの攻撃力
    int kougekiryoku = 2000;

    //きもねこの移動速度
    float sokudo = 0.55f;

    //猫の攻撃時間を設定
    float jikan = 0;
    bool kougeki = false;

    //猫のアニメータを設定
    bool kougekianime;
    float animekaisijikan = 4.00f;  //アニメ開始時間
    bool animekaisi = false;
    float aidanojikan = 0.35f;         //アニメ開始から攻撃までの時間
    float kougekijikan = 0;

    //猫の現在の位置を取得
    Vector2 nekoiti;

    //攻撃時の煙の微調整
    float tate = -1.0f;
    float yoko = -1.0f;

    //天使のプレハブを取得
    public GameObject tensiPre;
    public GameObject kemuri;

    // Start is called before the first frame update

    //きもねこのノックバック
    bool nockback = false;
    int kaisuu = 2;
    float nockbackjikan = 0.75f;
    int nockbacktairyoku = 500;

    //きもねこの消去
    bool kimonekosyoukyo = false;

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
        if (kimoneko < nockbacktairyoku && kaisuu % 2 == 0)
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
                if (kimonekosyoukyo == true)
                {
                    Destroy(gameObject);
                    GameObject go = Instantiate(tensiPre) as GameObject;
                    go.transform.position = nekoiti;
                }
            }
        }

        //猫の現在位置を取得
        nekoiti = GameObject.Find("KimonekoPre").transform.position;

        //猫の動きと攻撃の時間を合わせる
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
            //猫の待機と歩きアニメーション
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

        //きもねこを消去
        if (kimoneko < 0)
        {
            nockback = true;
            kimonekosyoukyo = true;
        }

        //きもねこの移動
        if (atari == false)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(-sokudo, 0);
        }
        if (atari == true)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        }
    }
    public void OnTriggerStay2D(Collider2D collision)
    {
        
        //敵城への攻撃判定
        if (collision.gameObject.name == "syatihoko")
        {
            atari = true;
            if (kougeki == true)
            {
                collision.transform.root.gameObject.GetComponent<syatihokoCon>().syatihoko -= kougekiryoku;
                kougeki = false;
                //攻撃時の煙演出を設定
                GameObject go = Instantiate(kemuri) as GameObject;
                go.transform.position = new Vector2(yoko + nekoiti.x, tate + nekoiti.y);
            }
            if (animekaisi == true)
            {
                kougekianime = true;
            }
        }
        //ワニへの攻撃判定
        if (collision.gameObject.name == "WaniAtarihantei")
        {
            atari = true;
            if (kougeki == true)
            {
                collision.transform.root.gameObject.GetComponent<waniCon>().wani -= kougekiryoku;
                kougeki = false;
                //攻撃時の煙演出を設定
                GameObject go = Instantiate(kemuri) as GameObject;
                go.transform.position = new Vector2(yoko + nekoiti.x, tate + nekoiti.y);
            }
            if (animekaisi == true)
            {
                kougekianime = true;
            }
        }
        //アザラシへの攻撃判定
        if (collision.gameObject.name == "AzarasiAtarihantei")
        {
            atari = true;
            if (kougeki == true)
            {
                collision.transform.root.gameObject.GetComponent<azarasiCon>().azarasi-= kougekiryoku;
                kougeki = false;
                //攻撃時の煙演出を設定
                GameObject go = Instantiate(kemuri) as GameObject;
                go.transform.position = new Vector2(yoko + nekoiti.x, tate + nekoiti.y);
            }
            if (animekaisi == true)
            {
                kougekianime = true;
            }
        }

    }
    //きもねこが攻撃をしないときは前進
    public void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.gameObject.name == "WaniAtarihantei")
            atari = false;
        if (collision.gameObject.name == "AzarasiAtarihantei")
            atari = false;
        if (collision.gameObject.name == "syatihoko")
            atari = false;
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tankunekoCon : MonoBehaviour
{
    //タンク猫の攻撃範囲     
    bool atari;

    //タンク猫の攻撃力
    int kougekiryoku = 10;

    //タンク猫の体力
    public int tankuneko = 3000;

    //タンク猫の速度
    float sokudo = 0.55f;

    //猫の攻撃時間を設定
    float jikan = 0;
    bool kougeki = false;

    //猫のアニメータを設定
    bool kougekianime;
    float animekaisijikan = 2.00f;  //アニメ開始時間
    bool animekaisi = false;
    float aidanojikan = 0.35f;         //アニメ開始から攻撃までの時間
    float kougekijikan = 0;

    //タンク猫のノックバック
    bool nockback = false;
    int kaisuu = 2;
    float nockbackjikan = 0.75f;
    int nockbacktairyoku = 500;

    //タンク猫の消去
    bool tankunekosyoukyo = false;

    //猫の現在の位置を取得
    Vector2 nekoiti;

    //攻撃時の煙の微調整
    float tate = 0f;
    float yoko = -1.0f;

    //天使のプレハブを取得
    public GameObject tensiPre;
    public GameObject kemuri;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //猫の現在位置を取得
        nekoiti = GameObject.Find("TankunekoPre").transform.position;

        //ノックバックを設定
        if (tankuneko < nockbacktairyoku && kaisuu % 2 == 0)
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
                if (tankunekosyoukyo == true)
                {
                    Destroy(gameObject);
                    GameObject go = Instantiate(tensiPre) as GameObject;
                    go.transform.position = nekoiti;
                }
            }
        }

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

        if (atari==true)
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        else
            GetComponent<Rigidbody2D>().velocity = new Vector2(-sokudo, 0);

        if (tankuneko < 0)
        {
            nockback = true;
            tankunekosyoukyo = true;

        }
    }
    public void OnTriggerStay2D(Collider2D collision)
    {
        //敵の城への攻撃判定
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
                collision.transform.root.gameObject.GetComponent<azarasiCon>().azarasi -= kougekiryoku;
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
    //タンク猫が攻撃をしないときは前進
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

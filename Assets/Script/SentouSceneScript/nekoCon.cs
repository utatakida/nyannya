using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nekoCon : MonoBehaviour
{
    //猫のコライダーが他のコライダーに接触したかのbool
    bool atari;

    //猫の体力
    public int neko = 1000;

    //猫の攻撃力
    int kougekiryoku = 100;

    //猫の移動速度
    float sokudo = 0.45f;
    //猫の攻撃時間を設定
    float kougekijikan=1.3f;
    float jikan;
    bool kougeki;

    //猫のアニメータ開始時間を設定
    float animejikan = 1.00f;

    //猫のノックバック
    bool nockback = false;
    int kaisuu=2;
    float nockbackjikan = 0.75f;
    int nockbacktairyoku = 500;

    //猫の消去
    bool nekosyoukyo = false;

    //アニメーターを取得
    Animator animator;
    bool kougekianime;
    bool kougekianimejikan;
    float kaisijikan = 0;

    //猫の現在の位置を取得
    Vector2 nekoiti;

    //天使のプレハブを取得
    public GameObject tensiPre;

    // Start is called before the first frame update
    void Start()
    {
        atari = false;

       
        jikan = 0;
        kougeki = false;

        this.animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //猫の現在位置を取得
        nekoiti = GameObject.Find("nekoPre").transform.position;


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
                jikan -= Time.deltaTime;
            }
            nockbackjikan -= Time.deltaTime;
            if (nockbackjikan < 0)
            {
                nockbackjikan = 0.75f;
                nockback = false;
                if (nekosyoukyo == true)
                {
                    Destroy(gameObject);
                    GameObject go = Instantiate(tensiPre) as GameObject;
                    go.transform.position = nekoiti;
                }
            }
        }
        //猫の攻撃時間を設定とアニメ時間を設定
        jikan += Time.deltaTime;
        if (jikan > kougekijikan)
        {
            kougeki = true;
            jikan =0;
        }
        if (jikan > animejikan)
        {
            kougekianimejikan = true;
        }
        //攻撃アニメーションの設定
        if (kougekianime == true)
        {
            kaisijikan += Time.deltaTime;
            if (kaisijikan >kougekijikan-animejikan)
            {
                kougekianime = false;
                kaisijikan = 0;
            }
            kougekianimejikan = false;
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
        //猫の移動速度
        if (atari == true)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        }
        else
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(-sokudo, 0);
        }

       

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
            if (kougekianimejikan == true)
            {
                kougekianime = true;
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
                kougekianime = true;
            }
            if (kougekianimejikan == true)
            {
                kougekianime = true;
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
                kougekianime = true;
            }
            if (kougekianimejikan == true)
            {
                kougekianime = true;
            }
        }

       
    }
    //猫が攻撃をしないときは前進
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

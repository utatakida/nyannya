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
    float sokudo = 0.55f;

    //タンク猫の攻撃時間
    float kougekijikan = 1;
    float jikan = 0;
    bool kougeki=false;

    //タンク猫のノックバック
    bool nockback = false;
    int kaisuu = 2;
    float nockbackjikan = 0.75f;
    int nockbacktairyoku = 500;

    //タンク猫の消去
    bool tankunekosyoukyo = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
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
                    Destroy(gameObject);
            }
        }
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
            nockback = true;
            tankunekosyoukyo = true;
            
        }


        if(atari==true)
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        else
            GetComponent<Rigidbody2D>().velocity = new Vector2(-sokudo, 0);
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

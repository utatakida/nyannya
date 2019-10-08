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
    int kougekiryoku = 100;

    //きもねこの移動速度
    float sokudo = 0.55f;

    //きもねこの攻撃時間
    float kougekijikan = 1;
    float jikan;
    bool kougeki;


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
                    Destroy(gameObject);
            }
        }

        //きもねこの攻撃時間を設定
        jikan += Time.deltaTime;
        if (jikan > kougekijikan)
        {
            kougeki = true;
            jikan = 0;
        }

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
                collision.transform.root.gameObject.GetComponent<azarasiCon>().azarasi-= kougekiryoku;
                kougeki = false;
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

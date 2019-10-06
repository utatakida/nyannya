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
            Destroy(gameObject);
        }

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
        if (collision.gameObject.name == "syatihoko")
        {
            atari = true;
            if (kougeki == true)
            {
                collision.transform.root.gameObject.GetComponent<syatihokoCon>().syatihoko -= kougekiryoku;
                kougeki = false;
            }
        }
        if (collision.gameObject.name == "WaniAtarihantei")
        {
            atari = true;
            if (kougeki == true)
            {
                collision.transform.root.gameObject.GetComponent<waniCon>().wani -= kougekiryoku;
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

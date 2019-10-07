using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class hatarakinekoButton : MonoBehaviour
{
    [SerializeField]
    private GameObject saiseisan;//再生産までの時間暗くするパネル

    int kaihoukin = 160;//解放時に働き猫の値段を上げる

    public int Lebel;//上限のレベル

    int zyoukin = 300;//解放時に上がる金額量

    public int kaisuu;//上限解放の数をここで決める

    public static  int hatarakin = 150;//働き猫の初期金額

    //解放時の判定
    public static bool kaihou = false;

    //解放時のテキストレベル
   public  GameObject LEVEL;

    //解放時の金額表示オブジェクト
     public GameObject kingakuText1;


    // Start is called before the first frame update
    void Start()
    {
        this.kingakuText1 = GameObject.Find("kingaku");
        this.LEVEL = GameObject.Find("LEVEL");
        saiseisan.SetActive(true);


      
    }

    // Update is called once per frame
    void FixdUpdate()
    {
        this.kingakuText1.GetComponent<TextMeshProUGUI>().text = hatarakin + "";//現在の金額を表示
        this.LEVEL.GetComponent<TextMeshProUGUI>().text = Lebel + "";//現在レベルを表示

        if(hatarakin>=kingakuCon.kingaku)
        {
            saiseisan.SetActive(true);

        }
    }
    public void OnClick()
    {
        if(kingakuCon.kingaku >= hatarakin)
        {
            saiseisan.SetActive(false);

            kingakuCon.kingaku -= hatarakin;
           kaihou = true;
            //上限解放処理
            if (kaihou = true)
            {
                kingakuCon.saidai += zyoukin;
                Lebel++;
                hatarakin += kaihoukin;
                this.kingakuText1.GetComponent<TextMeshProUGUI>().text = hatarakin + "";//現在の金額を表示
                this.LEVEL.GetComponent<TextMeshProUGUI>().text = Lebel + "";//現在レベルを表示
            }

        }
        
    }
}

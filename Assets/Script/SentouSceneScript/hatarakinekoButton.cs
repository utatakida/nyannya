using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class hatarakinekoButton : MonoBehaviour
{


    private Animator animator;

    public AudioClip derutoki;//キャラが出るときの音
    public AudioClip denaitoki;//キャラが出ないときの音

    public AudioSource SE;


    int kaihoukin = 160;//解放時に働き猫の値段を上げる

    int kaihouzyou = 160;//上がる量

    public int Lebel=1;//上限のレベル

    int zyoukin = 300;//解放時に上がる金額量

     int kaisuu=8;//上限解放の数をここで決める

   

    //解放時の判定
    public static bool kaihou = false;

    //解放時のテキストレベル
   public  GameObject LEVEL;

    public GameObject MAX;

    //解放時の金額表示オブジェクト
    public GameObject kingakuText1;



    // Start is called before the first frame update
    void Start()
    {
        this.kingakuText1 = GameObject.Find("kingaku");
        this.LEVEL = GameObject.Find("LEVEL");
        this.MAX = GameObject.Find("MAX");
        MAX.SetActive(false);


        animator = GetComponent<Animator>();


    }

    // Update is called once per frame
    void FixedUpdate()
    {
        this.kingakuText1.GetComponent<TextMeshProUGUI>().text = kaihoukin+"";//現在の金額を表示
        this.LEVEL.GetComponent<TextMeshProUGUI>().text = "LEVEL " + Lebel;//現在レベルを表示

        if (kingakuCon.kingaku >= kaihoukin)
        {
            animator.SetBool("ON", true);
        }else
        {
            animator.SetBool("ON", false);
        }
    }


    public void OnClick()
    {
        if(kingakuCon.kingaku >= kaihoukin&&Lebel < kaisuu)
        {

            SE.PlayOneShot(derutoki);

            Lebel++;

            kingakuCon.kingaku -= kaihoukin;

            kingakuCon.saidai += zyoukin;

            kaihou = true;

            kaihoukin += kaihouzyou;
          
            this.kingakuText1.GetComponent<TextMeshProUGUI>().text = kaihoukin + "";//現在の金額を表示
            this.LEVEL.GetComponent<TextMeshProUGUI>().text = "LEVEL " + Lebel ;//現在レベルを表示
          

        }
        else SE.PlayOneShot(denaitoki);

        if (Lebel ==kaisuu)
        {
            animator.SetBool("MAX", true);
            MAX.SetActive(true);
           kingakuText1.SetActive(false);
            this.MAX.GetComponent<TextMeshProUGUI>().text = "MAX";//現在レベルを表示
        }
        
    }
}

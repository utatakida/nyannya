using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class nekoButton : MonoBehaviour
{
    public static bool neko=false;

    [SerializeField]
    private GameObject saiseisan;//再生産までの時間暗くするパネル

    bool kanryouhan = true;//生産完了をみるためのもの

    public static bool nomaruseisanhantei = false;//ノーマル猫生産判定    
    public static bool nomarukanryou = false;

    
  public  Image UIobj;



    //ゲージ
    [SerializeField]
    private GameObject Blue;
    [SerializeField]
    private GameObject Black;

    [SerializeField]
    private GameObject kingaku;//金額テキスト
    [SerializeField]
    private GameObject kingaku2;//金額テキスト2

    public AudioClip derutoki;//キャラが出るときの音
    public AudioClip denaitoki;//キャラが出ないときの音
    public AudioClip mantan;//ゲージが満タンになったときの音


    public AudioSource SE;

    public static  float nekocountTime = 2.0f;//ノーマル猫生産時間

    void Start()
    {
       
        saiseisan.SetActive(true);

        Blue.SetActive(false);
        Black.SetActive(false);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //ノーマル猫の処理
        if (nomaruseisanhantei == true)
        {
            nomarukanryou = false;

            UIobj.fillAmount += 1.0f / nekocountTime * Time.deltaTime;
            if (UIobj.fillAmount == 1)
            {
                SE.PlayOneShot(mantan);
                UIobj.fillAmount = 0;
                nomaruseisanhantei = false;


                nomarukanryou = true;

                if (kingakuCon.kingaku >= kingakuCon.nekokin)
                {
                    saiseisan.SetActive(true);
                }

            }
        }


        if (nomarukanryou==true)
        {
            saiseisan.SetActive(false);
            kanryouhan = true;
            kingaku.SetActive(true);
            kingaku2.SetActive(true);

            Blue.SetActive(false);
            Black.SetActive(false);

        }

        if (kingakuCon.kingaku >= kingakuCon.nekokin &&kanryouhan == true)
        {
            saiseisan.SetActive(false);
        }else saiseisan.SetActive(true);

    }



    public void OnClick()
    {
        if (kingakuCon.kingaku >= kingakuCon.nekokin && kanryouhan == true)
        {
            SE.PlayOneShot(derutoki);

            neko = true;

            kingakuCon.kingaku -= kingakuCon.nekokin;

            saiseisan.SetActive(true);

            nomaruseisanhantei = true;

            kanryouhan = false;

            kingaku.SetActive(false);
            kingaku2.SetActive(false);

            Blue.SetActive(true);
            Black.SetActive(true);


        }
        else SE.PlayOneShot(denaitoki);
    }
   
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class kimonekoButton : MonoBehaviour
{
    public static bool kimoneko=false;

    [SerializeField]
    private GameObject saiseisan;//再生産までの時間暗くするパネル

    bool kanryouhan = true;//生産完了をみるためのもの

    public static bool nomarukimonekohan = false;//きもねこ生産判定 
    public static bool nomarukimokanryou = false;

    public  Image UIobj;

    [SerializeField]
    private GameObject kingaku;//金額テキスト
    [SerializeField]
    private GameObject kingaku2;//金額テキスト2


    //ゲージ
    [SerializeField]
    private GameObject Blue;
    [SerializeField]
    private GameObject Black;

    public AudioClip derutoki;//キャラが出るときの音
    public AudioClip denaitoki;//キャラが出ないときの音
    public  AudioClip mantan;//ゲージが満タンになったときの音

    public static  float kimocountTime = 3.5f;//きもねこ生産時間


    public AudioSource SE;
    // Start is called before the first frame update
    void Start()
    {
        saiseisan.SetActive(true);
        Blue.SetActive(false);
        Black.SetActive(false);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //きも猫の処理
        if (nomarukimonekohan == true)
        {
            nomarukimokanryou = false;

            UIobj.fillAmount += 1.0f / kimocountTime * Time.deltaTime;
            if (UIobj.fillAmount == 1)
            {
                SE.PlayOneShot(mantan);
                UIobj.fillAmount = 0;
                nomarukimonekohan = false;


                nomarukimokanryou = true;

            }
        }

        if (nomarukimokanryou == true)
        {
            saiseisan.SetActive(false);

            kanryouhan = true;
            kingaku.SetActive(true);
            kingaku2.SetActive(true);

            Blue.SetActive(false);
            Black.SetActive(false);

        }

        if (kingakuCon.kingaku >= kingakuCon.kimoneko &&kanryouhan == true)
        {
            saiseisan.SetActive(false);
        }
        else saiseisan.SetActive(true);

    }
    public void OnClick()
    {
        if (kingakuCon.kingaku >= kingakuCon.kimoneko &&kanryouhan == true)
        {

            SE.PlayOneShot(derutoki);

            kimoneko = true;

            kingakuCon.kingaku -= kingakuCon.kimoneko;
            nomarukimonekohan = true;

            saiseisan.SetActive(true);

            kanryouhan = false;

            kingaku.SetActive(false);
            kingaku2.SetActive(false);


            Blue.SetActive(true);
            Black.SetActive(true);
        }
        else SE.PlayOneShot(denaitoki);

    }
   
}

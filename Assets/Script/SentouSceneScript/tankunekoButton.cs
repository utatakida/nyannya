using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tankunekoButton : MonoBehaviour
{
    public static bool tankuneko = false;

    [SerializeField]
    private GameObject saiseisan;//再生産までの時間暗くするパネル

    bool kanryouhan = true;//生産完了をみるためのもの

    public  Image UI;
    public static bool nomarukabenekohan = false;//かべねこ生産判定    
    public static bool nomarukabekanryou = false;


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

    public static float kabecountTime = 2f;//かべねこ生産時間


    public AudioSource SE;
    // Start is called before the first frame update
    void Start()
    {
        saiseisan.SetActive(false);
        Blue.SetActive(false);
        Black.SetActive(false);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //たんく猫の処理
        if (nomarukabenekohan == true)
        {
            nomarukabekanryou = false;

            UI.fillAmount += 1.0f / kabecountTime * Time.deltaTime;
            if (UI.fillAmount == 1)
            {
                SE.PlayOneShot(mantan);
                UI.fillAmount = 0;
               nomarukabenekohan = false;


                nomarukabekanryou = true;

            }
        }

        if (nomarukabekanryou == true)
        {
            saiseisan.SetActive(false);

            kanryouhan = true;
            kingaku.SetActive(true);
            kingaku2.SetActive(true);

            Blue.SetActive(false);
            Black.SetActive(false);

        }
    }
    public void OnClick()
    {
        if (kingakuCon.kingaku >= kingakuCon.kabekin && kanryouhan == true)
        {

            SE.PlayOneShot(derutoki);

            tankuneko = true;

            kingakuCon.kingaku -= kingakuCon.kabekin;
            nomarukabenekohan = true;

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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class seisan : MonoBehaviour
{
    public static bool seisanhantei = false;//ノーマル猫生産判定     
    public GameObject Saiseisan;//青ゲージをオブジェクトとして取得する
   // public GameObject blackSaiseisan;//黒ゲージをオブジェクトとして取得する

    float Max=0.023f;//1秒を１時間としたノーマル猫の再生産時間

   float seiTime = 0;
    

    // Start is called before the first frame update
    void Start()
    {
        this.Saiseisan = GameObject.Find("青ゲージ");
       // Saiseisan.SetActive(false);
       // blackSaiseisan.SetActive(false);
    }

   // public void seiseiTime()
   // {
//
        //ImageというコンポーネントのfillAmountを取得して操作する
       // Saiseisan.GetComponent<Image>().fillAmount =Time.time;
   // }


    // Update is called once per frame
    void FixedUpdate()
    {

        seiTime += 0.001f;
        Saiseisan.GetComponent<Image>().fillAmount = seiTime;
        //ノーマル猫の処理
        if (seisanhantei == true)
        {
           // Saiseisan.SetActive(true);
           // blackSaiseisan.SetActive(true);

            Saiseisan.GetComponent<Image>().fillAmount = seiTime;
            if (seiTime == Max)
            {
                seisanhantei = false;
                seiTime = 0;
                //Saiseisan.SetActive(false);
               // blackSaiseisan.SetActive(false);
            }
        }
    }
}

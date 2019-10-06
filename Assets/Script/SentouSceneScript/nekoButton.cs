using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nekoButton : MonoBehaviour
{
    public static bool neko=false;

    [SerializeField]
    private GameObject saiseisan;//再生産までの時間暗くするパネル

    bool kanryouhan = true;//生産完了をみるためのもの

    [SerializeField]
    private GameObject kingaku;//金額テキスト
    [SerializeField]
    private GameObject kingaku2;//金額テキスト2

    public AudioClip derutoki;//キャラが出るときの音
    public AudioClip denaitoki;//キャラが出ないときの音
    public AudioClip mantan;//ゲージが満タンになったときの音

    public AudioSource SE;

    

    void Start()
    {
        saiseisan.SetActive(false);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(seisan.kanryou==true)
        {
            saiseisan.SetActive(false);
            kanryouhan = true;
            kingaku.SetActive(true);
            kingaku2.SetActive(true);
         
        }
    }



    public void OnClick()
    {
        if (kingakuCon.kingaku >= kingakuCon.nekokin && kanryouhan == true)
        {
            SE.PlayOneShot(derutoki);

            neko = true;

            kingakuCon.kingaku -= kingakuCon.nekokin;

            saiseisan.SetActive(true);

            seisan.seisanhantei = true;

            kanryouhan = false;

            kingaku.SetActive(false);
            kingaku2.SetActive(false);


        }
        else SE.PlayOneShot(denaitoki);
    }
   
}

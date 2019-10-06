using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class seisan : MonoBehaviour
{
    public static bool seisanhantei = false;//ノーマル猫生産判定    
    public static bool kanryou = false;

    public static bool kabenekohan = false;//かべねこ生産判定    
    public static bool kabekanryou = false;

    public static bool kimonekohan = false;//きもねこ生産判定 
    public static bool kimokanryou = false;


    public Image UIobj;

    public float nekocountTime = 3.0f;//ノーマル猫生産時間

    public float kabecountTime = 3.0f;//かべねこ生産時間

    public float kimocountTime = 3.0f;//きもねこ生産時間

    //ゲージ
    [SerializeField]
    private GameObject Blue;
    [SerializeField]
    private GameObject Black;


    public AudioClip mantan;//ゲージが満タンになったときの音

    public AudioSource SE;

    void Start()
    {
        Blue.SetActive(false);
        Black.SetActive(false);
    }

  
    void FixedUpdate()
    {
        //ノーマル猫の処理
        if (seisanhantei == true)
        {
            kanryou = false;
            Blue.SetActive(true);
            Black.SetActive(true);
            UIobj.fillAmount += 1.0f / nekocountTime * Time.deltaTime;
            if (UIobj.fillAmount == 1)
            {
                SE.PlayOneShot(mantan);
                UIobj.fillAmount = 0;
                seisanhantei = false;
                Blue.SetActive(false);
                Black.SetActive(false);

                kanryou = true;

            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class kingakuCon : MonoBehaviour
{
    GameObject kingakuText;
    public static float kingaku;//現在の金額

    
   

    public static int saidai;//金額の最大値

    public static int nekokin = 75;//ねこの値段


    public static int kabekin = 150;//かべねこの値段

    public static int kimoneko = 600;//きもねこの値段

    public static int kyosin = 1300;//巨神猫の値段


    // Start is called before the first frame update
    void Start()
    {
        this.kingakuText = GameObject.Find("kingakuText");
        kingaku = 0;//金額を0から始める
        saidai = 800;//金額の最大値はここで変更
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        

        //金額の骨組み
        if (kingaku < saidai)//金額の最大値がsaidaiの値
            kingaku += Time.deltaTime * 100 ;//1秒間に100円ずつ増える
        this.kingakuText.GetComponent<TextMeshProUGUI>().text = ((int)kingaku) + "/" + saidai;//現在の金額と最大値の金額をTextに表示


    }
}

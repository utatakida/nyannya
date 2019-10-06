using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class kingakuCon : MonoBehaviour
{
    GameObject kingakuText;
    public static float kingaku;//現在の金額
    int saidai;//金額の最大値

    public static int nekokin = 75;//ねこの値段


    public static int kabekin = 150;//かべねこの値段

    public static int kimoneko = 600;//きもねこの値段


    int jyougen; //上限解放
    int kaisuu;//上限解放の数をここで決める
    bool j;//解放スクリプトの値をこいつに代入
    // Start is called before the first frame update
    void Start()
    {
        this.kingakuText = GameObject.Find("kingakuText");
        kingaku = 0;//金額を0から始める
        saidai = 1000;//金額の最大値はここで変更
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //金額の骨組み
        if (kingaku < saidai - 0.1f)//金額の最大値がsaidaiの値
            kingaku += Time.deltaTime * 50 + 1f;//1秒間に100円ずつ増える
        this.kingakuText.GetComponent<TextMeshProUGUI>().text = ((int)kingaku) + "/" + saidai;//現在の金額と最大値の金額をTextに表示
    }
}

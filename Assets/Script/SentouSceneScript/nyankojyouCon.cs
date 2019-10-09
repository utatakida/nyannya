using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class nyankojyouCon : MonoBehaviour
{
    public int nyankojyou = 5000;
    GameObject nyankojyoutairyoku;
  

    //HPがゼロになったかを調べる
    public static int Lose = 0;
    public static bool lo = false;
    // Start is called before the first frame update
    void Start()
    {
        nyankojyoutairyoku = GameObject.Find("nyankojyoutairyoku");
       
    }

    // Update is called once per frame
    void Update()
    {
        if (nyankojyou < 0)
        {
            Lose = 1;
            nyankojyou =0;
            lo = true;

        }

        //にゃんこ城の体力を表示
        nyankojyoutairyoku.GetComponent<TextMeshProUGUI>().text = nyankojyou + "/" + "5000";
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class nyankojyouCon : MonoBehaviour
{
    public int nyankojyou = 5000;
    GameObject nyankojyoutairyoku;

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
            Debug.Log("ゲームオーバー");
        }

        //にゃんこ城の体力を表示
        nyankojyoutairyoku.GetComponent<Text>().text = nyankojyou + "/" + "5000";
    }
}

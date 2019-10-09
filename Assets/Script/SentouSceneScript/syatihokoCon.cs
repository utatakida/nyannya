using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class syatihokoCon : MonoBehaviour
{
    public int syatihoko=5000;
    GameObject syatihokotairyoku;



 
    public AudioClip wini;
    public AudioSource SE;
    bool sta = false;
    

    //HPがゼロになったかを調べる
    public static int win =0;

    // Start is called before the first frame update
    void Start()
    {
        syatihokotairyoku = GameObject.Find("syatihokotairyoku");

      

    }

    // Update is called once per frame
    void Update()
    {
        //クリア時の処理
        if (syatihoko < 0)
        {
           
            win = 1;
            syatihoko = 0;
            sta = true;
           
        }
        if(win==1&&sta==true)
        {
            SE.PlayOneShot(wini);
            sta = false;
        }


        //しゃちほこの体力を表示
        syatihokotairyoku.GetComponent<TextMeshProUGUI>().text = syatihoko + "/" + "5000";


    }
}

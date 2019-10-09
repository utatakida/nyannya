using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class syatihokoCon : MonoBehaviour
{
    public int syatihoko=5000;
    GameObject syatihokotairyoku;
    

    [SerializeField]
    private AudioSource audios;
    public AudioClip cler;

    //HPがゼロになったかを調べる
    public static bool win = false;

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
            win = true;
            syatihoko = 0;
           

        }
       
        //しゃちほこの体力を表示
        syatihokotairyoku.GetComponent<TextMeshProUGUI>().text = syatihoko + "/" + "5000";


    }
}

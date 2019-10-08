using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class syatihokoCon : MonoBehaviour
{
    public int syatihoko=5000;
    GameObject syatihokotairyoku;
    // Start is called before the first frame update
    void Start()
    {
        syatihokotairyoku = GameObject.Find("syatihokotairyoku");
    }

    // Update is called once per frame
    void Update()
    {

        if (syatihoko < 0)
        {
            Debug.Log("ゲームクリア");
            syatihoko = 0;
        }
        //しゃちほこの体力を表示
        syatihokotairyoku.GetComponent<TextMeshProUGUI>().text = syatihoko + "/" + "5000";


    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tankunekoGene : MonoBehaviour
{
    bool tankuneko;
    public GameObject tankunekoPre;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        tankuneko = tankunekoButton.tankuneko;//ゲーム全体で管理しているtankunekoBtton.tankunekoを取得

        if (tankuneko == true)//タンク猫の出撃コード
        {
            GameObject go = Instantiate(tankunekoPre) as GameObject;
            go.name = tankunekoPre.name;
            go.transform.position = new Vector2(6, -1);

            tankunekoButton.tankuneko = false;
        }
    }
}

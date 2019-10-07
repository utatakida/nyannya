using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tankunekoGene : MonoBehaviour
{
    bool tankuneko;
    public GameObject tankunekoPre;

    int randamu;
    float syousuu=0;
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
            //タンク猫の位置とレイヤーを合わせる
            randamu = Random.Range(1, 5);
            for (int i = 1; i <= 4; i++)
            {
                if (randamu == i)
                {

                    for (int j = 1; j <= i; j++)
                    {
                        syousuu += -0.17f;
                    }
                }
            }

            GameObject go = Instantiate(tankunekoPre) as GameObject;
            go.name = tankunekoPre.name;
            go.transform.position = new Vector2(6, -1+syousuu);
            go.transform.GetComponent<SpriteRenderer>().sortingOrder = randamu;
            syousuu = 0;

            tankunekoButton.tankuneko = false;
        }
    }
}

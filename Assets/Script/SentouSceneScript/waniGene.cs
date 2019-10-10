using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waniGene : MonoBehaviour
{
    public GameObject waniPre;

    float jikan;

    //ワニの出現位置とレイヤーを合わせる
    int randamu;
    float syousuu=0;

    //ワニ出撃可能bool
    bool wanigo = false;
    float syutugekijikan=0;
   
    // Start is called before the first frame update
    void Start()
    {
        jikan = 0;
    }

    // Update is called once per frame
    void Update()
    {
       

        jikan += Time.deltaTime;


        int a = GameObject.Find("syatihoko").GetComponent<syatihokoCon>().syatihoko;

        if (a == 10000)
        {
            syutugekijikan = 5;
        }
        else if (a < 10000 && 5000 < a)
        {
            syutugekijikan = 2;
        }
        else if (a < 5000 && 2000 < a)
        {
            syutugekijikan = 0.9f;
        }
        else
        {
            syutugekijikan = 1.5f;
        }

        //ワニの出陣コード
        if (jikan>syutugekijikan&&syatihokoCon.win<1)
        {
            //ワニの位置とレイヤーを合わせる
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

            GameObject go = Instantiate(waniPre) as GameObject;
            go.name = waniPre.name;
            go.transform.GetComponent<SpriteRenderer>().sortingOrder = randamu;
            go.transform.position = new Vector3(-6,-1.1f+syousuu,0);
            jikan = 0;
            syousuu = 0;
            wanigo = false;
        }
    }
}

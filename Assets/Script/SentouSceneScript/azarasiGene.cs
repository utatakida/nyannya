using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class azarasiGene : MonoBehaviour
{
    public GameObject azarasiPre;

    float jikan;

    //アザラシの出現位置とレイヤーを合わせる
    int randamu;
    float syousuu = 0;

    

    //アザラシの出撃可能をbool型で作成
    float syutugekijikan = 0;

    // Start is called before the first frame update
    void Start()
    {
        jikan = 0;
    }

    // Update is called once per frame
    void Update()
    {
        int a = GameObject.Find("syatihoko").GetComponent<syatihokoCon>().syatihoko;

        if (a == 10000)
        {
            syutugekijikan = 12;
        }
        else if (a < 10000 && 5000 < a)
        {
            syutugekijikan = 10;
        }
        else if (a < 5000 && 2000 < a)
        {
            syutugekijikan = 15;
        }
        else
        {
            syutugekijikan = 3;
        }

        jikan += Time.deltaTime;
        //アザラシの出陣コード
        if (jikan > syutugekijikan && syatihokoCon.win <1)
        {
            //アザラシの位置とレイヤーを合わせる
            randamu = Random.Range(1, 5);
            for (int i = 1; i <= 4; i++)
            {
                if (randamu == i)
                {

                    for (int j = 1; j <= i; j++)
                    {
                        syousuu += -0.15f;
                    }
                }
            }

            GameObject go = Instantiate(azarasiPre) as GameObject;
            go.name = azarasiPre.name;
            go.transform.GetComponent<SpriteRenderer>().sortingOrder = randamu;
            go.transform.position = new Vector3(-6, -0.9f + syousuu, 0);
            jikan = 0;
            syousuu = 0;

        }
    }
}


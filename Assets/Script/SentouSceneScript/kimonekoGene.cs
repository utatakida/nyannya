using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kimonekoGene : MonoBehaviour
{
    bool kimoneko;
    public GameObject kimonekoPre;

    int randamu;
    float syousuu=0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        kimoneko = kimonekoButton.kimoneko;
        if (kimoneko == true)
        {
            //きもねこの位置とレイヤーを合わせる
            randamu = Random.Range(1, 5);
            for (int i = 1; i <= 4; i++)
            {
                if (randamu == i)
                {

                    for (int j = 1; j <= i; j++)
                    {
                        syousuu += -0.1f;
                    }
                }
            }

            GameObject go = Instantiate(kimonekoPre) as GameObject;
            go.name = kimonekoPre.name;
            go.transform.position = new Vector2(5f,0.15f+syousuu);
            go.transform.GetComponent<SpriteRenderer>().sortingOrder = randamu;
            syousuu = 0;
            kimonekoButton.kimoneko = false;
        }
    }
}

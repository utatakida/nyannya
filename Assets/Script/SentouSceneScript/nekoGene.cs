using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nekoGene : MonoBehaviour
{

    public GameObject NekoPre;
    bool neko;

    int randamu;
    float syousuu=0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        neko = nekoButton.neko;
        if (neko == true)
        {

            //猫の位置とレイヤーを合わせる
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

            GameObject go = Instantiate(NekoPre) as GameObject;
            go.name = NekoPre.name;//猫の名前を変更
            go.transform.GetComponent<SpriteRenderer>().sortingOrder = randamu;//レイヤーを変更         
            go.transform.position = new Vector3(6,-1.57f+syousuu,0);//猫の出現位置を変更
            syousuu = 0;

            nekoButton.neko = false;
        }
    }
}

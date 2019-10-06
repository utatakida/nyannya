using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tankunekoButton : MonoBehaviour
{
    public static bool tankuneko = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnClick()
    {
        if (kingakuCon.kingaku >= kingakuCon.kabekin)
        {

            tankuneko = true;

            kingakuCon.kingaku -= kingakuCon.kabekin;

            seisan.kabenekohan = true;

        }
    }
   
}

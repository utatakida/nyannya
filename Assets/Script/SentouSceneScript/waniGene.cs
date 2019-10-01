using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waniGene : MonoBehaviour
{
    public GameObject waniPre;

    float jikan;
    // Start is called before the first frame update
    void Start()
    {
        jikan = 0;
    }

    // Update is called once per frame
    void Update()
    {
        jikan += Time.deltaTime;
        if (jikan>3.0f) //敵ワニの出陣コード
        { 
            GameObject go = Instantiate(waniPre) as GameObject;
            go.name = waniPre.name;
            go.transform.position = new Vector2(-6, -1.5f);

            jikan = 0;
        }
    }
}

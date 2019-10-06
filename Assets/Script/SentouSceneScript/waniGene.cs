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
        if (jikan>3f) //敵ワニの出陣コード
        {
            GameObject go = Instantiate(waniPre) as GameObject;
            go.name = waniPre.name;
            go.transform.position = new Vector3(-6, Random.Range(-1.2f, -1.5f), Random.Range(1, 100));

          

                jikan = 0;
           
        }
    }
}

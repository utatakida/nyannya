using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kimonekoGene : MonoBehaviour
{
    bool kimoneko;
    public GameObject kimonekoPre;
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
            GameObject go = Instantiate(kimonekoPre) as GameObject;
            go.name = kimonekoPre.name;
            go.transform.position = new Vector3(5, Random.Range(0.35f,0.45f), Random.Range(1, 100));

            kimonekoButton.kimoneko = false;
        }
    }
}

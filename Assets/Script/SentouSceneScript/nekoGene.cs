using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nekoGene : MonoBehaviour
{
    public GameObject NekoPre;
    bool neko;
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
            GameObject go = Instantiate(NekoPre) as GameObject;
            go.name = NekoPre.name;
            go.transform.position = new Vector2(6, -1.5f);

            nekoButton.neko = false;
        }
    }
}

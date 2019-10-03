using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nekoButton : MonoBehaviour
{
    public static bool neko=false;
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
        neko = true;
    }
    public static bool getNeko()
    {
        return neko;
    }
}

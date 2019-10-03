using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kimonekoButton : MonoBehaviour
{
    public static bool kimoneko=false;
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
        kimoneko = true;
        
    }
    public static bool getKimoneko()
    {
        return kimoneko;
    }
}

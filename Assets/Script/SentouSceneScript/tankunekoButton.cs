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
        tankuneko = true;
    }
    public static bool getTankuneko()
    {
        return tankuneko;
    }
}

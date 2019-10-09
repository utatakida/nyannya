using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutSceneCon : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (OkButtonCon.outhantei == true)
        {
            transform.localPosition = transform.localPosition += new Vector3(-20, 0, 0);
        }
    }
}

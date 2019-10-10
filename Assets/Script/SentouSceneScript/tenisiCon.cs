using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tenisiCon : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, 0.005f, 0);
        if(transform.position.y > 4.0f)
        {
            Destroy(gameObject);
        }
    }
}

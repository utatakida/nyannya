using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kougekikemuriCon : MonoBehaviour
{
    float jikan = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        jikan += Time.deltaTime;
        if (jikan > 0.14f)
        {
            Destroy(gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCon : MonoBehaviour
{

    

    [SerializeField, Header("速さ")]
    float speed =2; //特定の位置まで行く速さ


    // Start is called before the first frame update
    void Start()
    {
       

    }

    // Update is called once per frame
    void FixdUpdate()
    {
        if (syatihokoCon.win == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(0,0,0), speed*Time.deltaTime);
        }


    }
    
}

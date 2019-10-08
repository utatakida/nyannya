using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMCon : MonoBehaviour
{



    [SerializeField]
    private AudioSource audios;
   
   



    // Start is called before the first frame update
    void Start()
    {
        audios.Play();
      
    }

    // Update is called once per frame
    void Update()
    {
        if(syatihokoCon.win ==true)
        {
            audios.Stop();

         
        }


    }
}

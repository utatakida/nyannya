using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMCon : MonoBehaviour
{


    public AudioClip BGM;
    public AudioClip Win;

    public AudioSource audios;
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
            audios.PlayOneShot(Win);

         
        }


    }
}

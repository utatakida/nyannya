using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinBGMCon : MonoBehaviour
{
  
    public AudioSource audioSource;

    public AudioClip derutoki;
    public AudioClip denaitoki;
    public AudioClip mantan;

    public AudioSource BGM;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
       BGM = GetComponent<AudioSource>();
        BGM.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (syatihokoCon.win==1&&syatihokoCon.ss==true)
        {
            
            syatihokoCon.ss = false;
            audioSource.PlayOneShot(derutoki);
            BGM.Stop();

        }
        if(nyankojyouCon.Lose==1&&nyankojyouCon.lo==true)
        {
            nyankojyouCon.lo = false;
            audioSource.PlayOneShot(denaitoki);
            BGM.Stop();
        }

    }
}

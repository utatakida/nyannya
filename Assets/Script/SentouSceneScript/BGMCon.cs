using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMCon : MonoBehaviour
{
    public AudioSource backBGM;
    // Start is called before the first frame update
    void Start()
    {
        backBGM.Play();
    }

    // Update is called once per frame
    void Update()
    {
      if(syatihokoCon.win==1)
        {
            backBGM.Stop();

        }
    }
}

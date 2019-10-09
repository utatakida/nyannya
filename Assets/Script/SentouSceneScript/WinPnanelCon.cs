using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinPnanelCon : MonoBehaviour
{

    [SerializeField]
    private GameObject okbutton;

   
    IEnumerator Win()
    {
        yield return new WaitForSeconds(2.0f);
        okbutton.SetActive(true);
    }


    // Start is called before the first frame update
    void Start()
    {
      okbutton.SetActive(false);
       

    }

    // Update is called once per frame
    void Update()
    {

        if (syatihokoCon.win == 1)
        {
           
         if (transform.localPosition.x < 0)
            {
                transform.localPosition = transform.localPosition += new Vector3(10, 0, 0);
           }
            StartCoroutine("Win");
           

        }
    }
    
   

   

}


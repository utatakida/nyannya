using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LosePanelCon : MonoBehaviour
{

    [SerializeField]
    private GameObject okbutton;
  

    IEnumerator Win()
    {
        yield return new WaitForSeconds(5.0f);
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
        if (nyankojyouCon.Lose == 1)
        {
           

                if (transform.localPosition.y > 0)
                {
                    transform.localPosition = transform.localPosition += new Vector3(0, -3, 0);
                }
          
                StartCoroutine("Win");


        }
    }
}

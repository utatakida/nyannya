using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OkButtonCon : MonoBehaviour
{

   

    IEnumerator Win()
    {
        yield return new WaitForSeconds(1.0f);
       
        SceneManager.LoadScene("nekokitiScene");//カッコ内のシーンに移動
        syatihokoCon.win = 0;
        nyankojyouCon.Lose =0;
        losehantei = false;
        outhantei = false;
    }
    public static  bool outhantei=false;
    public static bool losehantei = false;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
      

    }
    public void OnClick()
    {
        if(syatihokoCon.win==1)
        {
            outhantei = true;

            StartCoroutine("Win");
           
        }
       if(nyankojyouCon.Lose==1)
        {
            losehantei = true;
            StartCoroutine("Win");
         
        }
    }
  
}

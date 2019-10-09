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
    }
    public static  bool outhantei=false;
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
        outhantei = true;
       
        StartCoroutine("Win");

    }
  
}

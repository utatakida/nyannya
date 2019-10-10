using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class kaisiButtonCon : MonoBehaviour
{

    public void OnClick()
    {
        SceneManager.LoadScene("sentouScene");//カッコ内のシーンに移動
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
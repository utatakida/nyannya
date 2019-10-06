using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseCon : MonoBehaviour
{
    //　バックボタン
    [SerializeField]
    private GameObject reStartButton;
    [SerializeField]
    //戦闘離脱ボタン
    private GameObject ridatuButton;
    //　最終確認パネル
    [SerializeField]
    private GameObject kakuPanel;
    //バックパネル
    [SerializeField]
    private GameObject backPanel;
    //オプションパネル
    [SerializeField]
    private GameObject OPPanel;


    public void OnClick()
    {
        Time.timeScale = 0f;
        backPanel.SetActive(true);
        OPPanel.SetActive(true);
        kakuPanel.SetActive(false);
        reStartButton.SetActive(true);
        ridatuButton.SetActive(true);

    }
    //戻るときの処理
    public void OnClick2()
    {
        Time.timeScale = 1f;
        backPanel.SetActive(false);
        OPPanel.SetActive(false);
        kakuPanel.SetActive(false);
        reStartButton.SetActive(false);
        ridatuButton.SetActive(false);

    }
    //戦闘離脱した際の処理
    /*
    public void OnClick3()
    {
      
    }
    */

   
}

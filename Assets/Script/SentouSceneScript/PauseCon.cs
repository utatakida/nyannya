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
  
    //バックパネル
    [SerializeField]
    private GameObject backPanel;
    //オプションパネル
    [SerializeField]
    private GameObject OPPanel;

    //　最終確認バックパネル
    [SerializeField]
    private GameObject kakubackPanel;
    //　最終確認パネル
    [SerializeField]
    private GameObject kakuPanel;

    //　はいボタン
    [SerializeField]
    private GameObject yesButton;
    [SerializeField]
    //いいえボタン
    private GameObject noButton;



    

    //中断ボタンを押したときの処理
    public void OnClick()
    {
        Time.timeScale = 0f;
        backPanel.SetActive(true);
        OPPanel.SetActive(true);
        kakuPanel.SetActive(false);
        reStartButton.SetActive(true);
        ridatuButton.SetActive(true);


        kakuPanel.SetActive(false);
        kakubackPanel.SetActive(false);
        yesButton.SetActive(false);
        noButton.SetActive(false);

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

        kakuPanel.SetActive(false);
        kakubackPanel.SetActive(false);
        yesButton.SetActive(false);
        noButton.SetActive(false);

    }
    //戦闘離脱した際の処理
    public void OnClick3()
    {
     
        kakuPanel.SetActive(true);
        kakubackPanel.SetActive(true);
        yesButton.SetActive(true);
        noButton.SetActive(true);

    }

    //最終確認の処理 yesの時
    public void OnClick4()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("nekokitiScene");//カッコ内のシーンに移動

    }

    //最終確認の処理 noの時
    public void OnClick5()
    {

        backPanel.SetActive(true);
        OPPanel.SetActive(true);
        reStartButton.SetActive(true);
        ridatuButton.SetActive(true);


        kakuPanel.SetActive(false);
        kakubackPanel.SetActive(false);
        yesButton.SetActive(false);
        noButton.SetActive(false);
    }

}

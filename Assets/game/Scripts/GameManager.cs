using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Utils;

public class GameManager : Soliton<GameManager>
{
    public CommodityManager commodityManager;

    public static void LOAD_MAIN_MENU() {
        SceneManager.LoadScene("MainMenuScene");
    }

    public static void LOAD_CATALOG_SCENE() {
        SceneManager.LoadScene("CatalogScene");
    }

    public static void LOAD_VIDEO_SCENE() {
        //        SceneManager.LoadScene("VideoScene");
        Application.OpenURL("https://www.youtube.com/");
    }

    public static void LOAD_ABOUT_COMPANY_SCENE() {
        SceneManager.LoadScene("AboutCompanyScene");
    }

    public static void LOAD_SEND_INFO_SCENE() {
        SceneManager.LoadScene("SendInfo");
    }
}

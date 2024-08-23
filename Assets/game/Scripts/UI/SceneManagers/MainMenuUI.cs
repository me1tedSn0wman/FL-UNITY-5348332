using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour
{
    [Header("Buttons (Set in Inspector)")]
    [SerializeField] private Button button_Catalog;
    [SerializeField] private Button button_AboutCompany;
    [SerializeField] private Button button_Video;
    [SerializeField] private Button button_SendInformation;

    public void Start()
    {
        button_Catalog.onClick.AddListener(() =>
        {
            GameManager.LOAD_CATALOG_SCENE();
        });

        button_AboutCompany.onClick.AddListener(() =>
        {
            GameManager.LOAD_ABOUT_COMPANY_SCENE();
        });

        button_Video.onClick.AddListener(() =>
        {
            GameManager.LOAD_VIDEO_SCENE();
        });

        button_SendInformation.onClick.AddListener(() =>
        {
            GameManager.LOAD_SEND_INFO_SCENE();
        });
    }

}

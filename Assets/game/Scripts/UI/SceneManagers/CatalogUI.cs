using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CatalogUI : MonoBehaviour
{
    [SerializeField] private Button button_MoveLeft;
    [SerializeField] private Button button_MoveRight;

    [SerializeField] private TextMeshProUGUI text_selectedTitle;
    [SerializeField] private Button button_SelectCommodity;

    [SerializeField] private Transform transform_catalog;
    [SerializeField] private Transform transform_selectedCatalog;

    [SerializeField] private TextMeshProUGUI text_DescTitle;
    [SerializeField] private TextMeshProUGUI text_DescCategory;
    [SerializeField] private TextMeshProUGUI text_DescMark;
    [SerializeField] private TextMeshProUGUI text_DescDescription;
    [SerializeField] private Button button_BackToCatalog;

    [SerializeField] private SimpleRotateControl simpleRotateControl;

    [SerializeField] private Button button_BackToMainMenu;

    public CatalogManager catalogManager;

    int selectedId = 0;

    public void Start()
    {
        button_MoveLeft.onClick.AddListener(() =>
        {
            if (selectedId <= 0) return;
            catalogManager.MoveAllBy(1);
            selectedId -= 1;
            text_selectedTitle.text = catalogManager.listOfCommodities[selectedId].title;
        });
        button_MoveRight.onClick.AddListener(() =>
        {
            if (selectedId >= catalogManager.listOfCommodities.Count-1) return;
            catalogManager.MoveAllBy(-1);
            selectedId += 1;
            text_selectedTitle.text = catalogManager.listOfCommodities[selectedId].title;
        });

        button_SelectCommodity.onClick.AddListener(() =>
        {
            catalogManager.SelectCommodity(selectedId);
            transform_selectedCatalog.gameObject.SetActive(true);
            transform_catalog.gameObject.SetActive(false);
            SetUpCommodity();
            simpleRotateControl.transform_selectedGO = catalogManager.listOfCommodities[selectedId].transform;
        });

        button_BackToCatalog.onClick.AddListener(() =>
        {
            transform_selectedCatalog.gameObject.SetActive(false);
            transform_catalog.gameObject.SetActive(true);
            simpleRotateControl.transform_selectedGO = null;
            catalogManager.UnselectCommodity(selectedId);
        });

        text_selectedTitle.text = catalogManager.listOfCommodities[selectedId].title;
        transform_selectedCatalog.gameObject.SetActive(false);
        transform_catalog.gameObject.SetActive(true);

        button_BackToMainMenu.onClick.AddListener(() =>
        {
            GameManager.LOAD_MAIN_MENU();
        });
    }

    public void SetUpCommodity() {
        text_DescTitle.text = catalogManager.listOfCommodities[selectedId].title;
        text_DescCategory.text = catalogManager.listOfCommodities[selectedId].category;
        text_DescMark.text = catalogManager.listOfCommodities[selectedId].mark;
        text_DescDescription.text = catalogManager.listOfCommodities[selectedId].description;
    }
}

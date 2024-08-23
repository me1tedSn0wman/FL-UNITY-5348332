using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CatalogManager : MonoBehaviour
{

    public Transform anchorForCommodities;
    public List<Commodity> listOfCommodities;

    public CommodityManager commodityManager;

    public Vector3 startPosition;
    public Vector3 stepBetweenGameObjects;

    public CatalogUI catalogUI;

    public void Start()
    {
        listOfCommodities = new List<Commodity>();
        commodityManager = GameManager.Instance.commodityManager;
        CreateCatalog();
        catalogUI.catalogManager= this;
    }

    public void CreateCatalog() {
        for (int i = 0; i < commodityManager.listOfCommodities.Length; i++) {
            GameObject tCommGO = Instantiate(commodityManager.listOfCommodities[i].gameObject_prefab);
            Commodity tComm = tCommGO.GetComponent<Commodity>();

            tComm.SetUpCommodity(commodityManager.listOfCommodities[i]);
            tCommGO.transform.SetParent(anchorForCommodities);
            tCommGO.transform.position = startPosition + i* stepBetweenGameObjects;
            listOfCommodities.Add(tComm);
        }
    }

    public void MoveAllBy(float step) {
        for (int i = 0; i < listOfCommodities.Count; i++) {
            listOfCommodities[i].gameObject.transform.DOMove(stepBetweenGameObjects * step, 0.2f).SetRelative();
        }
    }


    public void SelectCommodity(int id)
    {
        for (int i = 0; i < listOfCommodities.Count; i++) {
            if (i != id)
            {
                listOfCommodities[i].gameObject.SetActive(false);
            }
        }
        listOfCommodities[id].isSelected = true;
    }

    public void UnselectCommodity(int id)
    {
        for (int i = 0; i < listOfCommodities.Count; i++)
        {
            if (i != id)
            {
                listOfCommodities[i].gameObject.SetActive(true);
            }
        }
        listOfCommodities[id].isSelected = false;
    }
}

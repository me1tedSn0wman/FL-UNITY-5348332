using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommodityManager : MonoBehaviour
{
    public CommodityDef[] listOfCommodities;

    public CommodityDef GetCommodity(int id) {
        for (int i = 0; i < listOfCommodities.Length; i++) {
            if (listOfCommodities[i].id == id) { 
                return listOfCommodities[i];
            }
        }
        return null;
    }
}

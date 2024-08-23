using System;
using UnityEngine;

[Serializable]
public class CommodityDefDesc {
    public Lang lang;
    public string title;
    public string category;
    public string mark;
    public string description;
}

[CreateAssetMenu(fileName = "Commodity", menuName = "Scriptable Objects/Commodity", order = 1)]
public class CommodityDef : ScriptableObject
{
    public int id;
    public CommodityDefDesc[] commodityDesc;
    public GameObject gameObject_prefab;
    
    public CommodityDefDesc GetCommodityDesc(Lang lang) {
        for (int i = 0; i < commodityDesc.Length; i++) {
            if (commodityDesc[i].lang == lang) {
                return commodityDesc[i];
            }
        }
        return null;
    }
}

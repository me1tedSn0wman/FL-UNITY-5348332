using UnityEngine;

public class Commodity : MonoBehaviour
{
    public int id;
    public string title;
    public string category;
    public string mark;
    public string description;
    public float RotatingSpeed = 10f;

    public bool isSelected = false;

    public void Update() {
        Rotate();
    }

    public void SetUpCommodity(CommodityDef comm) { 
        id= comm.id;
        title = comm.GetCommodityDesc(Lang.Rus).title;
        category = comm.GetCommodityDesc(Lang.Rus).category;
        mark = comm.GetCommodityDesc(Lang.Rus).mark;
        description = comm.GetCommodityDesc(Lang.Rus).description;
    }

    public void Rotate() {
        if (isSelected) return;
        transform.Rotate(Vector3.up, Time.deltaTime * RotatingSpeed);
    }
}

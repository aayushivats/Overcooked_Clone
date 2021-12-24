using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CuttingStation : Station, IDrop, ICut, IPickup
{
    public Slider timerUI;

    // Start is called before the first frame update
    void Start()
    {
        timerUI = GetComponentInChildren<Slider>();
        timerUI.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public override bool DoPickupDrop(Transform player)
    {        
        if (isOccupied)
        {
            if (itemOnStation.GetComponent<Vegetables>().veggieState == Vegetables.VegetablesState.partiallyCut  )
            {
                return false;
            }

            PickupItem(player);
        }
        else
        {
            DropItem(player);
            
        }

        return true;
    }

    public void DropItem(Transform player)
    {
        GameObject temp = IStationHelper.DropItem(this,player);

        if(temp)
        {
            itemOnStation = temp;
            itemOnStation.transform.SetParent(transform);
        }
    }

    public override bool DoChop(Transform player)
    {
        if(!itemOnStation)
        {
            return false;
        }
        CutItem(itemOnStation,player);
        return true;
    }

    public void CutItem(GameObject itemToCut, Transform player)
    {
        //itemToCut = itemOnStation;
        IStationHelper.CutItem(itemToCut,player);
    }

    public void PickupItem(Transform player)
    {
        IStationHelper.PickupItem(this,player);
    }
}



using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuttingStation : Station, IDrop, ICut, IPickup
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public override bool DoPickupDrop()
    {        
        if (isOccupied)
        {
            if (itemOnStation.GetComponent<Vegetables>().veggieState == Vegetables.VegetablesState.partiallyCut  )
            {
                return false;
            }

            PickupItem();
        }
        else
        {
            DropItem();
        }

        return true;
    }

    public void DropItem()
    {
        GameObject temp = IStationHelper.DropItem(this);

        if(temp)
        {
            itemOnStation = temp;
            itemOnStation.transform.SetParent(transform);
        }
    }

    public override bool DoChop()
    {
        if(!itemOnStation)
        {
            return false;
        }
        CutItem(itemOnStation);
        return true;
    }

    public void CutItem(GameObject itemToCut)
    {
        //itemToCut = itemOnStation;
        IStationHelper.CutItem(itemToCut);
    }

    public void PickupItem()
    {
        IStationHelper.PickupItem(this);
    }
}



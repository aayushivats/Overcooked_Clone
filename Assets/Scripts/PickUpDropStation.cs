using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpDropStation : Station, IPickup, IDrop
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PickupItem()
    {
        IStationHelper.PickupItem(this);
    }

    public void DropItem()
    {
        GameObject temp = IStationHelper.DropItem(this);

        if (temp) 
        {
            itemOnStation = temp;
            itemOnStation.transform.SetParent(transform);
        }
    }

    public override bool DoPickupDrop()
    {
        Transform player = GameController.GetPlayer();
        if (isOccupied)
        {
            //itemonstaion is plate?
            if(itemOnStation.GetComponent<Plate>()!=null)
            {
                //if player has something in hand then dropitem
                if (player.GetComponent<PlayerMovement>().GetItem()!=null)
                {
                    DropItem();
                    return true;
                }
            }
            
            PickupItem();
            
            //else if player hand is empty then pick item

        }
        else
        {
            DropItem();
        }
        return true;
    }
}

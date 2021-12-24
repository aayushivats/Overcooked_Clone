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

    public void PickupItem(Transform player)
    {
        IStationHelper.PickupItem(this,player);
    }

    public void DropItem(Transform player)
    {
        GameObject temp = IStationHelper.DropItem(this,player);

        if (temp) 
        {
            itemOnStation = temp;
            itemOnStation.transform.SetParent(transform);
        }
    }

    public override bool DoPickupDrop(Transform player)
    {
        if (isOccupied)
        {
            //itemonstaion is plate?
            if(itemOnStation.GetComponent<Plate>()!=null)
            {
                //if player has something in hand then dropitem
                if (player.GetComponent<PlayerMovement>().GetItem()!=null)
                {
                    DropItem(player);
                    return true;
                }
            }
            
            PickupItem(player);
            
            //else if player hand is empty then pick item

        }
        else
        {
            DropItem(player);
        }
        return true;
    }
}

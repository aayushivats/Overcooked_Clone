using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpStation : Station, IPickup
{
    public override bool DoPickupDrop(Transform player)
    {
        PickupItem(player);
        return true;
    }

    public void PickupItem(Transform player)
    {
        IStationHelper.PickupItem(this,  player);
    }
}

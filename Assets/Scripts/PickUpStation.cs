using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpStation : Station, IPickup
{
    public override bool DoPickupDrop()
    {
        PickupItem();
        return true;
    }

    public void PickupItem()
    {
        IStationHelper.PickupItem(this);
    }
}

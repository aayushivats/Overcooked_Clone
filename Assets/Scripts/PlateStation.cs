using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateStation : Station, IPickup
{
    public int platesOnStation = 0;
    private bool wasEmpty = true;

    public void PickupItem()
    {
        if(platesOnStation > 0)
        {
            if(IStationHelper.PickupItem(this))
            {
                platesOnStation--;

                if(platesOnStation == 0)
                {
                    transform.GetChild(0).gameObject.SetActive(false);
                    wasEmpty = true;
                }
            }
        }
    }

    public override bool DoPickupDrop()
    {
        PickupItem();
        return true;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(wasEmpty && platesOnStation > 0)
        {
            transform.GetChild(0).gameObject.SetActive(true);
            wasEmpty = false;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DustbinStation : Station,IDrop
{

    public void DropItem()
    {
        GameObject temp = IStationHelper.DropItem(this);
        if(temp)
        {
            if (temp.GetComponent<CookingUtensil>() != null)
            {
                if (temp.GetComponentInChildren<Vegetables>() != null)
                {
                    Destroy(temp.GetComponentInChildren<Vegetables>().gameObject);
                }
            }
            else
            {
                Destroy(temp);
                
            }
        }
    }

    public override bool DoPickupDrop()
    {
        DropItem();
        return true;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

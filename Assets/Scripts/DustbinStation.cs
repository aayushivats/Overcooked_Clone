using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DustbinStation : Station,IDrop
{

    public void DropItem(Transform player)
    {
        GameObject temp = IStationHelper.DropItem(this,player);
        if(temp)
        {
            if (temp.GetComponent<CookingUtensil>() != null)
            {
                if (temp.GetComponentInChildren<Vegetables>() != null)
                {
                    Destroy(temp.GetComponentInChildren<Vegetables>().gameObject);
                }

                var playerScript = player.GetComponent<PlayerMovement>();
                playerScript.SetItem(temp);
                temp.transform.parent = player;
                temp.transform.position = player.position + player.forward * 2.5f;
                temp.transform.rotation = Quaternion.identity;
            }
            else
            {
                Destroy(temp);
                
            }
        }
    }

    public override bool DoPickupDrop(Transform player)
    {
        DropItem(player);
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
